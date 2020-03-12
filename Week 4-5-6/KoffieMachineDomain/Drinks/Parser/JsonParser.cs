using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Parser
{
    public class SpecialCoffeeJSONHandler
    {
        private const string FileName = "SpecialCoffee.json";

        public IDictionary<string, ICollection<string>> SpecialCoffees { get; private set; }

        public SpecialCoffeeJSONHandler()
        {
            GetSpecialCoffees();

            if (SpecialCoffees == null)
            {
                SpecialCoffees = new Dictionary<string, ICollection<string>>();
                AddSpecialCoffee("Irish Coffee", new List<string> { "Whiskey", "Coffee", "Sugar", "Whippedcream" });
                AddSpecialCoffee("Spanish Coffee", new List<string> { "Cointreau", "Cognac", "Coffee", "Sugar", "Whippedcream" });
                AddSpecialCoffee("Italian Coffee", new List<string> { "Amaretto", "Coffee", "Sugar", "Whippedcream" });
            }
        }

        public void GetSpecialCoffees()
        {
            using (FileStream fs = File.Open(Path.Combine(Environment.CurrentDirectory, FileName), FileMode.OpenOrCreate))
            using (StreamReader sr = new StreamReader(fs))
            {
                dynamic specialCoffeesRead = JsonConvert.DeserializeObject(sr.ReadToEnd());
                if (specialCoffeesRead != null)
                {
                    SpecialCoffees = specialCoffeesRead.ToObject<Dictionary<string, ICollection<string>>>();
                }
            }
        }

        public void AddSpecialCoffee(string coffeeName, ICollection<string> options)
        {
            SpecialCoffees.Add(coffeeName, options);

            SaveSpecialCoffees();
        }

        public void SaveSpecialCoffees()
        {
            using (FileStream fs = File.Open(Path.Combine(Environment.CurrentDirectory, FileName), FileMode.Truncate, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, SpecialCoffees);
            }
        }
    }
}
