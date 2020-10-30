using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
	private Button timeButton;
	private Button greetButton;

	public MainForm()
	{
		this.Text = "Hello World";

		timeButton = new Button();
		timeButton.Text = "Time";
		timeButton.Location = new Point(20, 20);
		timeButton.Size = new Size(60, 25);
		timeButton.Click += Button_Click;
		this.Controls.Add(timeButton);

		greetButton = new Button();
		greetButton.Text = "Greet";
		greetButton.Location = new Point(90, 20);
		greetButton.Size = new Size(60, 25);
		greetButton.Click += Button_Click;
		this.Controls.Add(greetButton);
	}

	protected override void OnClosed(EventArgs e)
	{
		MessageBox.Show("Exiting this application!", "Goodbye World");
	}

	private void Button_Click(object sender, EventArgs e)
	{
		this.Text = (sender == timeButton) ? DateTime.Now.ToString() : "Hello World";
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
