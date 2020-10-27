using System;

static class Program
{
	public static void Main(string[] args)
	{
		double a = 1;
		double b = -0.5 * double.Parse(args[0]);
		double c = double.Parse(args[1]);
		
		//when new operator is applied to a COM imported class,
		//it activates the COM object and returns its RCW
		var qe = new QuadEq.QuadraticEquationClass();

		if(qe.HasRealRoots(a, b, c) != 0)
		{
			double d1, d2;
			qe.Solve(a, b, c, out d1, out d2);
			Console.WriteLine($"Dimensions = {d1}, {d2}");
		}
		else
			Console.WriteLine("No such rectangle!");
	}
}
