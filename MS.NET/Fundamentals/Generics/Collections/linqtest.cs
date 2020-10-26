using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
	public static void Main(string[] args)
	{
		int limit = args.Length > 0 ? int.Parse(args[0]) : 0;
		double distance = args.Length > 1 ? double.Parse(args[1]) : 500.0;

		var sequence = new List<Interval>
		{
			new Interval(4, 31),
			new Interval(8, 42),
			new Interval(5, 53),
			new Interval(6, 14),
			new Interval(3, 25),
			new Interval(7, 36)
		};

		/*
		var selection = sequence.Where(i => i.Time > limit)
				.OrderBy(i => i.Seconds)
				.Select(i => new
				{
					Duration = i,
					Speed = 3.6 * distance / i.Time
				});
		*/
		var selection = from i in sequence
				where i.Time > limit
				orderby i.Seconds
				select new 
				{
					Duration = i,
					Speed = 3.6 * distance / i.Time
				};
		foreach(var entry in selection)
			Console.WriteLine("{0}\t{1:0.0}", entry.Duration, entry.Speed);
					
	}
}
