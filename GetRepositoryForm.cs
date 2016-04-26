using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using FacadeEjer.View;
using FacadeEjer.ViewModel;

namespace FacadeEjer.View
{
    class GetRepositoryForm
    {
        GetRepoViewModel grvm;
        
        internal GetRepositoryForm(IRepository customerRepo)
        {
            grvm = new GetRepoViewModel(customerRepo);
        }

        internal void Init()
        {
            try
            {
                Console.Clear();

                UtilsForms.YeimiBanner();

                GetRepository();

                Console.ReadKey();
                MainMenuForm p = new MainMenuForm();

                p.Main();
            }
            catch (Exception ex)
            { throw ex; }
        }


        internal void GetRepository()
        {
            Console.WriteLine("\n*Resgistered customers*");
            List<IComparable> lCustomer = grvm.GetCustomersReport();
            PrintCustomers(lCustomer);
            Console.WriteLine("\n*End of report*");
        }

        private void PrintCustomers(List<IComparable> lCustomers)
        {
            foreach (Customer c in lCustomers)
            {
                Console.WriteLine("\n- {0}, with patrimony: {1}$", c.Name, c.Patrimony);
            }
        }
    }
}
