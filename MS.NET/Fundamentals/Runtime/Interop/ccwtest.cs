using FinanceLib;
using System;
using System.Runtime.InteropServices;

[ComImport]
[Guid("1A87402F-A9F3-449F-ACB3-714A9275BEE0")]
class MyLoanClass {}

class CarLoanScheme : ILoanScheme
{
	public float GetInterestRate(short n)
	{
		return 10 + 0.5f * (n / 3);
	}
}

static class Program
{
	[STAThread]
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		short n = short.Parse(args[1]);

		ILoan loan = (ILoan) new MyLoanClass();
	
		try
		{
			loan.Acquire(p, n);
			Console.WriteLine("E.M.I for home-loan: {0:0.00}", loan.GetInstallmentUsingRate(8));	
			Console.WriteLine("E.M.I for car-loan : {0:0.00}", loan.GetInstallmentForScheme(new CarLoanScheme())); //CCW of CarLoanScheme will be passed	

		}
		catch(COMException ex)
		{
			Console.WriteLine("Loan denied: {0}", (LoanError)ex.HResult);
		}	
	}
}
