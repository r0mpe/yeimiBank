using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data;

namespace FacadeEjer.Data.Models
{
    internal class Credit
    {
        private float credit;
        internal Credit()
        {
            credit = 700;
        }

        internal bool HasGoodCredit(Customer c)
        {
            if (c.Patrimony >= credit)
                return true;
            else
                return false;
        }
    }
}
