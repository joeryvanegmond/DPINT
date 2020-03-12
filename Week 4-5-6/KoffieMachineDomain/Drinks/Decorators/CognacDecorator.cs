using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    public class CognacDecorator : BaseDrinkDecorator
    {
        public CognacDecorator(IDrink drink) : base(drink)
        {
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Adding a shot of cognac...");
        }
    }
}
