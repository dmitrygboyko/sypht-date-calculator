using System;

namespace sypht_date_calculator
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.Write("Please enter a first date: ");
				var firstDate = Console.ReadLine();
				Console.Write("Please enter a second date: ");
				var secondDate = Console.ReadLine();
				var dateCalculator = new DateCalculator();
				var dateDifference = dateCalculator.Calculate(firstDate, secondDate);
				Console.WriteLine($"Date difference: {dateDifference}");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Console.ReadLine();
		}
	}
}
