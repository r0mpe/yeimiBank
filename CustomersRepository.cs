using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.View;
using FacadeEjer.Data.Readers;
using FacadeEjer.Data.Models.Sort;
using FacadeEjer.Data.Models.Log;
using FacadeEjer.Data.Models.Memento;

namespace FacadeEjer.Data.Models
{
    public class CustomersRepository :IRepository
    {
        private static CustomersRepository instance;

        //Singletone pattern
        static public CustomersRepository GetInstance()
        {           
            if (instance == null)
                instance = new CustomersRepository();
            return instance;
        }

        //Attributes
        const string CTE_ADD = "Add customer ";
        const string CTE_REMOVE_CUSTOMER = "Remove customer ";
        const string CTE_GET_ELEMENTS_CUSTOMERS = "Get Customers.";
        const string CTE_RESET_REPOSITORY = "Reset repository.";
        const string CTE_UNDO_OPERATION = "Undo operation";
        
        List<IComparable> lCustomer;

        private ISortStrategy sortStrategy;
        public ISortStrategy SortStrategy
        {
            get { return sortStrategy; }
            set { sortStrategy = value; }
        }

        string lastOperation;
        public string LastOperation
        {
            get { return lastOperation; }
            set { lastOperation = value; }
        }
        
        //Lista de posibles observadores
        List<IObserver> lObservers = new List<IObserver>();

        //Memento
        CareTakerMemento c;

        //Constructor
        internal CustomersRepository()
        {
            lCustomer = new List<IComparable>();
            ReadCustomerRepositoryXmlFile reader = new ReadCustomerRepositoryXmlFile();
            lCustomer = reader.GetCustomers();

            //Default SortStrategy
            SortStrategy = new ShellSort();//QuickSort();

            //Memento
            c = new CareTakerMemento();
        }

        //Methods
        public object GetElements()
        {
            LastOperation = CTE_GET_ELEMENTS_CUSTOMERS + " at " + DateTime.Now;
            Notify();
            return SortStrategy.Sort(lCustomer);
        }

        public void AddElement(object element)
        {
            c.Memento = SaveMemento();

            FillLastOperation(CTE_ADD + ((Customer)element).Name);

            lCustomer.Add((Customer)element);

            Notify();
        }

        public void ResetRepository()
        {
            c.Memento = SaveMemento();

            FillLastOperation(CTE_RESET_REPOSITORY);

            lCustomer.Clear();

            Notify();
        }

        public void RemoveElement(string elementName)
        {
            c.Memento = SaveMemento();

            FillLastOperation(CTE_REMOVE_CUSTOMER + elementName);

            var selectedElement = LinqElementsToRemove(elementName);

            RemoveCustomers(selectedElement);

            Notify();
        }

        private void RemoveCustomers(IEnumerable<IComparable> selectedElement)
        {
            try
            {
                List<IComparable> lCustomersAux = new List<IComparable>(lCustomer);

                foreach (var customer in selectedElement)
                {
                    lCustomersAux.Remove(customer);
                }

                lCustomer = lCustomersAux;
            }
            catch (Exception ex)
            { throw new Exception("Error in RemoveCustomers method."); }
        }

        private IEnumerable<IComparable> LinqElementsToRemove(string elementName)
        {
            var selectedElement = from c in lCustomer
                                  where ((Customer)c).Name.ToUpper() == elementName.ToUpper()
                                  select c;
            return selectedElement;
        }

        public IComparable GetCustomer(string name)
        {
            FillLastOperation(CTE_GET_ELEMENTS_CUSTOMERS);

            IEnumerable<IComparable> lCustomer = LinqElementsToRemove(name);

            Notify();

            return lCustomer.ElementAt(0);
        }

        private void FillLastOperation(string operationName)
        {
            LastOperation = operationName + " at " + DateTime.Now;
        }

        public void RestoreSavedState()
        {
            SetMemento(c.Memento);

            FillLastOperation(CTE_RESET_REPOSITORY);

            Notify();
        }


        //Observers
        public void Attach(IObserver observer)
        {
            lObservers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            if(lObservers.Contains(observer))
                lObservers.Remove(observer);
        }

        private void Notify()
        {
            foreach (IObserver o in lObservers)
            {
                o.Update();
            }
        }

        //Memento
        internal RepositoryMemento SaveMemento()
        {
            List<IComparable> lCustomersCopy = new List<IComparable>();

            foreach (IComparable c in lCustomer)
            {
                Customer customer = (Customer)c;
                lCustomersCopy.Add( (IComparable)c );
            }

            return (new RepositoryMemento(lCustomersCopy));
        }

        public void SetMemento(RepositoryMemento memento)
        {
            lCustomer = memento.State;
        }
    }
}
