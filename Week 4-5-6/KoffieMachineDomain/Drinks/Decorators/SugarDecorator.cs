using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    using Enumerations;

    public class SugarDecorator : BaseDrinkDecorator, IDrink
    {
        private double _price;
        public object SugarAmount { get; }

        public SugarDecorator(IDrink drink, Amount sugarAmount, double price) : base(drink)
        {
            _price = price;
            SugarAmount = sugarAmount;
        }

        public override double GetPrice()
        {
            return base.GetPrice() + _price;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting sugar amount to {SugarAmount}.");
            log.Add("Adding sugar...");
        }
    }
}
