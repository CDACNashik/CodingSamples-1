using System;
using System.Runtime.InteropServices;

static class Program
{
	//calling convention must be specified for 32-bit DLLs not distributed with Windows platform 
	[DllImport(@"legacy\bin\asset32.dll", EntryPoint="depreciation", CallingConvention=CallingConvention.Cdecl)]
	private extern static float GetDepreciation(short life, short after, string method);

	public static void Main(string[] args)
	{
		double cost = double.Parse(args[0]);
		short life = short.Parse(args[1]);
		string method = args.Length > 2 ? args[2] : null;

		for(short y = 1; y < life; ++y)
		{
			float dep = GetDepreciation(life, y, method);
			Console.WriteLine("{0}\t{1:0.00}", y, cost * dep);
		}
	}
}
