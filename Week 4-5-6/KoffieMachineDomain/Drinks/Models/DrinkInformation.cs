using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Drinks
{
    using Enumerations;

    public class DrinkInformation
    {
        public string Name { get; set; }
        public TeaBlend Blend { get; set; }
        public SpecialDrinkLibrary.model.SpecialDrinkModel SpecialDrink { get; set; }
    }
}
