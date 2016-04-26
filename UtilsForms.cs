using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacadeEjer.View
{
    static class UtilsForms
    {
        //public enum options { create, remove, clear, check, show, save, exit };

        static public void YeimiBanner()
        {
            Console.Clear();
            Console.WriteLine("***********************");
            Console.WriteLine("****** YEIMI BANK *****");
            Console.WriteLine("***********************\n");
        }

        static public string CustomerNameRequest()
        {
            Console.WriteLine("\nInsert customer name: ");
            string name = Console.ReadLine();
            return name;
        }

        static public bool ConfirmMessage()
        {
            Console.WriteLine("\nDo you want to proceed? Y/N");
            string selectedOption = Console.ReadLine();

            if (selectedOption.ToUpper().Equals("Y")) return true;
            else if (selectedOption.ToUpper()
                .Equals("N")) return false;

            else throw new Exception("Invalid option mother fucker!");
        }

        static public string GetOption()
        {
            Console.Write("\nSelect an option: ");
            string option = Console.ReadLine();
            return option;
        }

        static public void SucceedMessage()
        {
            Console.WriteLine("\nOperation succeed !");
            Console.ReadLine();
            Console.Clear();
        }

        static public void PrintApplicationMainMenu()
        {
            UtilsForms.YeimiBanner();

            Console.WriteLine("1- Create new customer.\n");
            Console.WriteLine("2- Remove customer.\n");
            Console.WriteLine("3- Clear customer repository.\n");
            Console.WriteLine("4- Check for a customer´s Mortgage.\n");
            Console.WriteLine("5- Show all customers.\n");
            Console.WriteLine("6- Save changes.\n");
            Console.WriteLine("7- Show operations log.\n");
            Console.WriteLine("8- Undo last operation.\n");
            Console.WriteLine("9- Exit.");
        }   

    }
}
