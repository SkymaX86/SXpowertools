using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SXpowertools.Extensions
{
    public static class SystemTypeExtensions
    {
        #region string
        /// <summary>
        /// <para>DE: Wandelt einen decimal in einen string nach europäischen Format(Tausendertrenner und Komma) um.</para>
        /// <para>EN: Converts a decimal to european currencyformat (dots and comma) </para>
        /// </summary>
        /// <param name="_value">the decimal value</param>
        /// <returns>european currency formated string</returns>
        public static string ToEuropeanCurrencyFormat(this decimal _value)
        {
            return String.Format("{0:##,##0.00}", _value);
        }

        #endregion
    }
}
