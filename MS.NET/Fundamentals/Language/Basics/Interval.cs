partial class Interval
{
	private int min, sec;

	public Interval(int m, int s)
	{
		min = m + s / 60;
		sec = s % 60;
	}

	public Interval() : this(0, 0) {}

	//property - get/set methods called implicitly with field-access syntax
	public int Time
	{
		get
		{
			return 60 * min + sec;
		}

		set
		{
			min = value / 60;
			sec = value % 60;
		}
	}

	//read-only property
	public int Minutes
	{
		get { return min; }
	}

	public int Seconds => sec;
}
