using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPINT_Wk1_Strategies
{
    public class HexadecimalNumberConverter : INumberConverter
    {
        string INumberConverter.ToLocalString(int number)
        {
            return Convert.ToString(number, 16);
        }

        int INumberConverter.ToNumerical(string fromText)
        {
           return Convert.ToInt32(fromText, 16);
        }
    }
}