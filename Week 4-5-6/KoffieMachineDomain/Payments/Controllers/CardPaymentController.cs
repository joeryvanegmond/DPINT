using System.Collections.Generic;

namespace KoffieMachineDomain.Payments
{
    public class CardPaymentController : ICardPaymentController
    {
        private Dictionary<string, double> _cashOnCards;

        public CardPaymentController()
        {
            InitializeCards();
        }

        public void InitializeCards()
        {
            _cashOnCards = new Dictionary<string, double>
            {
                ["Arjen"] = 5.0,
                ["Bert"] = 3.5,
                ["Chris"] = 7.0,
                ["Daan"] = 6.0
            };
        }

        public double PayDrink(string name, double remainingPriceToPay)
        {
            var insertedMoney = GetCardAmountLeft(name);
            if (remainingPriceToPay <= insertedMoney)
            {
                _cashOnCards[name] = insertedMoney - remainingPriceToPay;
                return 0;
            }
            else
            {
                _cashOnCards[name] = 0;
                return remainingPriceToPay - insertedMoney;
            }
        }

        public ICollection<string> GetCardKeys()
        {
            return _cashOnCards.Keys;
        }

        public double GetCardAmountLeft(string name)
        {
            if (_cashOnCards.ContainsKey(name))
                return _cashOnCards[name];

            return -1;
        }
    }
}
