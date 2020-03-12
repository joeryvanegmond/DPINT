using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Payments.Interfaces
{
    interface ICashPaymentController
    {
        double PayDrink(double insertedMoney, double remainingPriceToPay);
    }
}
