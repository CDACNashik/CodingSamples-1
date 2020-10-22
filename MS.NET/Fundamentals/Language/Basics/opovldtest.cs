using System;

partial class Interval
{
	public void Print()
	{
		Console.WriteLine("{0}:{1:00}", min, sec);
	}

	public static Interval operator+(Interval lhs, Interval rhs)
	{
		return new Interval(lhs.min + rhs.min, lhs.sec + rhs.sec);
	}

	public static Interval operator*(int lhs, Interval rhs)
	{
		return new Interval(lhs * rhs.min, lhs * rhs.sec);
	}
}

static class Program
{
	public static void Main()
	{
		Interval a = new Interval(2, 80);
		a.Print();
		Interval b = new Interval();
		b.Time = 285;
		b.Print();
		Interval c = a + b;
		c.Print();
		Interval d = 3 * c;
		d.Print();
	}
}
