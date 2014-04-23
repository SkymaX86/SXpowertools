using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXpowertools.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// <para>DE: Hole ein Item anhand des index.</para>
        /// <para>EN: Grap an item from the specified instance and index.</para>
        /// </summary>
        /// <param name='instance'>The instance of the list.</param>
        /// <param name='index'>The index from which are to grap.</param>
        /// <typeparam name='T'>The 1st type parameter.</typeparam>
        public static T Grap<T>(this List<T> instance, int index)
        {
            try
            {
                if (index < instance.Count)
                {
                    T item = instance[index];

                    instance.Remove(item);

                    return item;
                }
                else
                {
                    return default(T);
                }
            }
            catch
            {
                throw new IndexOutOfRangeException(
                    "The index {0} is out of range.".FormatIt(index)
                );
            }
        }
    }
}
