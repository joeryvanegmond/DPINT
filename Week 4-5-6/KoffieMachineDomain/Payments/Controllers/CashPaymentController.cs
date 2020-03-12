using KoffieMachineDomain.Payments.Interfaces;
using System;

namespace KoffieMachineDomain.Payments
{
    public class CashPaymentController : ICashPaymentController
    {
        public double PayDrink(double insertedMoney, double remainingPriceToPay)
        {
            return Math.Max(Math.Round(remainingPriceToPay - insertedMoney, 2), 0);
        }
    }
}
