using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;

namespace FacadeEjer.ViewModel
{
    internal class CheckCustomerMortgageViewModel : ProgramViewModel
    {
        internal CheckCustomerMortgageViewModel(IRepository custRepo)
            : base(custRepo)
        { }


        internal bool CheckMortgage(string customerName)
        {
            IComparable c = GetCustomer(customerName);
            return CheckCustomerMortgage( ((Customer)c).Name, ((Customer)c).Patrimony );
        }

        private bool CheckCustomerMortgage(string name, float patrimony)
        {
            float bankSavings = 550;
            Bank b1 = new Bank(bankSavings);

            Loan l1 = new Loan();

            Credit c1 = new Credit();

            Mortgage m1 = new Mortgage(b1, c1, l1);

            IComparable c = GetCustomer(name);

            bool status = m1.IsPossibleGetAMortgage((Customer)c);

            return status;
        }

        private IComparable GetCustomer(string name)
        {
            IComparable c = CustomerRepo.GetCustomer(name);
            return c;
        }
    }
}
