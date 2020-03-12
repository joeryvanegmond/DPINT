using System.Collections.Generic;
using KoffieMachineDomain.Drinks.Enumerations;

namespace KoffieMachineDomain.Drinks
{

    class CoffeeDecorator : BaseCoffeeDecorator, IDrink
    {
        private double _price;
        private Amount _amount;
        public CoffeeDecorator(IDrink drink, Strength strength = Strength.Normal, double price = 0, Amount amount = Amount.Normal) : base(drink, strength)
        {
            _amount = amount;
            _price = price;
        }


        public override double GetPrice()
        {
            return base.GetPrice() + _price;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee amount to {_amount}.");
            log.Add("Filling with coffee...");
        }
    }
}