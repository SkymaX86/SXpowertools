using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXpowertools.Extensions
{
    public static class UriExtensions
    {
        public class UriParameter
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        /// <summary>
        /// <para>DE: Holt die Parameter aus der übergebenen Uri Instanz</para>
        /// <para>EN: Parameterses the specified instance.</para>
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static IList<UriParameter> Parameters(this Uri instance)
        {
            string[] _params = instance.Query.Split(
                new string[] { "&" },
                StringSplitOptions.None
            );

            List<UriParameter> list = new List<UriParameter>();

            foreach (string par in _params)
            {
                string[] _sep = par.Split(new char[] { '=' });
                string _key = "";
                string _value = "";

                if (_sep.Length > 0)
                {
                    _key = _sep[0].Replace("?", "").Replace("&", "");
                }

                if (_sep.Length > 1)
                {
                    _value = _sep[1].Replace("?", "").Replace("&", "");
                }

                list.Add(new UriParameter() { Key = _key, Value = _value });
            }

            return list;
        }

        /// <summary>
        /// <para>DE: Holt die Parameter aus der übergebenen Uri Instanz und fügt diese in ein Dictornary</para>
        /// <para>EN: Parameterses the specified instance to dictionary.</para>
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static Dictionary<string, string> ParameterList(this Uri instance)
        {
            IList<UriParameter> list = instance.Parameters();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (UriParameter param in list)
            {
                dict.Add(param.Key, param.Value);
            }

            return dict;
        }
    }
}
