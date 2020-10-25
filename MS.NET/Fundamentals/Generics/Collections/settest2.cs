using System;
using System.Collections.Generic;

static class Program
{
	public static void Main()
	{
		//ISet<Interval> store = new SortedSet<Interval>();
		ISet<Interval> store = new SortedSet<Interval>(Comparer<Interval>.Create((x, y) => x.Seconds - y.Seconds));
		store.Add(new Interval(5, 31));
		store.Add(new Interval(3, 42));
		store.Add(new Interval(7, 23));
		store.Add(new Interval(6, 14));
		store.Add(new Interval(4, 55));
		store.Add(new Interval(5, 74));

		foreach(var i in store)
			Console.WriteLine(i);
	}
}
