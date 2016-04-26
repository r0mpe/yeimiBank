using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.ViewModel;
using FacadeEjer.Data.Models;

namespace FacadeEjer.View
{
    class ClearCustomerForm
    {
        ClearCustomerViewModel ccvm;

        public ClearCustomerForm(IRepository repo)
        {
            ccvm = new ClearCustomerViewModel(repo); 
        }

        public void Init()
        {
            Console.Clear();

            UtilsForms.YeimiBanner();

            bool proceed = UtilsForms.ConfirmMessage();

            if (proceed = true)
                ccvm.ClearRepository();

            UtilsForms.SucceedMessage();

            MainMenuForm p = new MainMenuForm();
            p.Main();
        }

    }
}
