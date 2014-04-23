using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXpowertools.Extensions
{
    public static class Int32Extensions
    {
        /// <summary>
        /// <para>DE: Überprüft ob _int32 eine Primzahl ist</para>
        /// <para>EN: Checks if a number is a prim number</para>
        /// </summary>
        /// <param name="_int32">The number to check.</param>
        /// <returns>Returns a value that indicates if the number is a prim number.</returns>
        public static bool IsPrimeNumber(this int _int32)
        {
            if (_int32 < 2)
            {
                return false;
            }

            if (_int32 % 2 == 0)
            {
                return false;
            }

            int upperBorder = (int)System.Math.Round(System.Math.Sqrt(_int32), 0);

            for (int i = 3; i <= upperBorder; i = i + 2)
            {
                if (_int32 % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// <para>DE: Gibt die nächste Primzahl zurück</para>
        /// <para>EN: Get the next prim number</para>
        /// </summary>
        /// <param name="_int32">The int _int32.</param>
        /// <returns>Returns the next prime number.</returns>
        public static int NextPrimNumber(this int _int32)
        {
            int chk = _int32 + 1;

            while (!chk.IsPrimeNumber())
            {
                chk++;
            }

            return chk;
        }

        /// <summary>
        /// <para>DE: Gibt die vorherige Primzahl zurück</para>
        /// <para>EN: Get the previous prim number</para>
        /// </summary>
        /// <param name="_int32">The int _int32.</param>
        /// <returns>Returns the previous prime number.</returns>
        public static int PreviousPrimNumber(this int _int32)
        {
            int chk = _int32 - 1;

            while (!chk.IsPrimeNumber())
            {
                chk--;
            }

            return chk;
        }

        /// <summary>
        /// <para>DE: Gibt den übergebenen _int32 als Datetime.Years zurück</para>
        /// <para>EN: Returns a datetime representation of the integer as years</para>
        /// </summary>
        /// <param name="_int32">The integer _int32.</param>
        /// <returns>Returns a datetime _int32 representating the current value as years.</returns>
        public static DateTime Years(this int _int32)
        {
            return DateTime.MinValue.AddYears(_int32 - 1);
        }

        /// <summary>
        /// <para>DE: Gibt den übergebenen _int32 als DateTime.Month zurück</para>
        /// <para>EN: Returns a datetime representation of the integer as months</para>
        /// </summary>
        /// <param name="_int32">The integer _int32.</param>
        /// <returns>Returns a datetime _int32 representating the current value as months.</returns>
        public static DateTime Months(this int _int32)
        {
            return DateTime.MinValue.AddMonths(_int32 - 1);
        }

        /// <summary>
        /// <para>DE: Gibt den übergebenen _int32 als DateTime.Weeks zurück</para>
        /// <para>EN: Returns a timespan representation of the integer as weeks</para>
        /// </summary>
        /// <param name="_int32">The integer _int32.</param>
        /// <returns>Returns a timespan _int32 representating the current value as weeks.</returns>
        public static TimeSpan Weeks(this int _int32)
        {
            return new TimeSpan((_int32 * 7), 0, 0, 0);
        }

        /// <summary>
        /// <para>DE: Gibt den übergebenen _int32 als DateTime.Days zurück</para>
        /// <para>EN: Returns a timespan representation of the integer as days</para>
        /// </summary>
        /// <param name="_int32">The integer _int32.</param>
        /// <returns>Returns a timespan _int32 representating the current value as days.</returns>
        public static TimeSpan Days(this int _int32)
        {
            return new TimeSpan(_int32, 0, 0, 0);
        }

        /// <summary>
        /// <para>DE: Gibt den übergebenen _int32 als DateTime.Hours zurück</para>
        /// <para>EN: Returns a timespan representation of the integer as hours</para>
        /// </summary>
        /// <param name="_int32">The integer _int32.</param>
        /// <returns>Returns a timespan _int32 representating the current value as hours.</returns>
        public static TimeSpan Hours(this int _int32)
        {
            return new TimeSpan(_int32, 0, 0);
        }

        /// <summary>
        /// <para>DE: Gibt den übergebenen _int32 als DateTime.Minutes zurück</para>
        /// <para>EN: Returns a timespan representation of the integer as minutes</para>
        /// </summary>
        /// <param name="_int32">The integer _int32.</param>
        /// <returns>Returns a timespan _int32 representating the current value as minutes.</returns>
        public static TimeSpan Minutes(this int _int32)
        {
            return new TimeSpan(0, _int32, 0);
        }

        /// <summary>
        /// <para>DE: Gibt den übergebenen _int32 als DateTime.Seconds zurück</para>
        /// <para>EN: Returns a timespan representation of the integer as seconds</para>
        /// </summary>
        /// <param name="_int32">The integer _int32.</param>
        /// <returns>Returns a timespan _int32 representating the current value as seconds.</returns>
        public static TimeSpan Seconds(this int _int32)
        {
            return new TimeSpan(0, 0, _int32);
        }

        /// <summary>
        /// <para>DE: Gibt den übergebenen _int32 als DateTime.Milliseconds zurück</para>
        /// <para>EN: Returns a timespan representation of the integer as milliseconds</para>
        /// </summary>
        /// <param name="_int32">The integer _int32.</param>
        /// <returns>Returns a timespan _int32 representating the current value as milliseconds.</returns>
        public static TimeSpan Milliseconds(this int _int32)
        {
            return new TimeSpan(0, 0, 0, 0, _int32);
        }

        /// <summary>
        /// <para>DE: Kopiert den _int32 als string in die Zwischenablage.</para>
        /// <para>EN: Copys the _int32 as string into clipboard.</para>
        /// </summary>
        /// <param name="_int"></param>
        public static void ToClipboard(this int _int32)
        {
            System.Windows.Forms.Clipboard.SetDataObject(_int32.ToString(), true);
        }
    }
}
