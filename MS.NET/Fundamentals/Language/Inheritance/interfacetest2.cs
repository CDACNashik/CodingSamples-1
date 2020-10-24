using System;

#if NETCORE
interface IConsumer : IDisposable
{
	void Apply(int action); 

	void ApplyAll(int first, int last)
	{
		for(int action = first; action <= last; ++action)
			Apply(action);
	}
}
#else
interface IConsumer : IDisposable
{
	void Apply(int action); 
}

static class Consumer
{
	//extension method - it is a method of a static class which can be used
	//as an instance method of its first this qualified parameter type
	public static void ApplyAll(this IConsumer that, int first, int last)
	{
		for(int action = first; action <= last; ++action)
			that.Apply(action);
	}
}
#endif
interface IActor
{
	void Apply(int action);
}

class Resource : IConsumer, IActor
{
	private string id;

	public Resource(string name)
	{
		id = name;
		Console.WriteLine($"{id} resource acquired");
	}

	//explicit interface implementation
	void IConsumer.Apply(int action)
	{
		if(id != null)
			Console.WriteLine($"{id} resource consumed using action<{action}>");
	}

	void IActor.Apply(int action) {}

	void IDisposable.Dispose()
	{
		if(id != null)
			Console.WriteLine($"{id} resource released");
		id = null;
	}
}

static class Program
{
	private static void Run(string cmd)
	{
		using(IConsumer b = new Resource("Second"))
		{
			b.ApplyAll(1, int.Parse(cmd)); //Consumer.ApplyAll(b, 1, int.Parse(cmd));
		}
	}

	public static void Main(string[] args)
	{
		IConsumer a = new Resource("First");
		a.Apply(1);
		//IActor aa = (IActor)a;
		//aa.Apply();
		a.Dispose();
		
		try
		{
			Run(args[0]);
		}
		catch {}
	}
}
