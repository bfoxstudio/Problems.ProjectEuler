﻿using System.Collections.Generic;
using Demo.ProjectEuler.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.ProjectEuler.Tests._0018
{
	public class MaximumPathSumOneTest : BaseTest
	{
		private readonly MaximumPathSum _sut = new MaximumPathSum();
		private const string SAMPLE_DATA = 
@"3
7 4
2 4 6
8 5 9 3";

		public MaximumPathSumOneTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestParsingInput()
		{
			var expected = new List<IEnumerable<int>>
			{
				new[] {3},
				new[] {7, 4},
				new[] {2, 4, 6},
				new[] {8, 5, 9, 3}
			};

			IEnumerable<IEnumerable<int>> actual = _sut.ParseInput(SAMPLE_DATA);

			Assert.True(IsMultidimensionalArraySequenceEqual<int>(expected, actual));
		}

		[Fact]
		public void TestGettingMaximumValueForSampleData()
		{
			const int expected = 23;

			int actual = _sut.GetMximumPathSum(SAMPLE_DATA);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ShowResult()
		{
			const string input =
@"75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

			int result = _sut.GetMximumPathSum(input);

			_output.WriteLine(result.ToString());
		}
	}
}
