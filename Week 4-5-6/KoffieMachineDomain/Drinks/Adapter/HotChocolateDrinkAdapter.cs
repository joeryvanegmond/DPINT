using System.Collections.Generic;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Drinks
{
    public class HotChocolateDrinkAdapter : IHotChocolateDrinkAdapter
    {
        private HotChocolate _hotChocolate;

        public HotChocolateDrinkAdapter()
        {
            _hotChocolate = new HotChocolate();
        }

        public string Name => _hotChocolate.GetNameOfDrink();

        public double GetPrice()
        {
            return _hotChocolate.Cost();
        }

        public void LogDrinkMaking(ICollection<string> log)
        {
            foreach (string step in _hotChocolate.GetBuildSteps())
            {
                log.Add(step);
            }
        }

        public void MakeDeluxe()
        {
            _hotChocolate.MakeDeluxe();
        }
    }
}