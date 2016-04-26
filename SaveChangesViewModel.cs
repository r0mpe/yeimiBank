using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using FacadeEjer.Data.Writers;

namespace FacadeEjer.ViewModel
{
    internal class SaveChangesViewModel : ProgramViewModel
    {
        internal SaveChangesViewModel(IRepository repo)
            : base(repo)
        { }


        internal void SaveCustomers()
        {
            try
            {
                WriteCustomerRepositorytXmlFile wcr = new WriteCustomerRepositorytXmlFile();
                wcr.SetCustomers(CustomerRepo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving datas." + ex.Message);
            }
        }

    }
}
