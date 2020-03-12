using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPINT_Wk1_Strategies
{
    public class NumberConverterFactory
    {
        public IEnumerable<string> ConverterNames
        {
            get { return _converters.Keys;  }
        }

        private Dictionary<string, INumberConverter> _converters;

        public NumberConverterFactory() 
        {
            _converters = new Dictionary<string, INumberConverter>();
            _converters["Numerical"] = new NumericalNumberConverter();
            _converters["Binary"] = new BinaryNumberConverter();
            _converters["Hexadecimal"] = new HexadecimalNumberConverter();
            _converters["Roman"] = new RomanNumberConverter();
            _converters["Octal"] = new OctalNumberConverter();
        }

        public INumberConverter GetConverter(string name)
        {
            return _converters[name];
        }
    }
}