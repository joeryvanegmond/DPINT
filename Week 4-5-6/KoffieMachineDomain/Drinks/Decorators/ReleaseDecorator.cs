using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    public class ReleaseDecorator : BaseDrinkDecorator, IDrink
    {
        public ReleaseDecorator(IDrink drink) : base(drink)
        {
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Finished making {Name}.");
        }
    }
}