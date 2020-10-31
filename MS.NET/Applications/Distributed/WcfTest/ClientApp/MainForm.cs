using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Shopping;

namespace ClientApp
{
    public partial class MainForm : Form
    {
        static readonly NetHttpBinding binding = new NetHttpBinding();
        static readonly string address = "http://localhost:8056/shopping/shopkeeper";

        public MainForm()
        {
            InitializeComponent();
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            string item = itemTextBox.Text.ToLower();
            int quantity = int.Parse(quantityTextBox.Text);

            using(var service = new ChannelFactory<IShopKeeper>(binding, address))
            {
                IShopKeeper client = service.CreateChannel();
                ItemInfo info = client.GetItemInfo(item);
                if (info != null && quantity <= info.CurrentStock)
                {
                    float discount = client.GetBulkDiscount(quantity);
                    double payment = quantity * info.UnitPrice * (1 - discount / 100);
                    paymentTextBox.Text = payment.ToString("0.00");
                }
                else
                    paymentTextBox.Text = "Not Available";                       
            }
        }
    }
}
