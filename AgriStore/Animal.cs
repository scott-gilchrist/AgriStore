using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriStoreLogic
{
    #region Generic animal class

    class Animal
    {
        // Generic values present for all animals with getter and setters
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }

        //Constructor
        public Animal()
        {
            this.Name = "";
            this.Id = 0;
            this.Weight = 0;
            this.Age = 0;
        }
    }

    #endregion

    #region Cow class

    class Cow : Animal
    {
        // Species for specific animal can't be changed
        public readonly string species = "Cow";

    }

    #endregion
}