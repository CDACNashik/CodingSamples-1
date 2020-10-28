using System;
using System.Threading;

static class Program
{
	private volatile static int data;
	private static object coordinator = new object();

	private static void Produce()
	{
		Console.WriteLine("Producer<{0}> ready...", Thread.CurrentThread.ManagedThreadId);
		lock(coordinator)
		{
			data = Worker.DoWork();
			Monitor.Pulse(coordinator);	
		}
	}

	private static void Consume()
	{
		Console.WriteLine("Consumer<{0}> ready...", Thread.CurrentThread.ManagedThreadId);
		//while(data == 0) Thread.Yield();
		lock(coordinator)
		{
			Monitor.Wait(coordinator);
			Console.WriteLine("Processed value = {0}", data * data);
		}
	}

	public static void Main()
	{
		var consumer = new Thread(Consume);
		consumer.Start();

		var producer = new Thread(Produce);
		producer.Start();
	}
}
