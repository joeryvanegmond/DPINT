using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    public class WhippedCreamDecorator : BaseDrinkDecorator
    {
        private double _price;
        public WhippedCreamDecorator(IDrink drink, double price) : base(drink)
        {
            _price = price;
        }
        public override double GetPrice()
        {
            return base.GetPrice() + _price;
        }


        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Adding whipped cream...");
        }
    }
}
