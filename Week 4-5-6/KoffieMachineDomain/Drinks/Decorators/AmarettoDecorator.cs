using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    public class AmarettoDecorator : BaseDrinkDecorator
    {
        public AmarettoDecorator(IDrink drink) : base(drink)
        {
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Adding a shot of Amaretto...");
        }
    }
}
