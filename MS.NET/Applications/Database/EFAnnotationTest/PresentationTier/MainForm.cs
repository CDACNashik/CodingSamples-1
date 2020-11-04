using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationTier
{
    public partial class MainForm : Form
    {
        OrderManagerClient client = new OrderManagerClient();

        public MainForm()
        {
            InitializeComponent();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            string customerId = customerIdTextBox.Text.ToUpper();
            int productNo = int.Parse(productNoTextBox.Text);
            int quantity = (int)quantityNumericUpDown.Value;

            try
            {
                int orderNo = client.ProcessOrder(customerId, productNo, quantity);
                MessageBox.Show($"New order number is {orderNo}", "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Order cannot be placed with given inputs", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
