using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXpowertools.Extensions
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// <para>DE: Gibt den Wert der true(1) oder false (0) beschreibt zurück</para>
        /// <para>EN: Gets a value that describes a true (1) and a false (0) value</para>
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static int ToInt32(this bool instance)
        {
            return (instance ? 1 : 0);
        }
    }
}
