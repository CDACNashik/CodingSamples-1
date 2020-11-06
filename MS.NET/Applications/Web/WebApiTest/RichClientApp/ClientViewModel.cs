using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RichClientApp
{
    class ClientViewModel : MvvmSupport.BindableObjectBase
    {
        ClientModel model = new ClientModel();

        public IEnumerable<ProductInfo> Products => model.GetProducts();

        public ProductInfo CurrentProduct
        {
            get => _CurrentProduct;
            set => SetProperty(ref _CurrentProduct, value);
        }
        private ProductInfo _CurrentProduct;

        public string Message
        {
            get => _Message;
            set => SetProperty(ref _Message, value);
        }
        private string _Message;

        public ICommand Save => DispatchCommand();
        private bool Save_CanExecute(object parameter) => _CurrentProduct != null;
        private void Save_Execute(object parameter)
        {
            try
            {
                model.PutProduct(_CurrentProduct);
                Message = "Product updated successfully";
            }
            catch
            {
                Message = "Product update failed";
            }
        }



    }
}
