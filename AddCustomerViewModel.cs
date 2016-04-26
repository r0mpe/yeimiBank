using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;

namespace FacadeEjer.ViewModel
{
    internal class AddCustomerViewModel : ProgramViewModel
    {
        //Constructor
        internal AddCustomerViewModel(IRepository custRepo):base(custRepo)
        {}

        internal void CreateCustomer(string customerName, string patrimony)
        {
            try
            {
                Customer cust = new Customer(customerName, float.Parse(patrimony));
                CustomerRepo.AddElement(cust);
            }
            catch (Exception ex)
            { throw new Exception("Create customer error " + ex.Message); }
        }
    }
}
