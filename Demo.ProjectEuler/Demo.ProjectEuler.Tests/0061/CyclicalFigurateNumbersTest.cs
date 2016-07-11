﻿using System;
using System.Collections.Generic;
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

		[Fact]
		public void TestGeneratingFourDigitHexagonalNumbers()
		{
			var fourDigitHexagonalNumbers = _sut.GetFourDigitHexagonalNumbers().ToList();
			var actual = fourDigitHexagonalNumbers.Count;

			_output.WriteLine("fourDigitHexagonalNumbers.Count: {0}", actual);
			const int expected = 48;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitHeptagonalNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitHeptagonalNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 43;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestGeneratingFourDigitOctagonalNumbers()
		{
			var fourDigitNumber = _sut.GetFourDigitOctagonalNumbers().ToList();
			var actual = fourDigitNumber.Count;

			_output.WriteLine("fourDigitNumber.Count: {0}", actual);
			const int expected = 40;    // calculated via trial-error.
			Assert.Equal(expected, actual);
		}
	}

	public class CyclicalFigurateNumbers
	{
		private readonly NumberGenerator _numberGenerator = new NumberGenerator();
		private const int LOWER_LIMIT = 999;
		private const int UPPER_LIMIT = 10000;

		public IEnumerable<long> GetFourDigitTriangleNumbers()
		{
			// First 4-digit triangle number starts at 45: 
			// calculated using http://www.mathgoodies.com/calculators/triangular-numbers.html
			const int startIndex = 45;  // from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetTriangleNumber);
		}

		public IEnumerable<long> GetFourDigitSquareNumbers()
		{
			const int startIndex = 32;  // from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetSquareNumber);
		}

		public IEnumerable<long> GetFourDigitPentagonalNumbers()
		{
			const int startIndex = 26;  // from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetPentagonalNumber);
		}

		public IEnumerable<long> GetFourDigitHexagonalNumbers()
		{
			const int startIndex = 23;	// from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetHexagonalNumber);
		}

		public IEnumerable<long> GetFourDigitHeptagonalNumbers()
		{
			const int startIndex = 21;  // from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetHeptagonalNumber);
		}

		public IEnumerable<long> GetFourDigitOctagonalNumbers()
		{
			const int startIndex = 19;  // from trial and error.
			return GetNumbers(startIndex, _numberGenerator.GetOctagonalNumber);
		}

		public IEnumerable<long> GetNumbers(int startIndex, Func<long, long> numberGenerator)
		{
			for (int n = startIndex; ; n++)
			{
				var number = numberGenerator(n);
				if (LOWER_LIMIT < number && number < UPPER_LIMIT)
				{
					Console.WriteLine(n);
					yield return number;
				}

				if (number >= UPPER_LIMIT)
					yield break;
			}
		}
	}
}
