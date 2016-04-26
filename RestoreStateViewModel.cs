using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeEjer.Data.Models;

namespace FacadeEjer.ViewModel
{
    internal class RestoreStateViewModel : ProgramViewModel
    {
        //Constructor
        internal RestoreStateViewModel(IRepository customersRepo)
            : base(customersRepo)
        { }

        //Method
        internal void RestoreState()
        {
            CustomerRepo.RestoreSavedState();
        }
    }
}
