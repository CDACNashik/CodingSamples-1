using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{

	private Rectangle frame = new Rectangle(65, 50, 250, 50);
	private Timer clock = new Timer();

	public MainForm()
	{
		this.Text = "Hello World";
		this.BackColor = Color.FromArgb(255, 255, 255);
		this.Size = new Size(400, 400);

		clock.Interval = 1000;
		clock.Tick += (sender, e) => Refresh();
		clock.Start();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		using(var br = new SolidBrush(Color.Blue))
			e.Graphics.FillRectangle(br, frame);

		using(var pn = new Pen(Color.Green, 5))
			e.Graphics.DrawRectangle(pn, frame);

		using(var ft = new Font("Arial", 16, FontStyle.Bold))
			e.Graphics.DrawString(DateTime.Now.ToString(), ft, Brushes.Yellow, frame.X + 5, frame.Y + 15);
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		if(frame.Contains(e.Location))
			clock.Enabled = !clock.Enabled;
	}

}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Application.Run(new MainForm());
	}
}
