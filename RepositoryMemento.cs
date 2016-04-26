using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeEjer.Data.Models.Memento
{
    public class RepositoryMemento : ICloneable
    {
        //Attribute
        List<IComparable> lCustomerState;

        //Constructor
        public RepositoryMemento()
        {
            lCustomerState = new List<IComparable>();
        }

        public RepositoryMemento(List<IComparable> lCustomerState)
        {
            this.lCustomerState = lCustomerState;
        }

        //Method
        public List<IComparable> State
        {
            get { return lCustomerState; }
        }


        public object Clone()
        {
            List<IComparable> lCustomerStateCopy = new List<IComparable>();
            foreach (ICloneable c in lCustomerState)
                lCustomerState.Add((Customer)c.Clone());

            return new RepositoryMemento(this.lCustomerState);
        }
    }
}
