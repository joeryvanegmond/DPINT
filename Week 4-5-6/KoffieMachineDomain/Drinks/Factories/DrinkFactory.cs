using TeaAndChocoLibrary;
using System.Collections.Generic;

namespace KoffieMachineDomain.Drinks
{
    using Enumerations;
    using KoffieMachineDomain.Drinks.Adapter;
    using SpecialDrinkLibrary.model;

    public class DrinkFactory
    {
        public static IDrink CreateDrink(DrinkInformation info, Strength strength, Dictionary<string, Amount> additionals)
        {
            IDrink baseDrink;
            switch (info.Name)
            {
                case "Coffee":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, strength, 1);
                    break;
                case "Coffee With Milk":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, strength, 1);
                    baseDrink = new MilkDecorator(baseDrink, additionals["milk"], 0.1);
                    break;
                case "Coffee With Sugar":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, strength, 1);
                    baseDrink = new SugarDecorator(baseDrink, additionals["sugar"], 0.1);
                    break;
                case "Coffee With Sugar And Milk":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, strength, 1);
                    baseDrink = new SugarDecorator(baseDrink, additionals["sugar"], 0.1);
                    baseDrink = new MilkDecorator(baseDrink, additionals["milk"], 0.1);
                    break;
                case "Espresso":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, Strength.Strong, 1.7, Amount.Few);
                    break;
                case "Capuccino":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, Strength.Strong, 1.7, Amount.Few);
                    baseDrink = new MilkDecorator(baseDrink, additionals["milk"], 0.1);
                    break;
                case "Wiener Melange":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, strength, 1.6);
                    baseDrink = new SugarDecorator(baseDrink, Amount.Normal, 0.1);
                    baseDrink = new WhippedCreamDecorator(baseDrink, 0.3);
                    break;
                case "Café au Lait":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, strength, 1.4);
                    baseDrink = new MilkDecorator(baseDrink, Amount.Extra, 0.1);
                    break;
                case "Chocolate":
                    baseDrink = new HotChocolateDrinkAdapter();
                    break;
                case "Chocolate Deluxe":
                    IHotChocolateDrinkAdapter hotChocolate = new HotChocolateDrinkAdapter();
                    baseDrink = new HotChocolateDeluxeDecorator(hotChocolate);
                    break;
                case "Tea":
                    ITeaDrinkAdapter tea = new TeaDrinkAdapter();
                    baseDrink = new TeaBlendDecorator(tea, info.Blend);
                    break;
                case "Tea With Sugar":
                    ITeaDrinkAdapter teaWithSugar = new TeaDrinkAdapter();
                    baseDrink = new TeaBlendDecorator(teaWithSugar, info.Blend);
                    baseDrink = new SugarDecorator(baseDrink, Amount.Normal, 0.1);
                    break;
                case "Irish Coffee":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, strength, 2.5);
                    baseDrink = new SugarDecorator(baseDrink, Amount.Normal, 0.1);
                    baseDrink = new WhiskeyDecorator(baseDrink);
                    baseDrink = new WhippedCreamDecorator(baseDrink, 0.3);
                    break;
                case "Spanish Coffee":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, strength, 2.5);
                    baseDrink = new SugarDecorator(baseDrink, Amount.Normal, 0.1);
                    baseDrink = new CognacDecorator(baseDrink);
                    baseDrink = new CointreauDecorator(baseDrink);
                    baseDrink = new WhippedCreamDecorator(baseDrink, 0.3);
                    break;
                case "Italian Coffee":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, strength, 2.5);
                    baseDrink = new SugarDecorator(baseDrink, Amount.Normal, 0.1);
                    baseDrink = new AmarettoDecorator(baseDrink);
                    baseDrink = new WhippedCreamDecorator(baseDrink, 0.3);
                    break;
                case "CoffeeChoc":
                    baseDrink = new Drink(info.Name);
                    baseDrink = new CoffeeDecorator(baseDrink, strength, 2.0);
                    baseDrink = new HotChocolateAdapter(baseDrink);
                    break;
                case "SpecialDrink":
                    baseDrink = new Drink(info.SpecialDrink.Name, info.SpecialDrink.Price);
                    foreach (var item in info.SpecialDrink.Ingredients)
                    {
                        baseDrink = new SpecialDrinkAdapter(baseDrink, item);
                    }
                    break;
                default:
                    return null;
            }

            return new ReleaseDecorator(baseDrink);
        }
    }
}
