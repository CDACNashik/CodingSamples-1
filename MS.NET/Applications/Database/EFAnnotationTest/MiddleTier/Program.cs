using Sales;
using System;
using System.ServiceModel;

namespace MiddleTier
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class OrderManagerService : IOrderManager
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public int PlaceOrder(string customerId, int productNo, int quantity)
        {
            using(var model = new ShopModel())
            {
                Counter ctr = model.Counters.Find("order");
                OrderEntry order = new OrderEntry 
                { 
                    Id = ++ctr.CurrentValue + 1000,
                    CustomerId = customerId,
                    ProductNo = productNo,
                    Quantity = quantity
                };

                model.Orders.Add(order);
                model.SaveChanges();

                return order.Id;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(OrderManagerService));

            host.Open();
            Console.ReadKey();
            host.Close();
        }
    }
}
