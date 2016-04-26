using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using FacadeEjer.ViewModel;

namespace FacadeEjer.View
{
    class RemoveCustomerForm
    {
        RemoveCustomerViewModel rcvm;

        internal RemoveCustomerForm(IRepository repo)
        {
            rcvm = new RemoveCustomerViewModel(repo);
        }

        public void Init()
        {
            Console.Clear();

            UtilsForms.YeimiBanner();

            string customerName = UtilsForms.CustomerNameRequest();

            Console.Clear();
            bool confirm = UtilsForms.ConfirmMessage();

            if (confirm)
                RemoveCustomer(customerName);

            MainMenuForm p = new MainMenuForm();
            p.Main();
        }

        private void RemoveCustomer(string customerName)
        {
            rcvm.RemoveCustomer(customerName);

            UtilsForms.SucceedMessage();
        }

        

    }
}
