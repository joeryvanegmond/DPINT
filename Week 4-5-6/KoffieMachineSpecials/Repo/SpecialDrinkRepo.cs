using Newtonsoft.Json;
using SpecialDrinkLibrary.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialDrinkLibrary.repo
{
    public class SpecialDrinkRepo
    {
        private List<SpecialDrinkModel> _specialDrinks;

        public SpecialDrinkRepo()
        {
            try
            {
                string jsonFromFile = System.IO.File.ReadAllText(@"C:\Users\joery\Downloads\Week_456_Koffiemachine_Egmond_van_Joery\Week_456_Koffiemachine_Egmond_van_Joery\KoffieMachineSpecials\SpecialDrinks.json");
                Debug.WriteLine(jsonFromFile);
                _specialDrinks = new List<SpecialDrinkModel>();
                _specialDrinks = JsonConvert.DeserializeObject<List<SpecialDrinkModel>>(jsonFromFile);

            }
            catch (Exception e)
            {
                Debug.WriteLine("Couldnt read");
                Debug.WriteLine(e);
            }
        }

        public List<string> GetSpecialDrinkNames()
        {
            List<string> names = new List<string>();
            foreach (var drink in _specialDrinks)
                names.Add(drink.Name);
            return names;
        }

        public SpecialDrinkModel GetSpecialDrink(string name)
        {
            foreach (var drink in _specialDrinks)
                if (drink.Name == name)
                    return drink;
            return null;
        }
    }
}
