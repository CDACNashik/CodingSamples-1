using Payroll;
using System;

static class Program
{
	private static double GetAverageIncome(Employee[] group)
	{
		double total = 0;
		foreach(Employee member in group)
		{
			total += member.GetIncome();
		}
		return total / group.Length;
	}

	private static double GetTotalSales(Employee[] group)
	{
		double total = 0;
		foreach(Employee member in group)
		{
			SalesPerson sp = member as SalesPerson;
			if(sp != null)
				total += sp.Sales;
		}
		return total;
	}

	public static void Main()
	{
		Employee[] department = new Employee[5];
		department[0] = new Employee(50, 58);
		department[1] = new Employee(38, 63);
		department[2] = new SalesPerson(47, 45, 4400);
		department[3] = new Employee(55, 125);
		department[4] = new SalesPerson(36, 46, 5600);
		Console.WriteLine("Average income = {0:0.00}", GetAverageIncome(department));
		Console.WriteLine("Total sales    = {0:0.00}", GetTotalSales(department));

	}
}
