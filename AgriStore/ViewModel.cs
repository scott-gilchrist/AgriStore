using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriStoreLogic
{
    public static class ViewModel
    {
        static List<Cow> cowList = new List<Cow>();

        // Add a new cow to the list (update to use for any kind of animal)
        public static void addCow()
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

        public static void viewList()
        {

            foreach (Cow c in cowList)
            {
                Console.WriteLine("\n############################");
                Console.WriteLine($"#   Name: {c.Name}");
                Console.WriteLine($"#   Age: {c.Age}");
                Console.WriteLine($"#   Weight: {c.Weight}");
                Console.WriteLine($"#   ID: {c.Id}");
                Console.WriteLine("############################\n");
            }

        }

    }
}
