namespace KoffieMachineDomain.Drinks
{
    class HotChocolateDeluxeDecorator : BaseDrinkDecorator
    {
        public HotChocolateDeluxeDecorator(IHotChocolateDrinkAdapter drink) : base(drink)
        {
            HotChocolate.MakeDeluxe();
        }

        private IHotChocolateDrinkAdapter HotChocolate
        {
            get => Drink as IHotChocolateDrinkAdapter;
        }
    }
}