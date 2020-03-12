using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPINT_Wk1_Strategies
{
    public interface INumberConverter
    {
        string ToLocalString(int number);
        int ToNumerical(string fromText);
    }
}