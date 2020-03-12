using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    using Enumerations;

    class BaseCoffeeDecorator : BaseDrinkDecorator, IDrink
    {
        public Strength CoffeeStrength { get; }

        public BaseCoffeeDecorator(IDrink drink, Strength strength = Strength.Normal) : base(drink)
        {
            CoffeeStrength = strength;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {CoffeeStrength}.");
        }
    }
}