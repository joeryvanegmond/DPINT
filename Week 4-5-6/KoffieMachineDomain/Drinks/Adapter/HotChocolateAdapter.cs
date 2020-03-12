using System.Collections.Generic;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Drinks
{
    public class HotChocolateAdapter : BaseDrinkDecorator, IHotChocolateDrinkAdapter
    {
        private readonly HotChocolate _hotChocolate;

        public HotChocolateAdapter(IDrink drink) : base(drink)
        {
            _hotChocolate = new HotChocolate();
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Adding hot chocolate...");
        }

        public void MakeDeluxe()
        {
            _hotChocolate.MakeDeluxe();
        }
    }
}