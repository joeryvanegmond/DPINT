using System;
using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    public class Drink : IDrink
    {
        private readonly double _price;

        public Drink(string name, double price = 0)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Drink name can not be null or empty");
            Name = name;
            _price = price;
        }

        public string Name { get; }

        public virtual double GetPrice()
        {
            return _price;
        }

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {Name}...");
        }
    }
}