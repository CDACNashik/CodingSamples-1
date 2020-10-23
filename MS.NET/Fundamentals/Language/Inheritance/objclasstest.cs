using System;

static class Program
{
	public static void Main()
	{
		Interval a = new Interval(5, 10);
		Interval b = new Interval(3, 5);
		Interval c = new Interval(4, 70);
		Interval d = b;

		Console.WriteLine("Interval a = {0}", a.ToString());
		Console.WriteLine("Interval b = {0}", b);
		Console.WriteLine("Interval c = {0}", c);
		Console.WriteLine("Interval d = {0}", d);

		Console.WriteLine("a is identical to b: {0}", ReferenceEquals(a, b));
		Console.WriteLine("a is identical to c: {0}", ReferenceEquals(a, c));
		Console.WriteLine("d is identical to b: {0}", ReferenceEquals(d, b));


	}
}
