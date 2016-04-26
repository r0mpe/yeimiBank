using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeEjer.Data.Models.Sort
{
    public class ShellSort : ISortStrategy
    {

        public List<IComparable> Sort(List<IComparable> list)
        {
            list.Sort();
            return list;
        }
    }
}
