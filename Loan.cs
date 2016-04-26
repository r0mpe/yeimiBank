using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data;

namespace FacadeEjer.Data.Models
{
    internal class Loan
    {
        internal Loan()
        { }

        internal bool HasNotBadLoans(Customer c)
        {
            //Console.WriteLine("*Check loans for {0}...", c.Name);
            return true;
        }
    }
}
