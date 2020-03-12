using System.Collections.Generic;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Drinks
{
    public class TeaDrinkAdapter : Drink, ITeaDrinkAdapter, IDrink
    {
        private readonly Tea _tea;

        public TeaDrinkAdapter() : base("Tea", Tea.Price)
        {
            _tea = new Tea();
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Filling with hot water...");
        }

        public void SetBlend(TeaBlend blend)
        {
            _tea.Blend = blend;
        }
    }
}