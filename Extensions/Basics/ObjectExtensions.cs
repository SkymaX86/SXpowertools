using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXpowertools.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNumeric(this object _object)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(_object),
                                     System.Globalization.NumberStyles.Any,
                                     System.Globalization.NumberFormatInfo.InvariantInfo,
                                     out retNum);
            return isNum;
        }
    }
}
