﻿using System;
using System.Linq;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0032
{
	public class PandigitalProductsTest : BaseTest
	{
		private readonly PandigitalProducts _sut = new PandigitalProducts();

		public PandigitalProductsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestIsSpecialPandigital()
		{
			var specialPandigitalCandidate = new Tuple<int, int, int>(39, 186, 7254);
			bool isSpecialPandigital = _sut.IsSpecialPandigital(specialPandigitalCandidate);

			Assert.True(isSpecialPandigital);
		}
	}

	public class PandigitalProducts
	{
		public bool IsSpecialPandigital(Tuple<int, int, int> specialPandigitalCandidate)
		{
			int[] pandigitalSequence = {1, 2, 3, 4, 5, 6, 7, 8, 9};

			var candidateString = string.Format("{0}{1}{2}", 
				specialPandigitalCandidate.Item1, specialPandigitalCandidate.Item2, specialPandigitalCandidate.Item3);
			var candidateSequence = candidateString.Select(c => Convert.ToInt32(c.ToString())).ToList();
			candidateSequence.Sort();

			return candidateSequence.SequenceEqual(pandigitalSequence);
		}
	}
}
