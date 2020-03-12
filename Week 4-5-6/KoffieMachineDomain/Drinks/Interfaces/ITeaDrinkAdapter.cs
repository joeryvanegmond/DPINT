using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Drinks
{
    public interface ITeaDrinkAdapter : IDrink
    {
        void SetBlend(TeaBlend blend);
    }
}
