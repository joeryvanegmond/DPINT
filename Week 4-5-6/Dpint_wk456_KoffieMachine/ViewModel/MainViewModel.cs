using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using KoffieMachineDomain.Drinks;
using KoffieMachineDomain.Drinks.Enumerations;
using KoffieMachineDomain.Drinks.Parser;
using KoffieMachineDomain.Payments;
using System.Collections.Generic;
using System.Linq;
using TeaAndChocoLibrary;
using SpecialDrinkLibrary.repo;

namespace Dpint_wk456_KoffieMachine.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private CardPaymentController cardPaymentController;
        private CashPaymentController cashPaymentController;
        private TeaBlendRepository teaBlendRepository;
        private CultureInfo currentCulture;
        public ObservableCollection<string> LogText { get; private set; }
        private Dictionary<string, Amount> additionals;
        private SpecialDrinkRepo specialDrinkRepo;


        public MainViewModel()
        {
            _coffeeStrength = Strength.Normal;

            additionals = new Dictionary<string, Amount>();
            additionals.Add("milk", Amount.Normal);
            additionals.Add("sugar", Amount.Normal);

            LogText = new ObservableCollection<string>
            {
                "Starting up...",
                "Done, what would you like to drink?"
            };
            cardPaymentController = new CardPaymentController();
            cashPaymentController = new CashPaymentController();

            PaymentCardUsernames = new ObservableCollection<string>(cardPaymentController.GetCardKeys());
            SelectedPaymentCardUsername = PaymentCardUsernames[0];
            

            teaBlendRepository = new TeaBlendRepository();
            TeaBlendNames = new ObservableCollection<string>(teaBlendRepository.BlendNames);
            SelectedTeaBlend = TeaBlendNames[0];
            SpecialDrinkRepo = new SpecialDrinkRepo();
            List<string> specials = SpecialDrinkRepo.GetSpecialDrinkNames();
            SpecialDrinks = new ObservableCollection<string>();
            foreach (var item in specials)
            {
                SpecialDrinks.Add(item);
            }
            SelectedSpecialDrink = SpecialDrinks[0];

            currentCulture = new CultureInfo("nl-NL");
            currentCulture.NumberFormat.CurrencyPositivePattern = 0;
            currentCulture.NumberFormat.CurrencyNegativePattern = 2;
            currentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
        }

        #region Drink properties to bind to
        private IDrink _selectedDrink;
        public string SelectedDrinkName
        {
            get { return _selectedDrink?.Name; }
        }

        public double? SelectedDrinkPrice
        {
            get { return _selectedDrink?.GetPrice(); }
        }
        #endregion Drink properties to bind to

        #region Payment
        public RelayCommand PayByCardCommand => new RelayCommand(() =>
        {
            if (_selectedDrink == null)
                return;

            var insertedMoney = cardPaymentController.GetCardAmountLeft(SelectedPaymentCardUsername);
            RemainingPriceToPay = cardPaymentController.PayDrink(SelectedPaymentCardUsername, RemainingPriceToPay);
            LogText.Add($"Inserted {insertedMoney.ToString("C", currentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", currentCulture)}.");
            CheckRemainingPriceToPay();
            RaisePropertyChanged(() => PaymentCardRemainingAmount);
        });

        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            RemainingPriceToPay = cashPaymentController.PayDrink(coinValue, RemainingPriceToPay);
            LogText.Add($"Inserted {coinValue.ToString("C", currentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", currentCulture)}.");
            CheckRemainingPriceToPay();
        });

        private void CheckRemainingPriceToPay()
        {
            if (RemainingPriceToPay == 0)
            {
                _selectedDrink.LogDrinkMaking(LogText);
                LogText.Add("------------------");
                _selectedDrink = null;
            }
        }

        public double PaymentCardRemainingAmount
        {
            get { return cardPaymentController.GetCardAmountLeft(SelectedPaymentCardUsername); }
        }

        public ObservableCollection<string> PaymentCardUsernames { get; set; }
        private string _selectedPaymentCardUsername;
        public string SelectedPaymentCardUsername
        {
            get { return _selectedPaymentCardUsername; }
            set
            {
                _selectedPaymentCardUsername = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }

        private double _remainingPriceToPay;
        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }
        #endregion Payment

        #region Coffee buttons
        private Strength _coffeeStrength;
        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; RaisePropertyChanged(() => CoffeeStrength); }
        }

        public Amount SugarAmount
        {
            get { return additionals["sugar"]; }
            set { additionals["sugar"] = value; RaisePropertyChanged(() => SugarAmount); }
        }

        public Amount MilkAmount
        {
            get { return additionals["milk"]; }
            set { additionals["milk"] = value; RaisePropertyChanged(() => MilkAmount); }
        }

        private string _selectedTeaBlend;
        public string SelectedTeaBlend
        {
            get { return _selectedTeaBlend; }
            set { _selectedTeaBlend = value; RaisePropertyChanged(() => SelectedTeaBlend); }
        }

        private ObservableCollection<string> _teaBlendNames;
        public ObservableCollection<string> TeaBlendNames
        {
            get { return _teaBlendNames; }
            set { _teaBlendNames = value; RaisePropertyChanged(() => TeaBlendNames); }
        }

        public ICommand DrinkCommand => new RelayCommand<DrinkInformation>((info) =>
        {
            info.Blend = teaBlendRepository.GetTeaBlend(SelectedTeaBlend);
            info.SpecialDrink = SpecialDrinkRepo.GetSpecialDrink(SelectedSpecialDrink);

            _selectedDrink = DrinkFactory.CreateDrink(info, CoffeeStrength, additionals);
            RemainingPriceToPay = _selectedDrink.GetPrice();

            LogText.Add($"Selected {SelectedDrinkName}, price: {RemainingPriceToPay.ToString("C", currentCulture)}");
   
            if (CheckSelectedDrink(info.Name))
                return;
        });

        private bool CheckSelectedDrink(string drinkName)
        {
            if (_selectedDrink == null)
            {
                LogText.Add($"Could not make {drinkName}, recipe not found.");
                return true;
            }
            return false;
        }

        #endregion Coffee buttons

        #region SpecialDrinks
        private ObservableCollection<string> _specialDrinks;
        public ObservableCollection<string> SpecialDrinks
        {
            get { return _specialDrinks; }
            set
            {
                _specialDrinks = value;
                RaisePropertyChanged("SpecialDrinks");
            }
        }

        private string _selectedSpecialDrink;
        public string SelectedSpecialDrink
        {
            get { return _selectedSpecialDrink; }
            set
            {
                _selectedSpecialDrink = value;
                RaisePropertyChanged("SelectedSpecialDrink");
            }
        }

        public SpecialDrinkRepo SpecialDrinkRepo { get => specialDrinkRepo; set => specialDrinkRepo = value; }
        #endregion
    }
}