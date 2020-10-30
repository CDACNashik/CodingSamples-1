using System;
using System.Threading;
using System.Windows;
using System.Windows.Data;

class Clock : DependencyObject
{
	public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(string), typeof(Clock));

	public string Time
	{
		get => (string) GetValue(TimeProperty);
		set => SetValue(TimeProperty, value);
	}

	public Clock()
	{
		var child = new Thread(Run);
		child.IsBackground = true;
		child.Start();
	}

	private void Run()
	{
		for(;;)
		{
			Thread.Sleep(1000);

			//executed by child thread
			Dispatcher.Invoke(() => 
			{
				//executed by owner thread of this
				this.Time = DateTime.Now.ToString();
			});
		
		}
	}
}

class MainWindow : Window
{
	public MainWindow()
	{
		this.Title = "Hello World";
		//this.Content = DateTime.Now.ToString();

		var clockTime = new Binding
		{
			Source = new Clock(), 
			Path = new PropertyPath("Time")
		};

		SetBinding(ContentProperty, clockTime); 
	}
}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Application app = new Application();
		app.Run(new MainWindow());
	}
}
