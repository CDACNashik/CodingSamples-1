using Payroll;
using System;

static class Program
{
	public static double GetTax(Employee emp)
	{
		double i = emp.GetIncome();
		return i > 3500 ? 0.10 * (i - 3500) : 0;
	}

	public static void Main()
	{
		Employee jack = new Employee();
		jack.Hours = 50;
		jack.Rate = 58;
		Console.WriteLine("Jack's ID is {0} and Income is {1:0.00} with Tax of {2:0.00}", jack.Id, jack.GetIncome(), GetTax(jack));

		SalesPerson jill = new SalesPerson(50, 58, 8600);
		Console.WriteLine("Jill's ID is {0} and Income is {1:0.00} with Tax of {2:0.00}", jill.Id, jill.GetIncome(), GetTax(jill));

		Console.WriteLine("Number of Employees = {0}", Employee.CountActive());

	}
}

