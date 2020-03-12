namespace KoffieMachineDomain.Payments
{
    interface ICardPaymentController
    {
        double PayDrink(string name, double remainingPriceToPay);
    }
}
