using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeEjer.Data.Models.Sort
{
    public class QuickSort : ISortStrategy
    {
        public List<IComparable> Sort(List<IComparable> list)
        {
            ExecuteQuickSort(list.ToArray(), 0, list.Count - 1);

            return list;
        }

        private void ExecuteQuickSort(IComparable[] arrCustomer, int left_limit, int right_limit)
        {

            int left_index = left_limit;
            int right_index = right_limit;

            IComparable pivot = arrCustomer[(left_index + right_index) / 2];

            while (left_index < right_index)
            {
                while (arrCustomer[left_index].CompareTo(pivot) < 0)
                {
                    left_index++;
                }

                while (arrCustomer[right_index].CompareTo(pivot) > 0)
                {
                    right_index--;
                }

                //Si no se cruzan los indices
                if (left_index <= right_index)
                {
                    //Intercambio
                    IComparable tmp = arrCustomer[left_index];
                    arrCustomer[left_index] = arrCustomer[right_index];
                    arrCustomer[right_index] = tmp;

                    left_index++;
                    right_index--;
                }
            }

            //Rama izquierda del árbol de llamadas
            if (left_limit < right_index)
            {
                ExecuteQuickSort(arrCustomer, left_limit, right_index);
            }

            //Rama derecha del árbol de llamadas
            if (left_index < right_limit)
            {
                ExecuteQuickSort(arrCustomer, left_index, right_limit);
            }
        }
    }
}
