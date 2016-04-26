using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using FacadeEjer.ViewModel;

namespace FacadeEjer.View
{
    internal class SaveChangesForm
    {
        IRepository customersRepo;
        SaveChangesViewModel scvm;

        internal SaveChangesForm(IRepository customersRepo)
        {
            this.customersRepo = customersRepo;
            scvm = new SaveChangesViewModel(customersRepo);
        }

        internal void Init()
        {
            Console.Clear();
            UtilsForms.YeimiBanner();

            bool save = UtilsForms.ConfirmMessage();

            if (save)
                scvm.SaveCustomers();

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Main();
        }

    }
}
