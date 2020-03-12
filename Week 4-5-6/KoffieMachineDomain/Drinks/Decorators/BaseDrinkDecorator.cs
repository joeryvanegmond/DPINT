using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    public abstract class BaseDrinkDecorator : IDrink
    {
        public IDrink Drink { get; set; }

        public BaseDrinkDecorator(IDrink drink)
        {
            Drink = drink;
        }

        public string Name => Drink.Name;

        public virtual double GetPrice()
        {
            return Drink.GetPrice();
        }

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);
        }
    }
}