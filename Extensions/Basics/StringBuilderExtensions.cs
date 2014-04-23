using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SXpowertools.Util;

namespace SXpowertools.Extensions
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// DE: Leert die übergebene Instanz
        /// EN: Clears the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public static void Clear(this StringBuilder _stringBuilder)
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
        }

        /// <summary>
        /// <para>DE: Kopieren, auch über Zeilenende hinweg. Sollte der Quellstring kürzer sein als StartIndex + Länge, wird nur der Rest zurückgegeben.</para>
        /// <para>EN: Copys the sting over the end of line. If the given string is shorter than startindex + length, then it returns just the rest.</para>
        /// </summary>
        /// <param name="_stringBuilder">the stringbuilder</param>
        /// <param name="startIndex">startposition for the copy</param>
        /// <param name="length">count of chars that should be copied</param>
        /// <returns>copied string</returns>
        public static string SubstringCopy(this StringBuilder _stringBuilder, int startIndex, int length)
        {
            return StringFunctions.Copy(_stringBuilder, startIndex, length);
        }
    }
}
