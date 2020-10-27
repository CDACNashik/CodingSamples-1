using System;
using System.Runtime.InteropServices;

static class Program
{
	[StructLayout(LayoutKind.Sequential)]
	struct FixedDeposit
	{
		public int Id;

		public double Amount;

		public int Period;
	}	


	[DllImport(@"legacy\bin\invest.dll")]
	private extern static bool InitFixedDeposit(double amount, int period, out FixedDeposit fd);

	//[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	delegate float Scheme(int period);

	[DllImport(@"legacy\bin\invest.dll")]
	private extern static double GetMaturityValue(in FixedDeposit fd, Scheme policy);


	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		int n = int.Parse(args[1]);

		if(InitFixedDeposit(p, n, out FixedDeposit fd))
		{
			Console.WriteLine("New fixed-deposit ID: {0}", fd.Id);
			double mv = GetMaturityValue(fd, y => y < 3 ? 5 : 6);
			Console.WriteLine("Maturity value: {0:0.00}", mv);
		}
	}
}
