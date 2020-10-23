partial class Interval
{
	private int min, sec;

	public Interval(int m, int s)
	{
		min = m + s / 60;
		sec = s % 60;
	}

	public int Minutes => min;

	public int Seconds => sec;

	public int Time => 60 * min + sec;

	public override string ToString() => $"{min}:{sec:00}";
}
