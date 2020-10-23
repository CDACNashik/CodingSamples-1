namespace Payroll
{
	//public type is visible outside of its assembly
	public class Employee
	{
		private int id;
		internal int hours;
		protected float rate;
		static int count;

		public Employee(int h, float r)
		{
			id = 101 + count++;
			hours = h;
			rate = r;
		}

		public Employee() : this(0, 0) {}

		public int Id => id;

		public int Hours
		{
			get => hours;
			set => hours = value;
		}

		public float Rate
		{
			get => rate;
			set => rate = value;
		}

		public virtual double GetIncome() //overridable methods
		{
			int ot = hours > 40 ? hours - 40 : 0;
			return rate * (hours + ot);	
			
		}

		public static int CountActive()
		{
			return count;
		}
	}

	public class SalesPerson : Employee
	{
		//automatic property
		public double Sales {get; set;}

		public SalesPerson(int h, float r, double s) : base(h, r)
		{
			Sales = s;
		}

		//public new double GetIncome() //hiding method of base class
		public override double GetIncome() //overriding method of base class
		{
			double amount = base.GetIncome();
			if(Sales >= 5000)
				amount += 0.05 * Sales;
			return amount;
		}
	}
}
