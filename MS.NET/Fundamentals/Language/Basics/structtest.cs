using System;

struct Box
{
	public int Length, Breadth, Height;

	public Box(int l, int b, int h)
	{
		Length = l;
		Breadth = b;
		Height = h;
	}

	public long GetArea()
	{
		return 2 * (Length * Breadth + Breadth * Height + Height * Length);
	}

	public long GetVolume() => Length * Breadth * Height;
}


static class Program
{
	private static void ExpandBox(ref Box box, int percent)
	{
		box.Length += box.Length * percent / 100;
		box.Breadth += box.Breadth * percent / 100;
		box.Height += box.Height * percent / 100;
	}

	//out = must initialize ref
	private static bool CubicalBox(int size, out Box box)
	{
		box = new Box();
		if(size < 100)
		{
			box.Length = box.Breadth = box.Height = size;
			return true;
		}
		return false;
	}

	public static void Main(string[] args)
	{
		Box a;
		a.Length = 10;
		a.Breadth = 15;
		a.Height = 20;
		Console.WriteLine("Area of first box is {0} and its volume is {1}", a.GetArea(), a.GetVolume());

		Box b = new Box(20, 30, 40);
		Console.WriteLine($"Area of second box is {b.GetArea()} and its volume is {b.GetVolume()}");

		Console.WriteLine("Expanding second box...");
		ExpandBox(ref b, 10);
		Console.WriteLine($"Area of second box is {b.GetArea()} and its volume is {b.GetVolume()}");

		if(args.Length > 0)
		{
			int l = int.Parse(args[0]);
			if(CubicalBox(l, out Box c))
				Console.WriteLine($"Area of third box is {c.GetArea()} and its volume is {c.GetVolume()}");
			else
				Console.WriteLine("Cannot create a third box!");	
		}

	}
}
