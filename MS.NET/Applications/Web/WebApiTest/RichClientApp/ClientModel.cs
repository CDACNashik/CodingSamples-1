using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RichClientApp
{
    [DataContract]
    class ProductInfo
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "stock")]
        public int Stock { get; set; }
    }

    [ServiceContract]
    interface IProductClient
    {
        [OperationContract]
        [WebGet(UriTemplate = "/api/products/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<ProductInfo> GetProducts();

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/api/products/", RequestFormat = WebMessageFormat.Json)]
        void PutProduct(ProductInfo input);
    }

    class ClientModel
    {
        Uri serviceUri = new Uri(Properties.Settings.Default.ServiceAddress);

        public IEnumerable<ProductInfo> GetProducts()
        {
            using(var service = new WebChannelFactory<IProductClient>(serviceUri))
            {
                var client = service.CreateChannel();
                return client.GetProducts();
            }
        }

        public void PutProduct(ProductInfo input)
        {
            using (var service = new WebChannelFactory<IProductClient>(serviceUri))
            {
                var client = service.CreateChannel();
                client.PutProduct(input);
            }
        }
    }
}
