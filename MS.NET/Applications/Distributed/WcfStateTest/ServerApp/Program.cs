using System;
using System.ServiceModel;
using Shopping;

namespace ServerApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ShopKeeperService : IShopKeeper
    {
        public float GetBulkDiscount(int quantity)
        {
            return quantity < 3 ? 0 : 15;
        }

        public ItemInfo GetItemInfo(string name)
        {
            string[] items = { "cpu", "hdd", "keyboard", "motherboard", "mouse", "ram" };
            double[] prices = { 18000, 4500, 850, 6200, 450, 2400 };
            int[] stocks = { 25, 38, 150, 25, 120, 65 };

            int id = Array.IndexOf(items, name);
            if (id >= 0)
                return new ItemInfo { UnitPrice = prices[id], CurrentStock = stocks[id] };

            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(ShopKeeperService));
            host.AddServiceEndpoint(typeof(IShopKeeper), new NetHttpBinding(), "http://localhost:8056/shopping/shopkeeper");
 
            host.Open();
            Console.ReadKey();
            host.Close();
        }
    }
}
