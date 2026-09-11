using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Pfm.Core.Configuration;

public static class SafeNumericExpression
{
	private sealed class Parser
	{
		private const int MaximumDepth = 32;

		private const int MaximumOperations = 256;

		private readonly string _text;

		private readonly IReadOnlyDictionary<string, double> _variables;

		private int _position;

		private int _depth;

		private int _operations;

		private int _suppressionDepth;

		private bool IsEvaluating => _suppressionDepth == 0;

		public Parser(string text, IReadOnlyDictionary<string, double> variables, bool suppressEvaluation = false)
		{
			_text = text;
			_variables = variables;
			_suppressionDepth = (suppressEvaluation ? 1 : 0);
		}

		public double Parse()
		{
			double result = ParseOr();
			SkipWhitespace();
			if (_position != _text.Length)
			{
				throw Error($"Unexpected character '{_text[_position]}'.");
			}
			return result;
		}

		private double ParseOr()
		{
			double num = ParseAnd();
			while (Match("||"))
			{
				CountOperation();
				double value = (IsTrue(num) ? ParseSuppressed(ParseAnd) : ParseAnd());
				num = ((IsTrue(num) || IsTrue(value)) ? 1 : 0);
			}
			return num;
		}

		private double ParseAnd()
		{
			double num = ParseEquality();
			while (Match("&&"))
			{
				CountOperation();
				double value = ((!IsTrue(num)) ? ParseSuppressed(ParseEquality) : ParseEquality());
				num = ((IsTrue(num) && IsTrue(value)) ? 1 : 0);
			}
			return num;
		}

		private double ParseEquality()
		{
			double num = ParseComparison();
			while (true)
			{
				if (Match("=="))
				{
					CountOperation();
					num = ((Math.Abs(num - ParseComparison()) <= 1E-09) ? 1 : 0);
					continue;
				}
				if (!Match("!="))
				{
					break;
				}
				CountOperation();
				num = ((Math.Abs(num - ParseComparison()) > 1E-09) ? 1 : 0);
			}
			return num;
		}

		private double ParseComparison()
		{
			double num = ParseAdditive();
			while (true)
			{
				if (Match("<="))
				{
					CountOperation();
					num = ((num <= ParseAdditive()) ? 1 : 0);
					continue;
				}
				if (Match(">="))
				{
					CountOperation();
					num = ((num >= ParseAdditive()) ? 1 : 0);
					continue;
				}
				if (Match("<"))
				{
					CountOperation();
					num = ((num < ParseAdditive()) ? 1 : 0);
					continue;
				}
				if (!Match(">"))
				{
					break;
				}
				CountOperation();
				num = ((num > ParseAdditive()) ? 1 : 0);
			}
			return num;
		}

		private double ParseAdditive()
		{
			double num = ParseMultiplicative();
			while (true)
			{
				if (Match("+"))
				{
					CountOperation();
					num += ParseMultiplicative();
					continue;
				}
				if (!Match("-"))
				{
					break;
				}
				CountOperation();
				num -= ParseMultiplicative();
			}
			return num;
		}

		private double ParseMultiplicative()
		{
			double num = ParsePower();
			while (true)
			{
				if (Match("*"))
				{
					CountOperation();
					num *= ParsePower();
					continue;
				}
				if (Match("/"))
				{
					CountOperation();
					double num2 = ParsePower();
					if (IsEvaluating && Math.Abs(num2) <= double.Epsilon)
					{
						throw Error("Division by zero.");
					}
					num /= num2;
					continue;
				}
				if (!Match("%"))
				{
					break;
				}
				CountOperation();
				double num3 = ParsePower();
				if (IsEvaluating && Math.Abs(num3) <= double.Epsilon)
				{
					throw Error("Division by zero.");
				}
				num %= num3;
			}
			return num;
		}

		private double ParsePower()
		{
			double num = ParseUnary();
			if (Match("^"))
			{
				CountOperation();
				num = Math.Pow(num, ParsePower());
			}
			return num;
		}

		private double ParseUnary()
		{
			if (Match("+"))
			{
				return ParseUnary();
			}
			if (Match("-"))
			{
				return 0.0 - ParseUnary();
			}
			if (Match("!"))
			{
				return (!IsTrue(ParseUnary())) ? 1 : 0;
			}
			return ParsePrimary();
		}

		private double ParsePrimary()
		{
			SkipWhitespace();
			if (Match("("))
			{
				EnterDepth();
				double result = ParseOr();
				Require(")");
				_depth--;
				return result;
			}
			if (_position < _text.Length && (char.IsDigit(_text[_position]) || _text[_position] == '.'))
			{
				return ParseNumber();
			}
			string text = ParseIdentifier();
			if (text.Length == 0)
			{
				throw Error("Expected a number, variable, or function.");
			}
			if (!Match("("))
			{
				if (_variables.TryGetValue(text, out var value))
				{
					return value;
				}
				return text.ToLowerInvariant() switch
				{
					"pi" => Math.PI, 
					"e" => Math.E, 
					"true" => 1.0, 
					"false" => 0.0, 
					_ => throw Error("Unknown variable '" + text + "'."), 
				};
			}
			EnterDepth();
			if (text.Equals("if", StringComparison.OrdinalIgnoreCase))
			{
				double value2 = ParseOr();
				Require(",");
				double result2;
				double result3;
				if (IsTrue(value2))
				{
					result2 = ParseOr();
					Require(",");
					result3 = ParseSuppressed(ParseOr);
				}
				else
				{
					result2 = ParseSuppressed(ParseOr);
					Require(",");
					result3 = ParseOr();
				}
				Require(")");
				_depth--;
				CountOperation();
				if (!IsTrue(value2))
				{
					return result3;
				}
				return result2;
			}
			List<double> list = new List<double>();
			if (!Peek(")"))
			{
				do
				{
					list.Add(ParseOr());
					if (list.Count > 4)
					{
						throw Error("Functions support at most four arguments.");
					}
				}
				while (Match(","));
			}
			Require(")");
			_depth--;
			CountOperation();
			return EvaluateFunction(text, list);
		}

		private double EvaluateFunction(string name, IReadOnlyList<double> args)
		{
			if (!IsEvaluating)
			{
				ValidateFunction(name, args.Count);
				return 0.0;
			}
			switch (name.ToLowerInvariant())
			{
			case "abs":
				RequireCount(name, args, 1);
				return Math.Abs(args[0]);
			case "sqrt":
				RequireCount(name, args, 1);
				return Math.Sqrt(args[0]);
			case "round":
				RequireCount(name, args, 1);
				return Math.Round(args[0]);
			case "floor":
				RequireCount(name, args, 1);
				return Math.Floor(args[0]);
			case "ceil":
				RequireCount(name, args, 1);
				return Math.Ceiling(args[0]);
			case "sign":
				RequireCount(name, args, 1);
				return Math.Sign(args[0]);
			case "min":
				RequireCount(name, args, 2);
				return Math.Min(args[0], args[1]);
			case "max":
				RequireCount(name, args, 2);
				return Math.Max(args[0], args[1]);
			case "pow":
				RequireCount(name, args, 2);
				return Math.Pow(args[0], args[1]);
			case "clamp":
				RequireCount(name, args, 3);
				return Math.Clamp(args[0], args[1], args[2]);
			case "lerp":
				RequireCount(name, args, 3);
				return args[0] + (args[1] - args[0]) * args[2];
			default:
				throw Error("Unknown function '" + name + "'.");
			}
			static void RequireCount(string function, IReadOnlyList<double> values, int count)
			{
				if (values.Count != count)
				{
					throw new InvalidOperationException($"Function '{function}' expects {count} argument(s).");
				}
			}
		}

		private static void ValidateFunction(string name, int argumentCount)
		{
			int num;
			switch (name.ToLowerInvariant())
			{
			case "abs":
			case "sqrt":
			case "ceil":
			case "sign":
			case "floor":
			case "round":
				num = 1;
				break;
			case "min":
			case "pow":
			case "max":
				num = 2;
				break;
			case "lerp":
			case "clamp":
				num = 3;
				break;
			default:
				throw new InvalidOperationException("Unknown function '" + name + "'.");
			}
			int num2 = num;
			if (argumentCount != num2)
			{
				throw new InvalidOperationException($"Function '{name}' expects {num2} argument(s).");
			}
		}

		private double ParseNumber()
		{
			SkipWhitespace();
			int position = _position;
			while (true)
			{
				bool flag = _position < _text.Length;
				bool flag2;
				if (flag)
				{
					flag2 = char.IsDigit(_text[_position]);
					if (!flag2)
					{
						bool flag3;
						switch (_text[_position])
						{
						case '+':
						case '-':
						case '.':
						case 'E':
						case 'e':
							flag3 = true;
							break;
						default:
							flag3 = false;
							break;
						}
						flag2 = flag3;
					}
					flag = flag2;
				}
				if (!flag)
				{
					break;
				}
				char c = _text[_position];
				flag2 = ((c == '+' || c == '-') ? true : false);
				flag = flag2 && _position > position;
				if (flag)
				{
					char c2 = _text[_position - 1];
					bool flag3 = ((c2 == 'E' || c2 == 'e') ? true : false);
					flag = !flag3;
				}
				if (flag)
				{
					break;
				}
				_position++;
			}
			string text = _text;
			int num = position;
			if (!double.TryParse(text.Substring(num, _position - num), NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
			{
				throw Error("Invalid number.");
			}
			return result;
		}

		private string ParseIdentifier()
		{
			SkipWhitespace();
			int position = _position;
			if (_position < _text.Length && (char.IsLetter(_text[_position]) || _text[_position] == '_'))
			{
				_position++;
				while (_position < _text.Length && (char.IsLetterOrDigit(_text[_position]) || _text[_position] == '_'))
				{
					_position++;
				}
			}
			string text = _text;
			int num = position;
			return text.Substring(num, _position - num);
		}

		private bool Match(string token)
		{
			SkipWhitespace();
			if (!_text.AsSpan(_position).StartsWith(token.AsSpan(), StringComparison.Ordinal))
			{
				return false;
			}
			_position += token.Length;
			return true;
		}

		private bool Peek(string token)
		{
			SkipWhitespace();
			return _text.AsSpan(_position).StartsWith(token.AsSpan(), StringComparison.Ordinal);
		}

		private void Require(string token)
		{
			if (!Match(token))
			{
				throw Error("Expected '" + token + "'.");
			}
		}

		private void SkipWhitespace()
		{
			while (_position < _text.Length && char.IsWhiteSpace(_text[_position]))
			{
				_position++;
			}
		}

		private void EnterDepth()
		{
			if (++_depth > 32)
			{
				throw Error("Formula is nested too deeply.");
			}
		}

		private void CountOperation()
		{
			if (++_operations > 256)
			{
				throw Error("Formula contains too many operations.");
			}
		}

		private InvalidOperationException Error(string message)
		{
			return new InvalidOperationException($"{message} At position {_position + 1}.");
		}

		private double ParseSuppressed(Func<double> parser)
		{
			_suppressionDepth++;
			try
			{
				parser();
				return 0.0;
			}
			finally
			{
				_suppressionDepth--;
			}
		}

		private static bool IsTrue(double value)
		{
			return Math.Abs(value) > 1E-09;
		}
	}

	public const int MaximumLength = 512;

	public static double Evaluate(string expression, IReadOnlyDictionary<string, double> variables)
	{
		if (string.IsNullOrWhiteSpace(expression))
		{
			throw new InvalidOperationException("Formula cannot be empty.");
		}
		if (expression.Length > 512)
		{
			throw new InvalidOperationException($"Formula cannot exceed {512} characters.");
		}
		double num;
		try
		{
			num = new Parser(expression, variables).Parse();
		}
		catch (InvalidOperationException)
		{
			throw;
		}
		catch (Exception ex2) when (((ex2 is ArithmeticException || ex2 is ArgumentException) ? 1 : 0) != 0)
		{
			throw new InvalidOperationException("Formula math error: " + ex2.Message, ex2);
		}
		if (!double.IsFinite(num))
		{
			throw new InvalidOperationException("Formula result must be a finite number.");
		}
		return num;
	}

	public static void Validate(string expression, IEnumerable<string> variableNames)
	{
		if (string.IsNullOrWhiteSpace(expression))
		{
			throw new InvalidOperationException("Formula cannot be empty.");
		}
		if (expression.Length > 512)
		{
			throw new InvalidOperationException($"Formula cannot exceed {512} characters.");
		}
		Dictionary<string, double> variables = variableNames.ToDictionary<string, string, double>((string name) => name, (string _) => 1.0, StringComparer.OrdinalIgnoreCase);
		new Parser(expression, variables, suppressEvaluation: true).Parse();
	}
}
