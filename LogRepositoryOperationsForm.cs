using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using FacadeEjer.ViewModel;
using FacadeEjer.Data.Models.Log;

namespace FacadeEjer.View
{
    class LogRepositoryOperationsForm
    {
        CustomersRepository customersRepo;
        LogRepositoryOperationsViewModel lrovm;

        public LogRepositoryOperationsForm(IRepository customersRepo, LogCustomersRepository logCustomers)
        {
            this.customersRepo = (CustomersRepository)customersRepo;
            lrovm = new LogRepositoryOperationsViewModel(this.customersRepo, logCustomers);
        }

        public void Init()
        {
            Console.Clear();
            UtilsForms.YeimiBanner();

            List<string> log = lrovm.GetLog();

            PrintLog(log);

            Console.ReadKey();

            MainMenuForm Main = new MainMenuForm();
            Main.Main();
        }

        private void PrintLog(List<string> log)
        {
            Console.WriteLine(" --- Operations Performed ---");
            for (int i = 0; i < log.Count; i++)
            {
                Console.WriteLine("Operation {0} " + log[i].ToString(), i);
            }
        }
    }
}
