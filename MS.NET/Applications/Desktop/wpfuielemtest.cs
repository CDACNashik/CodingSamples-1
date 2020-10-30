using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

class Circle : UIElement
{

	protected override void OnRender(DrawingContext dc)
	{
		var da = new DoubleAnimation(100, 10, TimeSpan.FromSeconds(5));
		da.AutoReverse = true;
		//da.RepeatBehavior = RepeatBehavior.Forever;// new RepeatBehavior(3);

		var anim = da.CreateClock();

		dc.DrawEllipse(Brushes.Blue, new Pen(Brushes.Red, 10), new Point(200, 200), null, 100, anim, 100, anim);
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		InvalidateVisual();
	}

}

class MainWindow : Window
{
	public MainWindow()
	{
		this.Title = "Hello World";
		this.Content = new Circle();

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
