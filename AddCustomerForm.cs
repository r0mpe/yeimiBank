using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using FacadeEjer.ViewModel;

namespace FacadeEjer.View
{
    class AddCustomerForm
    {
        AddCustomerViewModel acvm;

        public AddCustomerForm(IRepository custRepo)
        {
            acvm = new AddCustomerViewModel(custRepo);         
        }

        public void Init()
        {
            try
            {
                Console.Clear();

                string name, patrimony;
                LoadAddOptions(out name, out patrimony);

                Console.Clear();
                bool confirm = UtilsForms.ConfirmMessage();

                if (confirm)
                    AddCustomer(name, patrimony);

                MainMenuForm p = new MainMenuForm();
                p.Main();
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void AddCustomer(string name, string patrimony)
        {
            acvm.CreateCustomer(name, patrimony);

            UtilsForms.SucceedMessage();
        }

        public void LoadAddOptions(out string name, out string patrimony)
        {
            UtilsForms.YeimiBanner();

            Console.WriteLine("\nInsert customer name: ");
            name = Console.ReadLine();

            Console.WriteLine("\nInsert customer patrimony: ");
            patrimony = Console.ReadLine();
        }
    }
}
