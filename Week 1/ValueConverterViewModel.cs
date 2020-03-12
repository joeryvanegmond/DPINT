using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DPINT_Wk1_Strategies
{
    public class ValueConverterViewModel : ViewModelBase
    {
        private INumberConverter _fromConverter;
        public INumberConverter FromConverter { get; set; }
        private INumberConverter _toConverter;
        public INumberConverter ToConverter { get; set; }

        private string _fromText;
        public string FromText
        {
            get { return _fromText; }
            set
            {
                _fromText = value;
                RaisePropertyChanged("FromText");
                this.ConvertNumbers();
            }
        }

        private string _toText;
        public string ToText
        {
            get { return _toText; }
            set
            {
                _toText = value;
                RaisePropertyChanged("ToText");
            }
        }

        private string _fromConverterName;
        public string FromConverterName
        {
            get { return _fromConverterName; }
            set
            {
                _fromConverterName = value;
                _fromConverter = _numberConverterFactory.GetConverter(FromConverterName);
                RaisePropertyChanged("FromConverterName");
                this.ConvertNumbers();
            }
        }

        private string _toConverterName;
        public string ToConverterName
        {
            get { return _toConverterName; }
            set
            {
                _toConverterName = value;
                _toConverter = _numberConverterFactory.GetConverter(ToConverterName);
                RaisePropertyChanged("ToConverterName");
                this.ConvertNumbers();
            }
        }

        public ObservableCollection<string> ConverterNames { get; set; }
        public ICommand ConvertCommand { get; set; }
        private NumberConverterFactory _numberConverterFactory;

        //constructor
        public ValueConverterViewModel()
        {
            _numberConverterFactory = new NumberConverterFactory();
            var temp = _numberConverterFactory.ConverterNames.ToList();
            ConverterNames = new ObservableCollection<string>(temp);

            FromText = "0";
            ToText = "0";
            FromConverterName = ConverterNames.First();
            ToConverterName = ConverterNames.First();

            ConvertCommand = new RelayCommand(ConvertNumbers);
        }
        private void ConvertNumbers()
        {
            int number = 0;
            if (_fromConverter != null && _toConverter != null)
            {
                try
                {
                    number = _fromConverter.ToNumerical(FromText);
                }
                catch (Exception)
                {
                    FromText = number.ToString();
                }
                
                ToText = _toConverter.ToLocalString(number);
            }
        }
    }
}
