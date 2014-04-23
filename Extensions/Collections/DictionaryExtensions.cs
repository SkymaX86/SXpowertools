using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXpowertools.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// <para>DE: Fügt mehrere Items auf einmal der Instanz des Dictionarys hinzu.</para>
        /// <para>EN: Add a range of items to the instance of this dictionary</para>
        /// </summary>
        /// <typeparam name="TKey">The key type of the dictionary.</typeparam>
        /// <typeparam name="TValue">The value type of the dictionary.</typeparam>
        /// <param name="instance">The instance of the dictionary.</param>
        /// <param name="list">The dictionary to add.</param>
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> instance, Dictionary<TKey, TValue> list)
        {
            foreach (KeyValuePair<TKey, TValue> item in list)
            {
                instance.Add(item.Key, item.Value);
            }
        }

        /// <summary>
        /// <para>DE: Entfernt mehrere Items auf einmal aus Instanz des Dictionarys.</para>
        /// <para>EN: Remove a range of items from the instance of this dictionary</para>
        /// </summary>
        /// <typeparam name="TKey">The key type of the dictionary.</typeparam>
        /// <typeparam name="TValue">The value type of the dictionary.</typeparam>
        /// <param name="instance">The instance of the dictionary.</param>
        /// <param name="list">The dictionary to remove.</param>
        public static void RemoveRange<TKey, TValue>(this Dictionary<TKey, TValue> instance, Dictionary<TKey, TValue> list)
        {
            foreach (KeyValuePair<TKey, TValue> item in list)
            {
                instance.Remove(item.Key);
            }
        }

        /// <summary>
        /// <para>DE: Gibt einen spezifischen Eintrag anhand des übergeben Index zurück</para>
        /// <para>EN: Get an entry from a specific index</para>
        /// </summary>
        /// <typeparam name="TKey">The key type of the dictionary.</typeparam>
        /// <typeparam name="TValue">The value type of the dictionary.</typeparam>
        /// <param name="instance">The instance of the dictionary.</param>
        /// <param name="index">The index of the target object.</param>
        /// <returns>Returns a entry of the dictionary from a specific index.</returns>
        public static KeyValuePair<TKey, TValue> FromIndex<TKey, TValue>(this Dictionary<TKey, TValue> instance, int index)
        {
            if (instance != null && instance.Count > 0)
            {
                int count = 0;

                foreach (KeyValuePair<TKey, TValue> item in instance)
                {
                    if (index == count)
                    {
                        return item;
                    }

                    count++;
                }

                return default(KeyValuePair<TKey, TValue>);
            }
            else
            {
                return default(KeyValuePair<TKey, TValue>);
            }
        }
    }
}
