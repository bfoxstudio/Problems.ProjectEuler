﻿using System.Collections.Generic;
using System.Linq;
using Demo.ProjectEuler.Core;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0061
{
	public class CyclicalFigurateNumbersTest : BaseTest
	{
		private readonly CyclicalFigurateNumbers _sut = new CyclicalFigurateNumbers();

		public CyclicalFigurateNumbersTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestGeneratingFourDigitTriangleNumbers()
		{
			var fourDigitTriangleNumbers = _sut.GetFourDigitTriangleNumbers().ToList();
			var actual = fourDigitTriangleNumbers.Count;

			_output.WriteLine("fourDigitTriangleNumbers.Count: {0}", actual);
			const int expected = 96;	// calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitSquareNumbers()
		{
			var fourDigitSquareNumbers = _sut.GetFourDigitSquareNumbers().ToList();
			var actual = fourDigitSquareNumbers.Count;

			_output.WriteLine("fourDigitSquareNumbers.Count: {0}", actual);
			const int expected = 68;    // 100-32
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitPentagonalNumbers()
		{
			var fourDigitPentagonalNumbers = _sut.GetFourDigitPentagonalNumbers().ToList();
			var actual = fourDigitPentagonalNumbers.Count;

			_output.WriteLine("fourDigitPentagonalNumbers.Count: {0}", actual);
			const int expected = 56;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

	}

	public class CyclicalFigurateNumbers
	{
		private readonly NumberGenerator _numberGenerator = new NumberGenerator();
		private const int LIMIT = 10000;

		public IEnumerable<long> GetFourDigitPentagonalNumbers()
		{
			for (int n = 26; ; n++)
			{
				var squareNumber = _numberGenerator.GetPentagonalNumber(n);
				if (squareNumber < LIMIT)
					yield return squareNumber;
				else
					yield break;
			}

		}

		public IEnumerable<long> GetFourDigitSquareNumbers()
		{
			for (int n = 32; ; n++)
			{
				var squareNumber = _numberGenerator.GetSquareNumber(n);
				if (squareNumber < LIMIT)
					yield return squareNumber;
				else
					yield break;
			}
		}

		public IEnumerable<long> GetFourDigitTriangleNumbers()
		{
			// First 4-digit triangle number starts at 45: 
			// calculated using http://www.mathgoodies.com/calculators/triangular-numbers.html
			for (int n = 45;; n++)
			{
				var triangleNumber = _numberGenerator.GetTriangleNumber(n);
				if (triangleNumber < LIMIT)
					yield return triangleNumber;
				else
					yield break;
			}
		}
	}
}
