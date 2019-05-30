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
        private const string JSON = ".json";
        static List<Cow> cowList = new List<Cow>();

        // Help menu
        // Help menu method
        public static void HelpMenu()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("AgriStore usage:");
            Console.WriteLine("add    - Add a Animal to the address book.");
            Console.WriteLine("remove - Remove a Animal from the address book.");
            Console.WriteLine("view   - List all people in address book.");
            Console.WriteLine("open   - Open a database file.");
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
            Console.WriteLine("Enter the name of the animal you would like to remove.");
            string firstName = Console.ReadLine();
            Cow Animal = cowList.FirstOrDefault(x => x.Name.ToLower() == firstName.ToLower());

            if (Animal == null)
            {
                Console.WriteLine("That animal could not be found. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Are you sure you want to remove this animal from your address book? (Y/N)");
            ViewElement(Animal);

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                cowList.Remove(Animal);
                Console.Write("\nAnimal removed. Press any key to continue.");
                Console.ReadKey();
            }
        }

        public static void saveList()
        {
            // Create folder in AppData
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string ourDirectory = Path.Combine(folder, "AgriStore");
            // Create folder if it doesn't already exist, otherwise skip
            if (!Directory.Exists(ourDirectory))
            {
                Directory.CreateDirectory(ourDirectory);
            }
            else
            {
                Console.WriteLine("Directory already exists, skipping step.");
            }

            // User input for the name of the file to save
            Console.Write("Enter the name of the file to save: ");
            string fileName = Console.ReadLine() + JSON;

            // Serialize data
            using (StreamWriter file = File.CreateText($"{ourDirectory}\\{fileName}"))
            {
                JsonSerializer serializer = new JsonSerializer();
                // Serialize object directly into file stream
                serializer.Serialize(file, cowList);
            }
        }

        public static void openDatabase()
        {
            // Read JSON file into list 
            string inputData = File.ReadAllText(@"C:\Users\scott.gilchrist\AppData\Roaming\AgriStore\output.json");
            cowList = JsonConvert.DeserializeObject<List<Cow>>(inputData);
        }

    }
}
