using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    public interface IDrink
    {
        string Name { get; }
        double GetPrice();
        void LogDrinkMaking(ICollection<string> log);
    }
}
