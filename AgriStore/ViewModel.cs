using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace AgriStoreLogic
{
    public static class ViewModel
    {
        static List<Cow> cowList = new List<Cow>();

        //Help menu
        //Help menu method
        public static void HelpMenu()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Address book usage:");
            Console.WriteLine("add    - Add a person to the address book.");
            Console.WriteLine("remove - Remove a person from the address book.");
            Console.WriteLine("list   - List all people in address book.");
            Console.WriteLine("exit   - Exit the program.");
            Console.WriteLine("------------------------------------------------");

            Console.Write("\nPress any key to continue.");
            Console.ReadKey();
        }

        // Add a new cow to the list (update to use for any kind of animal)
        public static void addToList()
        {

            string tempinput, inputName;
            int inputId, inputAge, inputWeight;

            // Get cows name from user input
            Console.Write("Enter the cow's name: ");
            inputName = Console.ReadLine();

            // Get cows age from user input
            Console.Write("Enter the cow's age: ");
            tempinput = Console.ReadLine();
            Int32.TryParse(tempinput, out inputAge);

            // Get cows weight from user input
            Console.Write("Enter the cow's weight: ");
            tempinput = Console.ReadLine();
            Int32.TryParse(tempinput, out inputWeight);

            // Set the ID as the number of elements in the list
            inputId = cowList.Count();

            cowList.Add(new Cow() { Id = inputId, Age = inputAge, Weight = inputWeight, Name = inputName });

        }

        private static void ViewElement(Cow cow)
        {
            Console.WriteLine("\n############################");
            Console.WriteLine($"#   Name: {cow.Name}");
            Console.WriteLine($"#   Age: {cow.Age}");
            Console.WriteLine($"#   Weight: {cow.Weight}");
            Console.WriteLine($"#   ID: {cow.Id}");
            Console.WriteLine("############################\n");
        }

        public static void viewList()
        {

            foreach (Cow c in cowList)
            {
                ViewElement(c);
            }

        }

        // Remove element from list
        public static void removeFromList()
        {
            Console.WriteLine("Enter the name of the person you would like to remove.");
            string firstName = Console.ReadLine();
            Cow person = cowList.FirstOrDefault(x => x.Name.ToLower() == firstName.ToLower());

            if (person == null)
            {
                Console.WriteLine("That person could not be found. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Are you sure you want to remove this person from your address book? (Y/N)");
            ViewElement(person);
            
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                cowList.Remove(person);
                Console.Write("\nPerson removed. Press any key to continue.");
                Console.ReadKey();
            }
        }

        public static void saveList()
        {
            using (StreamWriter file = File.CreateText(@"agristore.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                // Serialize object directly into file stream
                serializer.Serialize(file, cowList);
            }
        }

    }
}
