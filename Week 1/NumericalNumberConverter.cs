using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPINT_Wk1_Strategies
{
    public class NumericalNumberConverter : INumberConverter
    {
        string INumberConverter.ToLocalString(int number)
        {
            return number.ToString();
        }

        int INumberConverter.ToNumerical(string fromText)
        {
            return Int32.Parse(fromText);
        }
    }
}