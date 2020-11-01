using System.Threading.Tasks;
using System.ServiceModel;
using Shopping;

namespace ClientApp
{
    public class CartClient : ClientBase<ICart>
    {
        public CartClient() : base("CartTcpEndpoint")
        {
        }

        public Task<bool> AddItemAsync(string name)
        {
            return Task<bool>.Run(() => Channel.AddItem(name));
        }

        public Task<double> CheckoutAsync()
        {
            return Task<double>.Run(() => Channel.Checkout());
        }
    }
}
