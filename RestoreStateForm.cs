using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using FacadeEjer.ViewModel;

namespace FacadeEjer.View
{
    internal class RestoreStateForm
    {
        //Attributes
        RestoreStateViewModel rsvm;

        //Constructor
        internal RestoreStateForm(IRepository customersRepo)
        {
            rsvm = new RestoreStateViewModel(customersRepo);
            Init();
        }

        internal void Init()
        {
            UtilsForms.YeimiBanner();

            bool success = UtilsForms.ConfirmMessage();

            if (success)
            {
                rsvm.RestoreState();
                UtilsForms.SucceedMessage();
            }

            MainMenuForm main = new MainMenuForm();
            main.Main();
        }
    }
}
