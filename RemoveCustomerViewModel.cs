using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;

namespace FacadeEjer.ViewModel
{
    internal class RemoveCustomerViewModel : ProgramViewModel
    {
        internal RemoveCustomerViewModel(IRepository custRepo)
            : base(custRepo)
        { }

        internal void RemoveCustomer(string customerName)
        {
            CustomerRepo.RemoveElement(customerName);
        }
    }
}
