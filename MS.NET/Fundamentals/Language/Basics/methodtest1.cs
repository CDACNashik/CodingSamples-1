using System;

static class Program
{
	private static double Income(double invest, int period, bool risky=false)
	{
		float rate = risky ? 9 : 6;
		double amount = invest * Math.Pow(1 + rate / 100, period);
		return amount - invest;
	}

	private static double Income(double invest)
	{
		return Income(invest, 1, invest < 10000);
	}

	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		if(args.Length > 1)
		{
			int n = int.Parse(args[1]);
			Console.WriteLine("Income in Gold scheme will be {0:0.00}", Income(p, n, true)); //passing arguments by position
			Console.WriteLine("Income in Bronze scheme will be {0:0.00}", Income(period: n, invest: p)); //passing arguments by name
		}
		else
		{
			Console.WriteLine("Income in Smart scheme will be {0:0.00}", Income(p));
		}
	}
}
