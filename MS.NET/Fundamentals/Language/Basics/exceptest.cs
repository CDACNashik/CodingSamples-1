using System;

enum RiskLevel {None, Low, Medium, High}

class Investment
{
	private double invest;
	private int period;
	private RiskLevel risk;

	public Investment(double p, int n)
	{
		if(p < 5000)
			throw new ArgumentException("Low amount");
		invest = p;
		period = n;
		risk = RiskLevel.None;
	}

	public void AllowRisk(bool yes)
	{
		risk = yes ? RiskLevel.High : RiskLevel.None;
	}

	public void SetRiskLevel(RiskLevel level)
	{
		risk = level;
	}

	public double Income()
	{
		float rate;
		switch(risk)
		{
			case RiskLevel.None:
				rate = 6;
				break;
			case RiskLevel.Low:
				rate = 6.5f;
				break;
			case RiskLevel.Medium:
				rate = 7.5f;
				break;
			default:
				rate = 9;
				break;
		}
		double amount = invest * Math.Pow(1 + rate / 100, period);
		return amount - invest;
	}
}

static class Program
{
	public static void Main(string[] args)
	{
		try
		{
			double p = double.Parse(args[0]);
			int n = int.Parse(args[1]);
			Investment inv = new Investment(p, n);
			Console.WriteLine("Income in Bronze scheme will be {0:0.00}", inv.Income());
			inv.AllowRisk(true);
			Console.WriteLine("Income in Gold scheme will be {0:0.00}", inv.Income());
			inv.SetRiskLevel(RiskLevel.Medium);
			Console.WriteLine("Income in Silver scheme will be {0:0.00}", inv.Income());
		}
		catch(IndexOutOfRangeException)
		{
			Console.WriteLine("ERROR: Missing input");
		}
		catch(FormatException)
		{
			Console.WriteLine("ERROR: Invalid input");
		}
		catch(Exception ex)
		{
			Console.WriteLine("ERROR: {0}", ex.Message);
		}

	}
}
