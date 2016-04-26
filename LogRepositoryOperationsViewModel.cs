using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;
using FacadeEjer.Data.Models.Log;

namespace FacadeEjer.ViewModel
{
    class LogRepositoryOperationsViewModel : ProgramViewModel
    {
        LogCustomersRepository logCustomersRepository;

        public LogRepositoryOperationsViewModel(CustomersRepository customersRepo, LogCustomersRepository logCustomers)
            : base(customersRepo)
        {
            logCustomersRepository = logCustomers;
        }

        //Methods
        public List<string> GetLog()
        {
            try
            {
                List<string> log = logCustomersRepository.LOperations;
                return log;
            }
            catch (Exception ex)
            { throw new Exception("Error getting log information."); }
        }
    }
}
