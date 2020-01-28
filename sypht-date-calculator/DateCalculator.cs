using System;
using System.Collections.Generic;

namespace sypht_date_calculator
{
	public class DateCalculator
	{
		const string DateIsInIncorrectFormatExceptionMessage = "Date {0} is in incorrect format";
		int[] monthDaysArray = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

		public int Calculate(string date1, string date2)
		{
			var dateParts1 = ParseDateParts(date1);
			var dateParts2 = ParseDateParts(date2);

			var date1Days = CalculateNumberOfDays(dateParts1);
			var date2Days = CalculateNumberOfDays(dateParts2);

			return Math.Max(Math.Abs(date1Days - date2Days) - 1, 0);
		}

		private int CalculateNumberOfDays(int[] integerDateParts)
		{
			var day = integerDateParts[0];
			var month = integerDateParts[1];
			var year = integerDateParts[2];

			var numberOfLeapYearsBeforeThisYear = (year - 1) / 4;
			var numberOfDaysInLeapYearsBeforeThisYear = numberOfLeapYearsBeforeThisYear * 366;
			var numberOfNonLeapYearDaysBeforeThisYear = (year - numberOfLeapYearsBeforeThisYear - 1) * 365;

			var numberOfDaysBeforeThisMonth = 0;

			for(var i = 0; i < month - 1; i++)
			{
				numberOfDaysBeforeThisMonth += monthDaysArray[i];
			}

			var numberOfDaysInThisYear = numberOfDaysBeforeThisMonth + day;

			return numberOfDaysInLeapYearsBeforeThisYear + numberOfNonLeapYearDaysBeforeThisYear + numberOfDaysInThisYear;
		}

		private int[] ParseDateParts(string date)
		{
			var dateParts = date.Split("/");

			if (dateParts.Length != 3)
			{
				throw new ArgumentException(string.Format(DateIsInIncorrectFormatExceptionMessage, date));
			}

			var integerDateParts = new List<int>();

			foreach(var datePart in dateParts)
			{
				if (!int.TryParse(datePart, out var integerDatePart) || integerDatePart < 0) {
					throw new ArgumentException(string.Format(DateIsInIncorrectFormatExceptionMessage, date));
				}

				integerDateParts.Add(integerDatePart);
			}

			return integerDateParts.ToArray();
		}
	}
}
