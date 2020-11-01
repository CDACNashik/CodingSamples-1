using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Shopping;

namespace ServerApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CartService : ICart
    {
        private double payment;

        public bool AddItem(string name)
        {
            string[] items = { "cpu", "hdd", "keyboard", "motherboard", "mouse", "ram" };
            double[] prices = { 18000, 4500, 850, 6200, 450, 2400 };
            int id = Array.IndexOf(items, name);

            if(id >= 0)
            {
                payment += prices[id];
                return true;
            }

            return false;
        }

        public double Checkout()
        {
            return payment;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(CartService));

            host.Open();
            Console.ReadKey();
            host.Close();
        }
    }
}
