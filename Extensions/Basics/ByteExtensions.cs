using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SXpowertools.Extensions
{
    public static class ByteExtensions
    {
        /// <summary>
        /// <para>DE: Konvertiert die übergebene Instanz eines Bytearrays in einen Ascii String</para>
        /// <para>EN: Converts the instance of this byte array to an converted ascii string</para>
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string ToAsciiString(this byte[] instance)
        {
            ASCIIEncoding enc = new ASCIIEncoding();
            return enc.GetString(instance);
        }

        /// <summary>
        /// <para>DE: Konvertiert das übergebene Bytearray in einen einfachen String.</para>
        /// <para>EN: Converts the instance of this byte array to an simple string.</para>
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="instance">Instance.</param>
        public static string ToString(this byte[] instance)
        {
            char[] chars = new char[instance.Length / sizeof(char)];
            System.Buffer.BlockCopy(instance, 0, chars, 0, instance.Length);
            return new string(chars);
        }

        /// <summary>
        /// <para>DE: Konvertiert das übergebene Bytearray in einen Stream.</para>
        /// <para>EN: Converts the instance of this byte array to a stream.</para>
        /// </summary>
        /// <param name="instance">The instance of the byte array.</param>
        /// <returns>A stream with the byte array as content.</returns>
        public static Stream ToStream(this byte[] instance)
        {
            MemoryStream memStream = new MemoryStream(instance);
            return memStream;
        }
    }
}
