using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Pfm.Core.Vision;

namespace Pfm.Services.Vision;

public sealed class OnnxYoloObjectDetectionRunner : IAiObjectDetectionRunner, IDisposable, IModelSessionResetter
{
	private sealed record SessionInfo(InferenceSession Session, string InputName, int InputWidth, int InputHeight, IReadOnlyList<string> OutputNames, float[] InputBuffer);

	private readonly record struct LetterboxTransform(double Scale, int PadX, int PadY, int FrameWidth, int FrameHeight);

	private sealed class DetectionCandidate
	{
		public int ClassId { get; init; }

		public double Confidence { get; init; }

		public int X { get; init; }

		public int Y { get; init; }

		public int Width { get; init; }

		public int Height { get; init; }
	}

	private readonly Dictionary<string, SessionInfo> _sessions = new Dictionary<string, SessionInfo>();

	private readonly object _sync = new object();

	public AiDetectionResult Detect(in PixelFrame frame, string modelFilePath, double confidenceThreshold, int targetClassId = 0, int playerBarClassId = 1, int progressClassId = -1)
	{
		string text = PtModelConverter.EnsureOnnx(modelFilePath);
		lock (_sync)
		{
			if (!_sessions.TryGetValue(text, out SessionInfo value))
			{
				RuntimeDiagnostics.Write("Loading ONNX session '" + text + "'");
				value = LoadModel(text);
				_sessions[text] = value;
				RuntimeDiagnostics.Write($"ONNX session loaded input={value.InputWidth}x{value.InputHeight}");
			}
			int inputWidth = value.InputWidth;
			int inputHeight = value.InputHeight;
			LetterboxTransform transform = Preprocess(frame, value.InputBuffer, inputWidth, inputHeight);
			DenseTensor<float> value2 = new DenseTensor<float>(value.InputBuffer, new int[4] { 1, 3, inputHeight, inputWidth });
			using IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results = value.Session.Run(new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor(value.InputName, value2) }, value.OutputNames);
			return Postprocess(results, transform, confidenceThreshold, targetClassId, playerBarClassId, progressClassId);
		}
	}

	public void Dispose()
	{
		lock (_sync)
		{
			foreach (SessionInfo value in _sessions.Values)
			{
				value.Session.Dispose();
			}
			_sessions.Clear();
		}
	}

	public void ResetModelSession(string modelFilePath)
	{
		string text = PtModelConverter.EnsureOnnx(modelFilePath);
		lock (_sync)
		{
			if (_sessions.Remove(text, out SessionInfo value))
			{
				value.Session.Dispose();
				RuntimeDiagnostics.Write("ONNX session unloaded '" + text + "'");
			}
		}
	}

	private static SessionInfo LoadModel(string modelFilePath)
	{
		InferenceSession inferenceSession = new InferenceSession(modelFilePath);
		IReadOnlyDictionary<string, NodeMetadata> inputMetadata = inferenceSession.InputMetadata;
		string text = inputMetadata.Keys.First();
		int[] dimensions = inputMetadata[text].Dimensions;
		int num = dimensions[3];
		int num2 = dimensions[2];
		string[] outputNames = inferenceSession.OutputNames.ToArray();
		return new SessionInfo(inferenceSession, text, num, num2, outputNames, new float[3 * num * num2]);
	}

	private unsafe static LetterboxTransform Preprocess(PixelFrame frame, float[] destination, int targetWidth, int targetHeight)
	{
		int num = targetWidth * targetHeight;
		Span<float> span = new Span<float>(destination, 0, num);
		Span<float> span2 = new Span<float>(destination, num, num);
		Span<float> span3 = new Span<float>(destination, 2 * num, num);
		Array.Fill(destination, 38f / 85f, 0, 3 * num);
		double num2 = Math.Min((double)targetWidth / (double)frame.Width, (double)targetHeight / (double)frame.Height);
		int num3 = Math.Max(1, (int)Math.Round((double)frame.Width * num2));
		int num4 = Math.Max(1, (int)Math.Round((double)frame.Height * num2));
		int num5 = (targetWidth - num3) / 2;
		int num6 = (targetHeight - num4) / 2;
		for (int i = 0; i < num4; i++)
		{
			int num7 = Math.Min(frame.Height - 1, (int)((double)i / num2));
			byte* ptr = frame.Pixels + num7 * frame.Stride;
			for (int j = 0; j < num3; j++)
			{
				int num8 = Math.Min(frame.Width - 1, (int)((double)j / num2));
				byte* ptr2 = ptr + num8 * 4;
				int index = (i + num6) * targetWidth + j + num5;
				span[index] = (float)(int)ptr2[2] / 255f;
				span2[index] = (float)(int)ptr2[1] / 255f;
				span3[index] = (float)(int)(*ptr2) / 255f;
			}
		}
		return new LetterboxTransform(num2, num5, num6, frame.Width, frame.Height);
	}

	private static AiDetectionResult Postprocess(IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results, LetterboxTransform transform, double confidenceThreshold, int targetClassId, int playerBarClassId, int progressClassId)
	{
		Tensor<float> output = results.First().AsTensor<float>();
		ReadOnlySpan<int> dimensions = output.Dimensions;
		bool channelsFirst = dimensions[1] < dimensions[2];
		int num = (channelsFirst ? dimensions[1] : dimensions[2]);
		int num2 = (channelsFirst ? dimensions[2] : dimensions[1]);
		int num3 = num - 4;
		List<DetectionCandidate> list = new List<DetectionCandidate>();
		int i;
		for (i = 0; i < num2; i++)
		{
			float num4 = At(0);
			float num5 = At(1);
			float num6 = At(2);
			float num7 = At(3);
			int num8 = -1;
			double num9 = confidenceThreshold;
			for (int j = 0; j < num3; j++)
			{
				float num10 = At(4 + j);
				double num11 = ((num10 >= 0f && num10 <= 1f) ? ((double)num10) : Sigmoid(num10));
				if (num11 > num9)
				{
					num9 = num11;
					num8 = j;
				}
			}
			if (num8 >= 0)
			{
				double num12 = (double)(num4 - num6 / 2f - (float)transform.PadX) / transform.Scale;
				double num13 = (double)(num5 - num7 / 2f - (float)transform.PadY) / transform.Scale;
				double num14 = (double)(num4 + num6 / 2f - (float)transform.PadX) / transform.Scale;
				double num15 = (double)(num5 + num7 / 2f - (float)transform.PadY) / transform.Scale;
				if (!(num14 <= 0.0) && !(num15 <= 0.0) && !(num12 >= (double)transform.FrameWidth) && !(num13 >= (double)transform.FrameHeight))
				{
					int num16 = (int)Math.Round(Math.Clamp(num12, 0.0, transform.FrameWidth - 1));
					int num17 = (int)Math.Round(Math.Clamp(num13, 0.0, transform.FrameHeight - 1));
					int num18 = (int)Math.Round(Math.Clamp(num14, num16 + 1, transform.FrameWidth));
					int num19 = (int)Math.Round(Math.Clamp(num15, num17 + 1, transform.FrameHeight));
					list.Add(new DetectionCandidate
					{
						ClassId = num8,
						Confidence = num9,
						X = num16,
						Y = num17,
						Width = num18 - num16,
						Height = num19 - num17
					});
				}
			}
		}
		List<DetectionCandidate> source = NonMaxSuppression(list, 0.5);
		DetectionCandidate detectionCandidate = source.FirstOrDefault((DetectionCandidate b) => b.ClassId == targetClassId);
		DetectionCandidate detectionCandidate2 = source.FirstOrDefault((DetectionCandidate b) => b.ClassId == playerBarClassId);
		DetectionCandidate detectionCandidate3 = ((progressClassId >= 0) ? source.FirstOrDefault((DetectionCandidate b) => b.ClassId == progressClassId) : null);
		AiDetectionBox[] boxes = source.Select((DetectionCandidate box) => new AiDetectionBox(box.X, box.Y, box.Width, box.Height, box.Confidence, box.ClassId)).ToArray();
		return new AiDetectionResult((detectionCandidate != null) ? new AiDetectionBox?(new AiDetectionBox(detectionCandidate.X, detectionCandidate.Y, detectionCandidate.Width, detectionCandidate.Height, detectionCandidate.Confidence, detectionCandidate.ClassId)) : ((AiDetectionBox?)null), (detectionCandidate2 != null) ? new AiDetectionBox?(new AiDetectionBox(detectionCandidate2.X, detectionCandidate2.Y, detectionCandidate2.Width, detectionCandidate2.Height, detectionCandidate2.Confidence, detectionCandidate2.ClassId)) : ((AiDetectionBox?)null), (detectionCandidate3 != null) ? new AiDetectionBox?(new AiDetectionBox(detectionCandidate3.X, detectionCandidate3.Y, detectionCandidate3.Width, detectionCandidate3.Height, detectionCandidate3.Confidence, detectionCandidate3.ClassId)) : ((AiDetectionBox?)null), boxes);
		float At(int feature)
		{
			if (!channelsFirst)
			{
				return output[new int[3] { 0, i, feature }];
			}
			return output[new int[3] { 0, feature, i }];
		}
	}

	private static double Sigmoid(double value)
	{
		return 1.0 / (1.0 + Math.Exp(0.0 - value));
	}

	private static List<DetectionCandidate> NonMaxSuppression(List<DetectionCandidate> candidates, double iouThreshold)
	{
		List<DetectionCandidate> list = new List<DetectionCandidate>();
		List<DetectionCandidate> list2 = candidates.OrderByDescending((DetectionCandidate c) => c.Confidence).ToList();
		while (list2.Count > 0)
		{
			DetectionCandidate best = list2[0];
			list.Add(best);
			list2.RemoveAt(0);
			list2.RemoveAll((DetectionCandidate c) => c.ClassId == best.ClassId && IoU(best, c) > iouThreshold);
		}
		return list;
	}

	private static double IoU(DetectionCandidate a, DetectionCandidate b)
	{
		int num = Math.Max(a.X, b.X);
		int num2 = Math.Max(a.Y, b.Y);
		int num3 = Math.Min(a.X + a.Width, b.X + b.Width);
		int num4 = Math.Min(a.Y + a.Height, b.Y + b.Height);
		int num5 = Math.Max(0, num3 - num) * Math.Max(0, num4 - num2);
		int num6 = a.Width * a.Height;
		int num7 = b.Width * b.Height;
		int num8 = num6 + num7 - num5;
		return (num8 > 0) ? (num5 / num8) : 0;
	}

	AiDetectionResult IAiObjectDetectionRunner.Detect(in PixelFrame frame, string modelFilePath, double confidenceThreshold, int targetClassId = 0, int playerBarClassId = 1, int progressClassId = -1)
	{
		return Detect(in frame, modelFilePath, confidenceThreshold, targetClassId, playerBarClassId, progressClassId);
	}
}
