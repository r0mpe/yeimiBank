using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data;

namespace FacadeEjer.Data.Models
{
    internal class Bank
    {
        private float savings;

        internal Bank(float savigns)
        {
            this.savings = savings;
        }

        public bool HasSufficientSaving(Customer c, float amount)
        {
            //Console.WriteLine("*Check bank for {0}...", c.Name);
            if (amount > savings)
                return true;
            else
                return false;
        }
    }
}
