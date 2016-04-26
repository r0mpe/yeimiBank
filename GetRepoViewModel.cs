using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;

namespace FacadeEjer.ViewModel
{
    class GetRepoViewModel : ProgramViewModel
    {
        internal GetRepoViewModel(IRepository custRepo)
            : base(custRepo)
        { }

        internal List<IComparable> GetCustomersReport()
        {
            List<IComparable> lCustomers = (List<IComparable>)CustomerRepo.GetElements();

            return lCustomers;
        }

        
    }
}
