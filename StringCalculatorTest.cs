using System;
using NUnit.Framework;

namespace Pyroxene.Kata.StringCalculator
{
	[TestFixture]
	public class StringCalculatorTest
	{
		[Test]
		public void ReturnsZeroWhenArgumentIsEmptyString() {
			Assert.AreEqual(0, MakeStringCalculator().Add(""));
		}

		[Test]
		public void ReturnsOneWhenArgumentIsOne() {
			Assert.AreEqual(1, MakeStringCalculator().Add("1"));
		}

		[Test]
		public void ReturnsSumOfTwoNumbersCommaSeparated() {
			Assert.AreEqual(3, MakeStringCalculator().Add("1,2"));
		}

		[Test]
		public void ReturnsSumOfMoreThanTwoNumbers() {
			Assert.AreEqual(10, MakeStringCalculator().Add("1,2,3,4"));
		}

		[Test]
		public void HandleNewLineAsDelimiters() {
			Assert.AreEqual(6, MakeStringCalculator().Add("1\n,2,3"));
		}

		[Test]
		public void HandleNewDelimiterGivenAfterTwoSlashes() {
			Assert.AreEqual(6, MakeStringCalculator().Add("//;\n1;2;3"));
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void ShouldThrowException() {
			MakeStringCalculator().Add("-1");
		}

		[Test]
		public void IgnoreNumbersBiggerThan1000() {
			Assert.AreEqual(3, MakeStringCalculator().Add("1,1000,2"));
		}

		// bugs:
		// hard: new lines not working when using custom delimiter
		[Test]
		public void HandleNewDelimiterWithNewLines() {
			Assert.AreEqual(60, MakeStringCalculator().Add("//;\n10;20\n30;\n"));
		}

		// easy: wrong input
		[Test]
		public void HandleNull() {
			Assert.AreEqual(0, MakeStringCalculator().Add(null));
		}

		// edge case, 999 should still be counted
		[Test]
		public void ShouldCount999() {
			Assert.AreEqual(1000, MakeStringCalculator().Add("1,999"));
		}

		private StringCalculator MakeStringCalculator() {
			return new StringCalculator();
		}
	}
}
