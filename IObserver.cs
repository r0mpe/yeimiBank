using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeEjer.Data.Models.Log
{
    public interface IObserver
    {
        void Update();
    }
}
