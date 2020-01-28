using sypht_date_calculator;
using System;
using Xunit;

namespace tests
{
	public class DateCalculatorUnitTests
	{
		[Theory]
		[InlineData("02/06/1983", "22/06/1983", 19)]
		[InlineData("04/07/1984", "25/12/1984", 173)]
		[InlineData("03/01/1989", "03/08/1983", 1979)]
		[InlineData("03/08/2018", "04/08/2018", 0)]
		[InlineData("03/08/2018", "03/08/2018", 0)]
		[InlineData("01/01/2000", "03/01/2000", 1)]
		public void Calculate_DateDifferenceCorrectly_When_DatesAreCorrect(string date1, string date2, int difference)
		{
			var dateCalculator = new DateCalculator();
			var calculatedDifference = dateCalculator.Calculate(date1, date2);
			Assert.Equal(difference, calculatedDifference);
		}

		[Theory]
		[InlineData("0206/1983", "22/06/1983")]
		[InlineData("02/06/1983", "2206/1983")]
		[InlineData("02/-06/1983", "22/06/1983")]
		[InlineData("02/06/1983", "22/06/-1983")]
		public void Calculate_ThrowsError_When_DateIsIncorrectFormat(string date1, string date2)
		{
			var dateCalculator = new DateCalculator();
			Assert.Throws<ArgumentException>(() => dateCalculator.Calculate(date1, date2));
		}
	}
}
