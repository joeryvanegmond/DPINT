using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Adapter
{
    public class SpecialDrinkAdapter : BaseDrinkDecorator
    {
        private string _ingredient;

        public SpecialDrinkAdapter(IDrink drink, string ingredient) : base(drink)
        {
            Drink = drink;
            _ingredient = ingredient;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Adding {_ingredient} to the coffee");
        }

    }
}
