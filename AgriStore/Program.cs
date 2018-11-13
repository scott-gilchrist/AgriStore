using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriStoreLogic
{
    class Program
    {
        static void Main(string[] args)
        {

            // Take user input for entries into the list
            string userInput = "";

            while (userInput != "exit")
            {
                Console.Write("Enter a command (add, remove, view, help, save, exit): ");
                userInput = Console.ReadLine();

                // Switch for the action to be performed on the list
                switch (userInput.ToLower())
                {
                    case "add":
                        ViewModel.addToList();
                        break;
                    case "view":
                        ViewModel.viewList();
                        break;
                    case "remove":
                        ViewModel.removeFromList();
                        break;
                    case "help":
                        ViewModel.HelpMenu();
                        break;
                    case "save":
                        ViewModel.saveList();
                        break;
                    default:
                        Console.WriteLine("Unknown option");
                        break;

                }
            }
        }
    }
}