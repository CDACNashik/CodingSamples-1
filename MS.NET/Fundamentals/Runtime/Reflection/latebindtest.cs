using System;

static class Program
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		Type t = Type.GetType($"Finance.{args[1]},bank");
		var loan = Activator.CreateInstance(t);
		var mi = t.GetMethod(args[2], new Type[]{typeof(int)});
		int m = 10;

		for(int n = 1; n <= m; ++n)
		{
			float r = (float)mi.Invoke(loan, new object[]{n});
			float i = r / 1200;
			double emi = p * i / (1 - Math.Pow(1 + i, -12 * n));
			Console.WriteLine("{0, -6}{1, 12:0.00}", n, emi);
		}
	}
}
