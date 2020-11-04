using Sales;
using System.ServiceModel;

namespace PresentationTier
{
    class OrderManagerClient
    {
        public int ProcessOrder(string customerId, int productNo, int quantity)
        {
            using(var service = new ChannelFactory<IOrderManager>("OrderManagerTcpEndpoint"))
            {
                var client = service.CreateChannel();
                return client.PlaceOrder(customerId, productNo, quantity);
            }
        }
    }
}
