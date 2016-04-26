using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeEjer.Data.Models
{
    interface IRepository
    {
        //Methods
        Object GetElements();

        void AddElement(object element);
        void ResetRepository();
        void RemoveElement(string elementName);
    }
}
