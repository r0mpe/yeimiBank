using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeEjer.Data.Models.Log
{
    //Es un observer de la clase Customer
    public class LogCustomersRepository :IObserver
    {
        //Singleton pattern
        static LogCustomersRepository instance;

        public static LogCustomersRepository GetInstance()
        {
            if (instance == null)
                instance = new LogCustomersRepository();
            return instance;
        }

        //Attributes
        private CustomersRepository customersRepository;
        List<string> lOperations;

        //Properties
        public CustomersRepository CustomersRepository
        {
            get { return customersRepository; }
            set { customersRepository = value; }
        }

        public List<string> LOperations
        {
            get { return lOperations; }
            set { lOperations = value; }
        }

        //Constructor
        public LogCustomersRepository()
        {
            lOperations = new List<string>();
        }

        public void Update()
        {
            lOperations.Add(CustomersRepository.LastOperation);
        }
    }
}
