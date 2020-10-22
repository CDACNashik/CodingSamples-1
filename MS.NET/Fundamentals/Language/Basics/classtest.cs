using System;

class Investment
{
	private double invest;
	private int period;
	private bool risky;

	public Investment(double p, int n)
	{
		invest = p;
		period = n;
		risky = false;
	}

	public void AllowRisk(bool yes)
	{
		risky = yes;
	}

	public double Income()
	{
		float rate = risky ? 9 : 6;
		double amount = invest * Math.Pow(1 + rate / 100, period);
		return amount - invest;
	}
}

static class Program
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		int n = int.Parse(args[1]);
		Investment inv = new Investment(p, n);
		Console.WriteLine("Income in Bronze scheme will be {0:0.00}", inv.Income());
		inv.AllowRisk(true);
		Console.WriteLine("Income in Gold scheme will be {0:0.00}", inv.Income());
	}
}
