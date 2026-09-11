using System;
using System.Diagnostics;
using System.IO;

namespace Pfm.Services.Vision;

public static class PtModelConverter
{
	public static string EnsureOnnx(string modelPath)
	{
		string extension = Path.GetExtension(modelPath);
		if (extension.Equals(".onnx", StringComparison.OrdinalIgnoreCase))
		{
			return modelPath;
		}
		if (!extension.Equals(".pt", StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidOperationException("Unsupported model format: " + extension);
		}
		string text = Path.ChangeExtension(modelPath, ".onnx");
		if (File.Exists(text) && File.GetLastWriteTimeUtc(text) >= File.GetLastWriteTimeUtc(modelPath))
		{
			return text;
		}
		using Process process = Process.Start(new ProcessStartInfo("yolo")
		{
			Arguments = "export model=\"" + modelPath + "\" format=onnx imgsz=640",
			UseShellExecute = false,
			CreateNoWindow = true,
			RedirectStandardOutput = true,
			RedirectStandardError = true
		}) ?? throw new InvalidOperationException("Failed to start yolo export process. Ensure YOLO CLI is installed.");
		string value = process.StandardOutput.ReadToEnd();
		string value2 = process.StandardError.ReadToEnd();
		if (!process.WaitForExit(120000))
		{
			process.Kill(entireProcessTree: true);
			throw new InvalidOperationException("yolo export timed out after 120 seconds.");
		}
		if (process.ExitCode != 0 || !File.Exists(text))
		{
			throw new InvalidOperationException($"yolo export failed (exit {process.ExitCode}).\n{value2}\n{value}");
		}
		return text;
	}
}
