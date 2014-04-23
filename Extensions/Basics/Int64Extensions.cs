using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXpowertools.Extensions
{
    public static class Int64Extensions
    {
        /// <summary>
        /// <para>DE: Überprüft ob _int64 eine Primzahl ist</para>
        /// <para>EN: Checks if a number is a prim number</para>
        /// </summary>
        /// <param name="_int64">The number to check.</param>
        /// <returns>Returns a value that indicates if the number is a prim number.</returns>
        public static bool IsPrimeNumber(this long _int64)
        {
            if (_int64 < 2)
            {
                return false;
            }

            if (_int64 % 2 == 0)
            {
                return false;
            }

            long upperBorder = (long)System.Math.Round(System.Math.Sqrt(_int64), 0);

            for (long i = 3; i <= upperBorder; i = i + 2)
            {
                if (_int64 % i == 0)
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
        /// <param name="_int64">The int _int64.</param>
        /// <returns>Returns the next prime number.</returns>
        public static long NextPrimNumber(this long _int64)
        {
            long chk = _int64 + 1;

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
        /// <param name="_int64">The int _int64.</param>
        /// <returns>Returns the previous prime number.</returns>
        public static long PreviousPrimNumber(this long _int64)
        {
            long chk = _int64 - 1;

            while (!chk.IsPrimeNumber())
            {
                chk--;
            }

            return chk;
        }

        /// <summary>
        /// <para>DE: Kopiert den int_64 als string in die Zwischenablage.</para>
        /// <para>EN: Copys the _int64 as string into clipboard.</para>
        /// </summary>
        /// <param name="_int"></param>
        public static void ToClipboard(this long _int64)
        {
            System.Windows.Forms.Clipboard.SetDataObject(_int64.ToString(), true);
        }
    }
}
