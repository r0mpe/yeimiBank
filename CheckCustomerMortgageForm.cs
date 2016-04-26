using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using FacadeEjer.ViewModel;

namespace FacadeEjer.View
{
    class CheckCustomerMortgageForm
    {
        IRepository repository;
        CheckCustomerMortgageViewModel cmvm;

        internal CheckCustomerMortgageForm(IRepository repo)
        {
            this.repository = repo;
            cmvm = new CheckCustomerMortgageViewModel(repo);     
        }

        public void Init()
        {
            Console.Clear();

            UtilsForms.YeimiBanner();

            string customerName = UtilsForms.CustomerNameRequest();

            Console.Clear();
            bool confirm = UtilsForms.ConfirmMessage();

            if (confirm)
                CheckMortgage(customerName);

            MainMenuForm p = new MainMenuForm();
            p.Main();
        }

        private void CheckMortgage(string customerName)
        {
            bool status = cmvm.CheckMortgage(customerName);

            if (status == true)
                Console.WriteLine("\nCustomer {0} can take the mortgage =)", customerName);
            else
                Console.WriteLine("\nCustomer {0} can`t take the mortgage =(", customerName);

            UtilsForms.SucceedMessage();
        }
    }
}
