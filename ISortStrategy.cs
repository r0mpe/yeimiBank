using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeEjer.Data.Models.Sort
{
    public interface ISortStrategy
    {
        List<IComparable> Sort(List<IComparable> list);
    }
}
