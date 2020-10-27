using System;

static class Program
{

	private unsafe static void SquareAll(double[] values)
	{
		//An array is a reference type so its data is on the heap
		//and as such this data can be moved during garbage-collection.
		//To take a pointer to an element of an array, this array must 
		//be fixed so that its data is not moved by garbage collector.
		fixed(double* elements = &values[0])
		{
			for(int i = 0; i < values.Length; ++i)
				elements[i] *= elements[i];
		}
	}

	public static void Main(string[] args)
	{
		double[] list = {1.2, 2.3, 3.4, 4.5, 5.6};
		SquareAll(list);
		foreach(double v in list)
			Console.WriteLine("{0:0.00}", v);
	}
}
