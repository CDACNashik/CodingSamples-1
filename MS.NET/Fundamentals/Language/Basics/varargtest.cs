using System;

static class Program
{
	private static double Average(double first, double second, params double[] remaining)
	{
		double total = first + second;
		foreach(double value in remaining)
			total += value;
		return total / (remaining.Length + 2);
	}

	private static (double, double) AverageWithDeviation(double first, double second)
	{
		double average = (first + second) / 2;
		double deviation = first > second ? (first - second) / 2 : (second - first) / 2;
		
		return (average, deviation);
	}

	public static void Main(string[] args)
	{
		Console.WriteLine("Average of two values = {0}", Average(24.9, 27.6));
		Console.WriteLine("Average of three values = {0}", Average(24.9, 27.6, 19.8));
		Console.WriteLine("Average of five values = {0}", Average(24.9, 27.6, 19.8, 32.4, 17.7));
		if(args.Length > 1)
		{
			double x = double.Parse(args[0]);
			double y = double.Parse(args[1]);
			(double a, double d) = AverageWithDeviation(x, y);
			Console.WriteLine($"Average of input values is {a} with deviation of {d}");
		}
	}
}
