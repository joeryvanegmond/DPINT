using System.Collections.Generic;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Drinks
{
    class TeaBlendDecorator : BaseDrinkDecorator
    {
        public TeaBlend Blend { get; }

        public TeaBlendDecorator(ITeaDrinkAdapter drink, TeaBlend blend) : base(drink)
        {
            Blend = blend;
            Tea.SetBlend(blend);
        }

        private ITeaDrinkAdapter Tea
        {
            get => Drink as ITeaDrinkAdapter;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting tea blend to: {Blend.Name}");
            log.Add("Adding tea blend...");
        }
    }
}
