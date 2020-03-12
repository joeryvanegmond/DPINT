using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    using Enumerations;

    public class MilkDecorator : BaseDrinkDecorator, IDrink
    {
        private double _price;
        public Amount MilkAmount { get; }

        public MilkDecorator(IDrink drink, Amount milkAmount, double price) : base(drink)
        {
            _price = price;
            MilkAmount = milkAmount;
        }

        public override double GetPrice()
        {
            return base.GetPrice() + _price;
        }


        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting milk amount to {MilkAmount}.");
            log.Add("Adding milk...");
        }
    }
}
