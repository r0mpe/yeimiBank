using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.ViewModel;
using FacadeEjer.Data.Models;
using FacadeEjer.Data.Writers;
using FacadeEjer.Data.Models.Sort;
using FacadeEjer.Data.Models.Log;

namespace FacadeEjer.View
{
    public class MainMenuForm
    {
        CustomersRepository custRepo;
        LogCustomersRepository logCustomers;

        public MainMenuForm()
        {
            custRepo = CustomersRepository.GetInstance();
            logCustomers = LogCustomersRepository.GetInstance();
            logCustomers.CustomersRepository = custRepo;

            //ojo! registro el observador
            //el sujeto conoce cuales son sus observadores para notificarles sus cambios,
            //pero los observadores no tienen concocimiento del sujeto, solamente dejan un método que recibe notificaciones
            custRepo.Detach(logCustomers);
            custRepo.Attach(logCustomers);

            Console.Clear();
        }

        public void Main()
        {

            UtilsForms.PrintApplicationMainMenu();
            string option = UtilsForms.GetOption();

            LoadOption(option);

            Console.WriteLine("\nSee you!");
            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();

        }

        private void LoadOption(string option)
        {
            try
            {
                switch (option)
                {
                    case "1":
                        AddCustomerForm addCustFrom = new AddCustomerForm(custRepo);
                        addCustFrom.Init();
                        break;
                    case "2":
                        RemoveCustomerForm removeCustomerFrom = new RemoveCustomerForm(custRepo);
                        removeCustomerFrom.Init();
                        break;
                    case "3":
                        ClearCustomerForm clearCustomerFrom = new ClearCustomerForm(custRepo);
                        clearCustomerFrom.Init();
                        break;
                    case "4":
                        CheckCustomerMortgageForm checkCustomerMortgage = new CheckCustomerMortgageForm(custRepo);
                        checkCustomerMortgage.Init();
                        break;
                    case "5":
                        GetRepositoryForm getCustomerRepository = new GetRepositoryForm(custRepo);
                        getCustomerRepository.Init();
                        break;
                    case "6":
                        SaveChangesForm saveChanges = new SaveChangesForm(custRepo);
                        saveChanges.Init();
                        break;
                    case "7":
                        LogRepositoryOperationsForm logRepository = new LogRepositoryOperationsForm(custRepo, logCustomers);
                        logRepository.Init();
                        break;

                    case "8":
                        RestoreStateForm restoreStateForm = new RestoreStateForm(custRepo);
                        restoreStateForm.Init();
                        break;

                    case "9":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. (Mother fucker)");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Is not possible do this operation. \nDetails: " + ex.Message);
            }
        }
  
    }
}
