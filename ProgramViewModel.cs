using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;

namespace FacadeEjer.ViewModel
{
    internal class ProgramViewModel
    {
        //Attributes
        CustomersRepository customerRepo;

        internal CustomersRepository CustomerRepo
        {
            get { return customerRepo; }
            set { customerRepo = value; }
        } 

        internal ProgramViewModel(IRepository CustomerRepo)
        {
            this.CustomerRepo = (CustomersRepository)CustomerRepo;
        }
    }
}
