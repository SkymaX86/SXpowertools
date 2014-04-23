using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Security.Cryptography;
using System.Drawing;
using SXpowertools.Util;

namespace SXpowertools.Extensions
{
    public static class StringExtensions
    {
        #region Validation

        /// <summary>
        /// <para>DE: Ist der String eine gültige Email Adresse</para>
        /// <para>EN: Check an email adress for its correctness</para>
        /// </summary>
        /// <param name="_string">A email adress to check.</param>
        /// <exception cref="ArgumentNullException">If inputEmail is null.</exception>
        /// <returns>A value that indicates if the string is a real email adress or not.</returns>
        public static bool IsEmail(this string _string)
        {
            if (_string == null)
            {
                throw new ArgumentNullException("_string");
            }

            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}"
                + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\"
                + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            Regex pattern = new Regex(strRegex);

            if (pattern.IsMatch(_string))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// <para>DE: Prüft ob der String nur Leerstellen enthält oder NULL ist.</para>
        /// <para>EN: Checks the string on whitespaces and NULL</para>
        /// </summary>
        /// <param name="_string">the string</param>
        /// <returns><c>true</c> if Null; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrWhiteSpace(this string _string)
        {
            if (string.IsNullOrEmpty(_string))
                return true;

            return string.IsNullOrEmpty(_string.Trim());
        }

        /// <summary>
        /// <para>DE: Überprüft ob der String eine Nummer ist</para>
        /// <para>EN: Check if a string is a number</para>
        /// </summary>
        /// <param name="_string">The string itself.</param>
        /// <exception cref="ArgumentNullException">If value is null.</exception>
        /// <returns>Returns a value that indicates if this string is a numeric string.</returns>
        public static bool IsNumeric(this string _string)
        {
            if (_string == null)
            {
                throw new ArgumentNullException("_string");
            }

            Regex pattern = new Regex(@"^[0-9,.]+$");
            return pattern.IsMatch(_string.Trim());
        }

        /// <summary>
        /// <para>DE: Überprüft ob der String ein Wert ist der True eines Boolean ausdrücken soll,
        ///     z.B.: "1", "Wahr".</para>
        /// <para>EN: Check if a expression is a value that indicates a boolean value,
        ///     like "true", or "1".</para>
        /// </summary>
        /// <param name="_string">The string to check</param>
        /// <returns>A value that indicates if the expression fo the string is true or false.</returns>
        public static bool IsExpressionTrue(this string _string)
        {
            // null is false
            if (_string == null)
            {
                return false;
            }

            // the string should be trimmed, the value " true " should also be true
            string expression = _string.Trim().ToLower(CultureInfo.CurrentCulture);

            // first check if the string is empty
            if (expression.IsNullOrWhiteSpace())
            {
                return false;
            }

            // check if the string is a number, positive numbers are always a true boolean
            if (expression.IsNumeric())
            {
                // check the number for a number decimal digits seperator
                // and if the has a seperator, convert the string as double
                // otherwise convert it as integer
                if (expression.Contains(",")
                || expression.Contains("."))
                {
                    double expD = expression.ToDouble();

                    if (expD > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    int expI = expression.ToInt32();

                    if (expI > 0)
                    {
                        return true;
                    }
                }
            }
            else
            {
                // contains a list of expressions that are all values for "true"
                List<string> trueExpressions = new List<string>() {
					"1", "true", "wahr", "richtig", "korrekt",
					"valid", "correct", "accurate", "proper",
					"respectable", "positiv", "positive",
					"wow", "100pro", "100%", "yes", "ja",
					"si", "ok", "legal", "legitime", "legitim"
				};

                // contains a list of expressions that are all values for "false"
                List<string> falseExpressions = new List<string>() {
					"0", "false", "unwahr", "nicht wahr", "falsch", "inkorrekt",
					"incorrect", "inaccurate", "illegitimate", "fake",
					"invalid", "negativ", "negative", "nein",
					"no", "non", "not", "illegitime", "illegitim"
				};

                // check the string for this values
                if (trueExpressions.Contains(expression))
                {
                    return true;
                }
                else if (falseExpressions.Contains(expression))
                {
                    return false;
                }
            }

            return false;
        }

        #endregion

        #region Safe Convert / Convert Default

        /// <summary>
        /// <para>DE: Konvertiert den _string in den übergebenen Typen</para>
        /// <para>EN: Converts a string into a specific type</para>
        /// </summary>
        /// <typeparam name="T">The specific target type.</typeparam>
        /// <param name="_string">The string itself.</param>
        /// <returns>Returns a new object of the specific type with the value parsed from the given string.</returns>
        public static T ToType<T>(this string _string)
        {
            // compare the type of the string _string with
            // the given type T and use the specific string.ToXYZ
            // extension method
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)_string.ToBoolean();
            }
            else if (typeof(T) == typeof(short))
            {
                return (T)(object)_string.ToInt16();
            }
            else if (typeof(T) == typeof(int))
            {
                return (T)(object)_string.ToInt32();
            }
            else if (typeof(T) == typeof(long))
            {
                return (T)(object)_string.ToInt64();
            }
            else if (typeof(T) == typeof(byte[]))
            {
                return (T)(object)_string.ToByteArray();
            }
            else if (typeof(T) == typeof(DateTime))
            {
                return (T)(object)_string.ToDateTime();
            }
            else if (typeof(T) == typeof(decimal))
            {
                return (T)(object)_string.ToDecimal();
            }
            else if (typeof(T) == typeof(double))
            {
                return (T)(object)_string.ToDouble();
            }
            else if (typeof(T) == typeof(float))
            {
                return (T)(object)_string.ToFloat();
            }
            else
            {
                return (T)(object)_string;
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert einen _string sicher in einen Enum-Value</para>
        /// <para>EN: Converts a string value on a save way into a enum value</para>
        /// </summary>
        /// <typeparam name="T">The target enum type.</typeparam>
        /// <param name="_string">The string itself.</param>
        /// <returns>Returns a enum type of the given string.</returns>
        public static T ToEnum<T>(this string _string)
        {
            if (_string == null)
            {
                throw new ArgumentNullException("_string", "The parameter [value] cannot be null.");
            }

            try
            {
                return (T)Enum.Parse(typeof(T), _string);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in einen Byte Array</para>
        /// <para>EN: Converts a string value on a save way into a byte array value</para>
        /// </summary>
        /// <param name="_string">The string itself.</param>
        /// <returns>Returns the string converted as a byte array.</returns>
        public static byte[] ToAsciiByteArray(this string _string)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetBytes(_string);
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String in ein Byte Array</para>
        /// <para>EN: Converts a string value into a byte array.</para>
        /// </summary>
        /// <returns>The byte array.</returns>
        /// <param name="_string">_string.</param>
        public static byte[] ToByteArray(this string _string)
        {
            byte[] bytes = new byte[_string.Length * sizeof(char)];
            System.Buffer.BlockCopy(_string.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in ein Int16</para>
        /// <para>EN: Converts a string value on a save way into a int16 value</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string converted as a short (Int16) object.</returns>
        public static short ToInt16(this string _string)
        {
            short result = 0;

            if (short.TryParse(_string, out result))
            {
                return result;
            }
            else
            {
                return default(short);
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in ein Int32</para>
        /// <para>EN: Converts a string value on a save way into a int32 value</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string converted as a int (Int32) object.</returns>
        public static int ToInt32(this string _string)
        {
            int result = 0;

            if (int.TryParse(_string, out result))
            {
                return result;
            }
            else
            {
                return default(int);
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in ein Int32</para>
        /// <para>EN: Converts a string value on a save way into a int32 value</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string converted as a int (Int32) object.</returns>
        public static int ToInt32(this string _string, int _defaultValue)
        {
            int result = 0;

            if (int.TryParse(_string, out result))
            {
                return result;
            }
            else
            {
                return _defaultValue;
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in ein Int64</para>
        /// <para>EN: Convert a string value on a save way into a int64 value</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string converted as a long (Int64) object.</returns>
        public static long ToInt64(this string _string)
        {
            long result = 0;

            if (long.TryParse(_string, out result))
            {
                return result;
            }
            else
            {
                return default(long);
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in ein double</para>
        /// <para>EN: Convert a string value on a save way into a double value</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string converted as a double object.</returns>
        public static double ToDouble(this string _string)
        {
            double result = 0;

            if (double.TryParse(_string, out result))
            {
                return result;
            }
            else
            {
                return default(double);
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in ein decimal</para>
        /// <para>EN: Convert a string value on a save way into a decimal value</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string converted as a decimal object.</returns>
        public static decimal ToDecimal(this string _string)
        {
            decimal result = 0;

            if (decimal.TryParse(_string, out result))
            {
                return result;
            }
            else
            {
                return default(decimal);
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in ein decimal</para>
        /// <para>EN: Convert a string value on a save way into a decimal value</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string converted as a decimal object.</returns>
        public static decimal ToDecimal(this string _string, decimal _defaultValue)
        {
            decimal result = 0;

            if (decimal.TryParse(_string, out result))
            {
                return result;
            }
            else
            {
                return _defaultValue;
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert einen Float sicher in ein float</para>
        /// <para>EN: Convert a string value on a save way into a float value</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string converted as a float object.</returns>
        public static float ToFloat(this string _string)
        {
            float result = 0;

            if (float.TryParse(_string, out result))
            {
                return result;
            }
            else
            {
                return default(float);
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in ein Boolean</para>
        /// <para>EN: Convert a string value on a save way into a boolean value</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string converted as a boolean object.</returns>
        public static bool ToBoolean(this string _string)
        {
            bool result = false;

            // if the string equals the values "true" or "false"
            // convert it using the Boolean.Parse method, otherwise
            // use the string.IsExpressionTrue extension method
            if ((_string.Equals("True", StringComparison.OrdinalIgnoreCase)
            || _string.Equals("False", StringComparison.OrdinalIgnoreCase))
            && bool.TryParse(_string, out result))
            {
                return result;
            }

            return _string.IsExpressionTrue();
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in ein DateTime</para>
        /// <para>EN: Convert a string value on a save way into a DateTime value</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string converted as a datetime object.</returns>
        public static DateTime ToDateTime(this string _string)
        {
            DateTime result = default(DateTime);

            if (DateTime.TryParse(
                _string,
                CultureInfo.CurrentCulture.DateTimeFormat,
                DateTimeStyles.AllowWhiteSpaces,
                out result
            ))
            {
                return result;
            }

            result = StringFunctions.yyMMdd_ToDate(_string);

            if(result == DateTime.MinValue)
                result = StringFunctions.yyyyMMdd_ToDate(_string);

            return result;
        }

        /// <summary>
        /// <para>DE: Konvertiert einen String sicher in ein DateTime. Sollte die Konvertierung nicht erfolgreich sein, wird der übergebene Defaultwert zurückgeliefert.</para>
        /// <para>EN: Convert a string value on a save way into a DateTime value. If the converting fails, it returns the _defaultValue</para>
        /// </summary>
        /// <param name="_value">the string to convert</param>
        /// <param name="_defaultValue">the defaultvalue</param>
        /// <returns>Returns the string converted as a datetime object.</returns>
        public static DateTime ToDateTime(this string _string, DateTime _defaultValue)
        {
            DateTime result = _defaultValue;

            if (DateTime.TryParse(
                _string,
                CultureInfo.CurrentCulture.DateTimeFormat,
                DateTimeStyles.AllowWhiteSpaces,
                out result
                ))
            {
                return result;
            }

            result = StringFunctions.yyMMdd_ToDate(_string);

            if (result == DateTime.MinValue)
                result = StringFunctions.yyyyMMdd_ToDate(_string);

            return result;
        }

        /// <summary>
        /// <para>DE: Macht aus einem String ein Char. Nimmt standardmässig das erste Zeichen oder das ander Stelle iIndex</para>
        /// <para>EN: Gets the char of a string on the index position, index defaultvalue is 0.</para>
        /// </summary>
        /// <param name="_string">the string</param>
        /// <param name="iIndex">the index position</param>
        /// <returns>a char</returns>
        public static char ToChar(this string _string, int iIndex = 0)
        {
            if (_string.Length > iIndex)
                return _string[iIndex];
            else
                return (char)0;
        }

        #endregion

        #region Format

        /// <summary>
        /// <para>DE: Formatiert den übergebenen String mit Hilfe von string.Format().</para>
        /// <para>EN: Formats the given string using the string.Format() method</para>
        /// </summary>
        /// <param name="format">The format pattern.</param>
        /// <param name="arg0">The first argument for the string.</param>
        /// <returns>A string that is formated using the string.Format() method.</returns>
        public static string FormatIt(string format, object arg0)
        {
            return string.Format(format, arg0);
        }

        /// <summary>
        /// <para>DE: Formatiert den übergebenen String mit Hilfe von string.Format().</para>
        /// <para>EN: Formats the given string using the string.Format() method</para>
        /// </summary>
        /// <param name="format">The format pattern.</param>
        /// <param name="arg0">The first argument for the string.</param>
        /// <param name="arg1">The second argument for the string.</param>
        /// <returns>A string that is formated using the string.Format() method.</returns>
        public static string FormatIt(string format, object arg0, object arg1)
        {
            return string.Format(format, arg0, arg1);
        }

        /// <summary>
        /// <para>DE: Formatiert den übergebenen String mit Hilfe von string.Format().</para>
        /// <para>EN: Formats the given string using the string.Format() method</para>
        /// </summary>
        /// <param name="format">The format pattern.</param>
        /// <param name="arg0">The first argument for the string.</param>
        /// <param name="arg1">The second argument for the string.</param>
        /// <param name="arg2">The third argument for the string.</param>
        /// <returns>A string that is formated using the string.Format() method.</returns>
        public static string FormatIt(string format, object arg0, object arg1, object arg2)
        {
            return string.Format(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// <para>DE: Formatiert den übergebenen String mit Hilfe von string.Format().</para>
        /// <para>EN: Formats the given string using the string.Format() method</para>
        /// </summary>
        /// <param name="format">The format pattern.</param>
        /// <param name="parameters">A dynamic list of parameters.</param>
        /// <returns>A string that is formated using the string.Format() method.</returns>
        public static string FormatIt(this string format, params object[] parameters)
        {
            return string.Format(format, parameters);
        }

        /// <summary>
        /// <para>DE: Formatiert den übergebenen String mit Hilfe von string.Format().</para>
        /// <para>EN: Formats the given string using the string.Format() method</para>
        /// </summary>
        /// <param name="format">The format pattern.</param>
        /// <param name="provider">The provider to format the output.</param>
        /// <param name="args">A dynamic list of parameters.</param>
        /// <returns>A string that is formated using the string.Format() method.</returns>
        public static string FormatIt(this string format, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, format, args);
        }


        /// <summary>
        /// <para>DE: Formatiert einen String mit Leerstellen nach der angegeben Stelle bis zum Ende.</para>
        /// <para>EN: Formats the _string with spaces to the end.</para>
        /// </summary>
        /// <param name="_string">the _string</param>
        /// <param name="_index">index</param>
        /// <returns>formated string</returns>
        public static string FormatWithWhiteSpace(this string _string, int _index)
        {
            int count = 0;
            string result = "";

            foreach (char item in _string)
            {
                if (count == _index)
                {
                    result += " ";
                    count = 0;
                }

                result += item;
                count++;
            }

            return result;
        }

        /// <summary>
        /// <para>DE: Fügt den Characterstring an der Indexposition abhängig von der position(Vor/Nach) ein.</para>
        /// <para>EN: Insert the charters before or after the indexposition.</para>
        /// </summary>
        /// <param name="_string">the _string</param>
        /// <param name="_index">indexposition</param>
        /// <param name="characters">characterString</param>
        /// <param name="position">position</param>
        /// <returns></returns>
        public static string AddCharacters(this string _string, int _index, string characters, InsertPosition position)
        {
            string result = "";

            for (int i = 0; i < _index; i++)
            {
                result += characters;
            }

            if (position == InsertPosition.After)
                result = _string + result;
            else
                result += _string;

            return result;
        }

        /// <summary>
        /// <para>DE: Fasst einen String in den übergebenen Char ein.</para>
        /// <para>EN: Quotes a string into specified char.</para>
        /// </summary>
        /// <param name="_string">the string</param>
        /// <param name="textbegrenzer">the quote char</param>
        /// <returns>the quoted string</returns>
        public static string ToQuoteString(this string _string, char textbegrenzer)
        {
            return StringFunctions.QuoteString(_string, textbegrenzer);
        }

        /// <summary>
        /// <para>DE: Normalisiert Zeilenumbrüche.</para>
        /// <para>EN: normalizes linebreaks.</para>
        /// </summary>
        /// <param name="_string">the string</param>
        /// <returns>normalized string</returns>
        public static string NormalizeLineBreaks(this string _string)
        {
            StringBuilder builder = new StringBuilder((int)(_string.Length * 1.1));

            bool lastWasCR = false;

            foreach (char c in _string)
            {
                if (lastWasCR)
                {
                    lastWasCR = false;
                    if (c == '\n')
                    {
                        continue;
                    }
                }
                switch (c)
                {
                    case '\r':
                        builder.Append("\r\n");
                        lastWasCR = true;
                        break;
                    case '\n':
                        builder.Append("\r\n");
                        break;
                    default:
                        builder.Append(c);
                        break;
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// <para>DE: Entfernt Zeilenumbrüche.</para>
        /// <para>EN: Removes linebreaks.</para>
        /// </summary>
        /// <param name="_string">The String</param>
        /// <returns>string without linebreaks</returns>
        public static string RemoveLineBreaks(this string _string)
        {
            return _string.Replace("\r\n", "");
        }

        #endregion

        #region Split

        /// <summary>
        /// <para>DE: Gibt eine Liste von Strings zurück die die geplitteten Teile des übergebenen Strings
        ///     enthält, der durch den separator getrennt wurde. Weitere Informationen siehe Parameter.</para>
        /// <para>EN: Returns a string array that contains the substrings in this _string that are delimited
        ///     by elements of a specified Unicode character array. A parameter specifies the maximum
        ///     number of substrings to return.</para>
        /// </summary>
        /// <param name="_string">The _string of the current string.</param>
        /// <param name="seperator">A unicode characters that delimit the substrings in this _string.</param>
        /// <returns>
        /// An array whose elements contain the substrings in this _string that are delimited by
        /// one or more characters in separator. For more information, see the Remarks section.
        /// </returns>
        public static List<string> Split(this string _string, char seperator)
        {
            return _string.Split(seperator.ToString(), int.MaxValue, StringSplitOptions.None);
        }

        /// <summary>
        /// <para>DE: Gibt eine Liste von Strings zurück die die geplitteten Teile des übergebenen Strings
        ///     enthält, der durch den separator getrennt wurde. Der Parameter count gibt die maximale
        ///     größe der Listeneinträge an. Weitere Informationen siehe Parameter.</para>
        /// <para>EN: Returns a string array that contains the substrings in this _string that are delimited
        ///     by elements of a specified Unicode character array. A parameter specifies the maximum
        ///     number of substrings to return.</para>
        /// </summary>
        /// <param name="_string">The _string of the current string.</param>
        /// <param name="seperator">A unicode characters that delimit the substrings in this _string.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <exception cref="ArgumentOutOfRangeException">The parameter count is negative.</exception>
        /// <returns>
        /// An array whose elements contain the substrings in this _string that are delimited by
        /// one or more characters in separator. For more information, see the Remarks section.
        /// </returns>
        public static List<string> Split(this string _string, char seperator, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "count is negative");
            }

            return _string.Split(seperator.ToString(), count, StringSplitOptions.None);
        }

        /// <summary>
        /// <para>DE: Gibt eine Liste von Strings zurück die die geplitteten Teile des übergebenen Strings
        ///     enthält, der durch den separator getrennt wurde. Der Parameter count gibt die maximale
        ///     größe der Listeneinträge an. Weitere Informationen siehe Parameter.</para>
        /// <para>EN: Returns a string array that contains the substrings in this _string that are delimited
        ///     by elements of a specified Unicode character array. A parameter specifies the maximum
        ///     number of substrings to return.</para>
        /// </summary>
        /// <param name="_string">The _string of the current string.</param>
        /// <param name="seperator">A unicode characters that delimit the substrings in this _string.</param>
        /// <param name="options">Specify System.StringSplitOptions.RemoveEmptyEntries to omit
        /// empty array elements from the array returned, or System.StringSplitOptions.None to
        /// include empty array elements in the array returned.</param>
        /// <exception cref="ArgumentException">The parameter options is not on of the <see cref="System.StringSplitOptions"/> values.</exception>
        /// <returns>
        /// An array whose elements contain the substrings in this _string that are delimited by
        /// one or more characters in separator. For more information, see the Remarks section.
        /// </returns>
        public static List<string> Split(this string _string, char seperator, StringSplitOptions options)
        {
            if ((options < StringSplitOptions.None)
            || (options > StringSplitOptions.RemoveEmptyEntries))
            {
                throw new ArgumentException(string.Format("option [{0}] is not one of the System.StringSplitOptions values.", options));
            }

            return _string.Split(seperator.ToString(), int.MaxValue, options);
        }

        /// <summary>
        /// <para>DE: Gibt eine Liste von Strings zurück die die geplitteten Teile des übergebenen Strings
        ///     enthält, der durch den separator getrennt wurde. Der Parameter count gibt die maximale
        ///     größe der Listeneinträge an. Weitere Informationen siehe Parameter.</para>
        /// <para>EN: Returns a string array that contains the substrings in this _string that are delimited
        ///     by elements of a specified Unicode character array. A parameter specifies the maximum
        ///     number of substrings to return.</para>
        /// </summary>
        /// <param name="_string">The _string of the current string.</param>
        /// <param name="seperator">A unicode characters that delimit the substrings in this _string.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <param name="options">Specify System.StringSplitOptions.RemoveEmptyEntries to omit
        /// empty array elements from the array returned, or System.StringSplitOptions.None to
        /// include empty array elements in the array returned.</param>
        /// <exception cref="ArgumentOutOfRangeException">The parameter count is negative.</exception>
        /// <exception cref="ArgumentException">The parameter options is not on of the <see cref="System.StringSplitOptions"/> values.</exception>
        /// <returns>
        /// An array whose elements contain the substrings in this _string that are delimited by
        /// one or more characters in separator. For more information, see the Remarks section.
        /// </returns>
        public static List<string> Split(this string _string, char seperator, int count, StringSplitOptions options)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "count is negative");
            }

            if ((options < StringSplitOptions.None)
            || (options > StringSplitOptions.RemoveEmptyEntries))
            {
                throw new ArgumentException(string.Format("option [{0}] is not one of the System.StringSplitOptions values.", options));
            }

            return _string.Split(seperator.ToString(), count, StringSplitOptions.None);
        }

        /// <summary>
        /// <para>DE: Gibt eine Liste von Strings zurück die die geplitteten Teile des übergebenen Strings
        ///     enthält, der durch den separator getrennt wurde. Der Parameter count gibt die maximale
        ///     größe der Listeneinträge an. Weitere Informationen siehe Parameter.</para>
        /// <para>EN: Returns a string array that contains the substrings in this _string that are delimited
        ///     by elements of a specified Unicode character array. A parameter specifies the maximum
        ///     number of substrings to return.</para>
        /// </summary>
        /// <param name="_string">The _string of the current string.</param>
        /// <param name="seperator">A unicode characters that delimit the substrings in this _string.</param>
        /// <exception cref="ArgumentNullException">The parameter seperator cannot be null.</exception>
        /// <returns>
        /// An array whose elements contain the substrings in this _string that are delimited by
        /// one or more characters in separator. For more information, see the Remarks section.
        /// </returns>
        public static List<string> Split(this string _string, string seperator)
        {
            if (seperator == null)
            {
                throw new ArgumentNullException("seperator", "Parameter seperator cannot be null!");
            }

            return _string.Split(seperator, int.MaxValue, StringSplitOptions.None);
        }

        /// <summary>
        /// <para>DE: Gibt eine Liste von Strings zurück die die geplitteten Teile des übergebenen Strings
        ///     enthält, der durch den separator getrennt wurde. Der Parameter count gibt die maximale
        ///     größe der Listeneinträge an. Weitere Informationen siehe Parameter.</para>
        /// <para>EN: Returns a string array that contains the substrings in this _string that are delimited
        ///     by elements of a specified Unicode character array. A parameter specifies the maximum
        ///     number of substrings to return.</para>
        /// </summary>
        /// <param name="_string">The _string of the current string.</param>
        /// <param name="seperator">A unicode characters that delimit the substrings in this _string.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <exception cref="ArgumentNullException">The parameter seperator cannot be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The parameter count is negative.</exception>
        /// <returns>
        /// An array whose elements contain the substrings in this _string that are delimited by
        /// one or more characters in separator. For more information, see the Remarks section.
        /// </returns>
        public static List<string> Split(this string _string, string seperator, int count)
        {
            if (seperator == null)
            {
                throw new ArgumentNullException("seperator", "Parameter seperator cannot be null!");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "count is negative");
            }

            return _string.Split(seperator, count, StringSplitOptions.None);
        }

        /// <summary>
        /// <para>DE: Gibt eine Liste von Strings zurück die die geplitteten Teile des übergebenen Strings
        ///     enthält, der durch den separator getrennt wurde. Der Parameter count gibt die maximale
        ///     größe der Listeneinträge an. Weitere Informationen siehe Parameter.</para>
        /// <para>EN: Returns a string array that contains the substrings in this _string that are delimited
        ///     by elements of a specified Unicode character array. A parameter specifies the maximum
        ///     number of substrings to return.</para>
        /// </summary>
        /// <param name="_string">The _string of the current string.</param>
        /// <param name="seperator">A unicode characters that delimit the substrings in this _string.</param>
        /// <param name="options">Specify System.StringSplitOptions.RemoveEmptyEntries to omit
        /// empty array elements from the array returned, or System.StringSplitOptions.None to
        /// include empty array elements in the array returned.</param>
        /// <exception cref="ArgumentNullException">The parameter seperator cannot be null.</exception>
        /// <exception cref="ArgumentException">The parameter options is not on of the <see cref="System.StringSplitOptions"/> values.</exception>
        /// <returns>
        /// An array whose elements contain the substrings in this _string that are delimited by
        /// one or more characters in separator. For more information, see the Remarks section.
        /// </returns>
        public static List<string> Split(this string _string, string seperator, StringSplitOptions options)
        {
            if (seperator == null)
            {
                throw new ArgumentNullException("seperator", "Parameter seperator cannot be null!");
            }

            if ((options < StringSplitOptions.None)
            || (options > StringSplitOptions.RemoveEmptyEntries))
            {
                throw new ArgumentException(string.Format("option [{0}] is not one of the System.StringSplitOptions values.", options));
            }

            return _string.Split(seperator, int.MaxValue, options);
        }

        /// <summary>
        /// <para>DE: Gibt eine Liste von Strings zurück die die geplitteten Teile des übergebenen Strings
        ///     enthält, der durch den separator getrennt wurde. Der Parameter count gibt die maximale
        ///     größe der Listeneinträge an. Weitere Informationen siehe Parameter.</para>
        /// <para>EN: Returns a string array that contains the substrings in this _string that are delimited
        ///     by elements of a specified Unicode character array. A parameter specifies the maximum
        ///     number of substrings to return.</para>
        /// </summary>
        /// <param name="_string">The _string of the current string.</param>
        /// <param name="seperator">A unicode characters that delimit the substrings in this _string.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <param name="options">Specify System.StringSplitOptions.RemoveEmptyEntries to omit
        /// empty array elements from the array returned, or System.StringSplitOptions.None to
        /// include empty array elements in the array returned.</param>
        /// <exception cref="ArgumentNullException">The parameter seperator cannot be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The parameter count is negative.</exception>
        /// <exception cref="ArgumentException">The parameter options is not on of the <see cref="System.StringSplitOptions"/> values.</exception>
        /// <returns>
        /// An array whose elements contain the substrings in this _string that are delimited by
        /// one or more characters in separator. For more information, see the Remarks section.
        /// </returns>
        public static List<string> Split(this string _string, string seperator, int count, StringSplitOptions options)
        {
            if (seperator == null)
            {
                throw new ArgumentNullException("seperator", "Parameter seperator cannot be null!");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "count is negative");
            }

            if ((options < StringSplitOptions.None)
            || (options > StringSplitOptions.RemoveEmptyEntries))
            {
                throw new ArgumentException(string.Format("option [{0}] is not one of the System.StringSplitOptions values.", options));
            }

            if (count == int.MaxValue)
            {
                return new List<string>(_string.Split(new string[] { seperator }, options));
            }
            else
            {
                return new List<string>(_string.Split(new string[] { seperator }, count, options));
            }
        }

        #endregion

        #region Crypto

        /// <summary>
        /// <para>DE: Wandelt einen string in einen MD5 String</para>
        /// <para>EN: Parse a string to MD5.</para>
        /// </summary>
        /// <param name="_string">The _string.</param>
        /// <returns>Returns the string as MD5 string.</returns>
        public static string ToMD5HashString(this string _string)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider provider
                = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] bytes = Encoding.UTF8.GetBytes(_string);
            StringBuilder builder = new StringBuilder();

            bytes = provider.ComputeHash(bytes);

            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2").ToLower(CultureInfo.CurrentCulture));
            }

            return builder.ToString();
        }

        /// <summary>
        /// <para>DE: Kovertiert den <see cref="_string"/> in einen MD5Hash als Guid</para>
        /// <para>EN: Converts the <see cref="_string"/> to MD5Hash</para>
        /// </summary>
        /// <param name="_string"></param>
        /// <returns></returns>
        public static Guid ToMD5Hash(this string _string)
        {
            MD5CryptoServiceProvider md5cryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] bytes = Encoding.UTF8.GetBytes(_string);
            bytes = md5cryptoServiceProvider.ComputeHash(bytes);

            return new Guid(bytes);
        }

        #endregion

        #region Other

        /// <summary>
        /// <para>DE: Kopiert den string in die Zwischenablage.</para>
        /// <para>EN: Copys the string into clipboard.</para>
        /// </summary>
        /// <param name="_string">the string</param>
        public static void ToClipboard(this string _string)
        {
            System.Windows.Forms.Clipboard.SetDataObject(_string, true);
        }

        /// <summary>
        /// <para>DE: Trimt einen String, auch wenn er null sein sollte</para>
        /// <para>EN: Trims a string, equal if it's null or not</para>
        /// </summary>
        /// <param name="_string">The String</param>
        /// <returns>Returns a trimmed string, or null, if the _string was null.</returns>
        public static string NullTrim(this string _string)
        {
            if (!_string.IsNullOrWhiteSpace())
            {
                return _string.Trim();
            }
            else
            {
                return _string;
            }
        }

        /// <summary>
        /// <para>DE: Manuelle Zeilenumbruchberechnung für eigene Controls</para>
        /// <para>EN: Manual wordwrapcalculation for own controls</para>
        /// </summary>
        /// <param name="_string">the specified string</param>
        /// <param name="hwndHandle">hwnd Handle of the control</param>
        /// <param name="font">the font</param>
        /// <param name="lineBreak">the linebreak string</param>
        /// <param name="maxWidthPixels">max pixel widht</param>
        /// <returns>wrapped text</returns>
        public static string WrapText(this string _string, IntPtr hwndHandle, Font font, string lineBreak, float maxWidthPixels)
        {
            List<string> wordwrapped = new List<string>();

            Graphics graphics = Graphics.FromHwnd(hwndHandle);

            string currentLine = string.Empty;

            for (int i = 0; i < _string.Length; i++)
            {
                char currentChar = _string[i];
                currentLine += currentChar;
                if (graphics.MeasureString(currentLine, font).Width > maxWidthPixels)
                {
                    int moveback = 0;
                    while (currentChar != ' ')
                    {
                        moveback++;
                        i--;

                        if (i < 0)
                        {
                            i = moveback - 1;
                            break;
                        }
                        else
                            currentChar = _string[i];
                    }

                    if (moveback != currentLine.Length)
                    {
                        string lineToAdd = currentLine.Substring(0, currentLine.Length - moveback);
                        wordwrapped.Add(lineToAdd);
                        currentLine = string.Empty;
                    }
                    else
                    {
                        string lineToAdd = currentLine.Substring(0, currentLine.Length);
                        wordwrapped.Add(lineToAdd);
                        currentLine = string.Empty;
                    }
                }
            }

            string result = "";

            foreach (string line in wordwrapped)
                result += line + lineBreak;

            if (_string.Length > result.Replace(lineBreak, "").Length)
            {
                result += _string.Replace(result.Replace(lineBreak, ""), "");
            }

            return result;
        }

        /// <summary>
        ///<para>DE: Löscht alle Ungültigen Zeichen aus dem String so das man den String als Dateiname benutzen kann</para>
        ///<para>EN: Convert the string to a valid Filename</para>
        /// Info  fnName      : DateiName + Ext                   <--- den bekomme ich übergeben
        ///      (fnFileName  : Laufwerk + Ordner + DateiName + Ext
        ///       fnPath      : Laufwerk + Ordner mit '\' am Ende
        ///       fnExt       : Ext mit '.' vorne
        ///       fnOnlyName  : DateiName ohne Ext)
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        public static string ToFileName(this string _string)
        {
            //CSetOfChar setof = new CSetOfChar("()-+& _[]=ÄÜÖß,.%$", 'A', 'Z', '0', '9');

            string regExPattern = @"[^0-9A-Za-z.,+\-/()%=ÄÜÖß$\[\]\&_\ ]";

            foreach (Match match in Regex.Matches(_string, regExPattern))
                _string = _string.Replace(match.Value, "_");

            return _string;
        }

        #endregion

        #region SEPA
        /// <summary>
        /// <para>DE: Kovertiert SEPA ungültige Zeichen in SEPA gültige Zeichen</para>
        /// <para>EN: Convert the _string into SEPA-conform string.</para>
        /// </summary>
        /// <param name="_string">the specified _string</param>
        /// <returns>sepa-conform string</returns>
        public static string ToSEPAConformString(this string _string)
        {
            string regExPattern = @"[^0-9A-Za-z.,?+\-:/()\ ]";

            _string = _string.Replace("Ü", "Ue");
            _string = _string.Replace("ü", "ue");

            _string = _string.Replace("Ö", "Oe");
            _string = _string.Replace("ö", "oe");

            _string = _string.Replace("Ä", "Ae");
            _string = _string.Replace("ä", "ae");

            _string = _string.Replace("ß", "ss");

            _string = _string.Replace("&", "+");

            foreach (Match match in Regex.Matches(_string, regExPattern))
                _string = _string.Replace(match.Value, " ");

            return _string;
        }

        /// <summary>
        /// <para>DE: Kopieren, auch über Zeilenende hinweg. Sollte der Quellstring kürzer sein als StartIndex + Länge, wird nur der Rest zurückgegeben.</para>
        /// <para>EN: Copys the sting over the end of line. If the given string is shorter than startindex + length, then it returns just the rest.</para>
        /// </summary>
        /// <param name="_string">the string</param>
        /// <param name="startIndex">startposition for the copy</param>
        /// <param name="length">count of chars that should be copied</param>
        /// <returns>copied string</returns>
        public static string SubstringCopy(this String _string, int startIndex, int length)
        {
            return StringFunctions.Copy(_string, startIndex, length);
        }
        #endregion
    }

    public enum InsertPosition
    {
        Before,
        After
    }
}
