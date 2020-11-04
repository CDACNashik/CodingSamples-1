﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientApp
{
    public class CustomerViewModel : MvvmSupport.BindableObjectBase
    {
        private ShopModel model = new ShopModel();

        public IEnumerable<Customer> Customers => model.Customers.ToList();

        private Customer _currentCustomer;
        public Customer CurrentCustomer
        {
            get => _currentCustomer;
            set => SetProperty(ref _currentCustomer, value);
        }

        private bool Update_CanExecute(object arg)
        {
            return model.ChangeTracker.HasChanges();
        }

        private void Update_Execute(object arg)
        {
            model.SaveChanges();
        }

        public ICommand Update => DispatchCommand();
    }
}
