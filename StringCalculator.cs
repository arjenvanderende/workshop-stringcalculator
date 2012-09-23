using System;

namespace Pyroxene.Kata.StringCalculator
{
	public class StringCalculator
	{
		public int Add(string input) {
			return Add(new NumberedString(input));
		}

		private int Add(NumberedString input) {
			NumberedString replacedInput = input.ReturnNewInstanceWithNewLinesReplacedByDelimiter();
			string[] split = replacedInput.GetNumbersAsString();
			if (HasOneArgument(split)) {
				return ParseNumber(replacedInput.GetInput());
			}
			int total = 0;
			foreach (string piece in split) {
				int value = ParseNumber(piece);
				if (value < 0) throw new ArgumentException("negatives not allowed");
				if (value < 999) {
					total += value;
				}
			}
			return total;
		}

		private int ParseNumber(string input) {
			try {
				return int.Parse(input);
			} catch (FormatException) {
				return 0;
			}
		}

		private bool HasOneArgument(string[] split) {
			return split.Length == 0;
		}

		private class NumberedString {
			private const string Slashes = "//";
			private const int IndexAfterSlashes = 2;

			private readonly string delimiter = ",";
			private readonly string input;

			public NumberedString(string input) {
				this.input = input;
				if (input.StartsWith(Slashes)) {
					delimiter = input.Substring(IndexAfterSlashes, getFirstNewLine(input));
					this.input = input.Substring(getFirstNewLine(input));
				}
			}

			private NumberedString(string input, string delimiter) {
				this.input = input;
				this.delimiter = delimiter;
			}

			private int getFirstNewLine(string value) {
				return value.IndexOf('\n') - 1;
			}

			public NumberedString ReturnNewInstanceWithNewLinesReplacedByDelimiter() {
				return new NumberedString(input.Replace("\n", delimiter), delimiter);
			}

			public string GetInput() {
				return input;
			}

			public string[] GetNumbersAsString() {
				return input.Split(delimiter.ToCharArray());
			}
		}
	}
}