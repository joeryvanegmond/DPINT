using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    public class WhiskeyDecorator : BaseDrinkDecorator
    {
        public WhiskeyDecorator(IDrink drink) : base(drink)
        {
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Adding a shot of whiskey...");
        }
    }
}
