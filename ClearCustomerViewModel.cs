using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;

namespace FacadeEjer.ViewModel
{
    class ClearCustomerViewModel : ProgramViewModel
    {
        internal ClearCustomerViewModel(IRepository custRepo)
            : base(custRepo)
        { }

        internal void ClearRepository()
        {
            CustomerRepo.ResetRepository();
        }
    }
}
