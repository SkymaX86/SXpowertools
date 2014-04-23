using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXpowertools.Extensions
{
    public static class KeyValuePairExtensions
    {
        /// <summary>
        /// <para>DE: Wandelt das KeyValuePair in einen Parameterstring</para>
        /// <para>EN: To param string.</para>
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static string ToParamString<TKey, TValue>(this KeyValuePair<TKey, TValue> instance)
        {
            StringBuilder str = new StringBuilder();

            string _key = (string)((object)instance.Key);
            string _value = (string)((object)instance.Value);

            if (!_key.IsNullOrWhiteSpace())
            {
                str.Append("&");
            }

            if (!_key.IsNullOrWhiteSpace())
            {
                str.Append(_key);
            }

            if (!_value.IsNullOrWhiteSpace())
            {
                str.Append("=");
                str.Append(_value);
            }

            return str.ToString();
        }
    }
}
