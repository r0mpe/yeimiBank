using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeEjer.Data.Models.Memento
{
    internal class CareTakerMemento
    {
        static CareTakerMemento instance;

        static public CareTakerMemento GetInstance()
        {
            if(instance == null)
                instance = new CareTakerMemento();

            return instance;
        }

        private List<RepositoryMemento> historicalMemento = new List<RepositoryMemento>();

        //Nos permite recuperar el estado anterior ya guardado.
        internal RepositoryMemento Memento
        {
            get 
            {
                if (historicalMemento.Count > 0)
                {
                    RepositoryMemento memento = historicalMemento[historicalMemento.Count - 1];
                    historicalMemento.RemoveAt(historicalMemento.Count - 1);
                    return memento;
                }
                else
                    Console.WriteLine("\n*-All undo done.-*");
                    return new RepositoryMemento();                     
            }
            set 
            {
                historicalMemento.Add(value); 
            }
        }

        private RepositoryMemento this[int index]
        {
            get { return historicalMemento[index]; }
            set { historicalMemento[index] = value; }
        }

    }
}
