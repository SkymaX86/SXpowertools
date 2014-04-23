using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SXpowertools.Util
{
    public static class StringFunctions
    {
        /// <summary>
        /// <para>DE: Kopieren, auch über Zeilenende hinweg. Sollte der Quellstring kürzer sein als StartIndex + Länge, wird nur der Rest zurückgegeben.</para>
        /// <para>EN: Copys the sting over the end of line. If the given string is shorter than startindex + length, then it returns just the rest.</para>
        /// </summary>
        /// <param name="s">Der ganze String</param>
        /// <param name="startIndex">Position, ab der kopiert werden soll. Beginnt bei 0</param>
        /// <param name="length">Anzahl Zeichen, die kopiert werden sollen</param>
        /// <returns>:string Teilstring</returns>
        public static string Copy(string s, int startIndex, int length)
        {
            if (s == null)
                return "";
            if (startIndex >= s.Length)
                return "";
            if (s.Length >= (startIndex + length))
                return s.Substring(startIndex, length);
            else
                return s.Substring(startIndex, s.Length - startIndex);

        }

        /// <summary>
        /// <summary>
        /// <para>DE: Kopieren, auch über Zeilenende hinweg. Sollte der Quellstring kürzer sein als StartIndex + Länge, wird nur der Rest zurückgegeben.</para>
        /// <para>EN: Copys the sting over the end of line. If the given string is shorter than startindex + length, then it returns just the rest.</para>
        /// </summary>
        /// <param name="s">Quellestring befindet sich immStringBuilder</param>
        /// <param name="startIndex">Position, ab der kopiert werden soll. Beginnt bei 0</param>
        /// <param name="length">Anzahl Zeichen, die kopiert werden sollen</param>
        /// <returns>:string Teilstring</returns>
        public static string Copy(StringBuilder sb, int startIndex, int length)
        {
            if (startIndex >= sb.Length)
                return "";
            if (sb.Length >= (startIndex + length))
                return sb.ToString(startIndex, length);
            else
                return sb.ToString(startIndex, sb.Length - startIndex);
        }

        /// <summary>
        /// <para>DE: Konvertiert mir ein String im yyMMdd Format in ein Datum um, bei Fehler wird 01.01.0001 zurückgegeben.</para>
        /// <para>EN: Converts a string with format yyMMdd to date, on error it returns the date 01.01.0001.</para>
        /// </summary>
        /// <param name="sJJMMTT">the string yyMMdd</param>
        /// <returns>the Date</returns>
        public static DateTime yyMMdd_ToDate(string yyMMdd)
        {
            int jj;
            int mm;
            int tt;

            if(yyMMdd.Length > 6)
                return DateTime.MinValue;

            try
            {
                jj = Convert.ToInt32(StringFunctions.Copy(yyMMdd, 0, 2)) + 2000;
                mm = Convert.ToInt32(StringFunctions.Copy(yyMMdd, 2, 2));
                tt = Convert.ToInt32(StringFunctions.Copy(yyMMdd, 4, 2));
                return new DateTime(jj, mm, tt);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// <para>DE: Konvertiert mir ein String im yyyyMMdd Format in ein Datum um, bei Fehler wird 01.01.0001 zurückgegeben.</para>
        /// <para>EN: Converts a string with format yyyyMMdd to date, on error it returns the date 01.01.0001.</para>
        /// </summary>
        /// <param name="sJJMMTT">the string yyMMdd</param>
        /// <returns>the Date</returns>
        public static DateTime yyyyMMdd_ToDate(string yyyyMMdd)
        {
            int jjjj;
            int mm;
            int tt;

            if (yyyyMMdd.Length > 8)
                return DateTime.MinValue;

            try
            {
                jjjj = Convert.ToInt32(StringFunctions.Copy(yyyyMMdd, 0, 4));
                mm = Convert.ToInt32(StringFunctions.Copy(yyyyMMdd, 4, 2));
                tt = Convert.ToInt32(StringFunctions.Copy(yyyyMMdd, 6, 2));
                return new DateTime(jjjj, mm, tt);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// <para>DE: Löscht alle Chars in der Liste aus dem String</para>
        /// <para>EN: Remove all chars in the chararray from the string</para>
        /// </summary>
        /// <param name="s">String, in dem gelöscht wird</param>
        /// <param name="c">Liste mit den zu löschenden Zeichen</param>
        /// <returns>Übrig gebliebener String</returns>
        public static string DeleteCharSet(string s, char[] c)
        {
            for (int n = 0; n < c.Length; n++)
            {
                s = s.Replace(Convert.ToString(c[n]), "");
            }
            return s;
        }

        /// <summary>
        /// <para>DE: Füllt den String rechts mit Zeichen bis zur angegebenen Länge auf</para>
        /// <para>EN: Pad right with the given char up to the given lenght</para>
        /// </summary>
        /// <param name="s">Quellstring</param>
        /// <param name="c">Füllzeichen</param>
        /// <param name="iLen">Länge</param>
        /// <returns>Der aufgefüllte String</returns>
        public static string FillCharRight(string s, char c, int length)
        {
            if (s.Length < length)
                return s + new string(c, length - s.Length);
            else
                return s;
        }

        /// <summary>
        /// <para>DE: Füllt den String links mit Zeichen bis zur angegebenen Länge auf</para>
        /// <para>EN: Pad left with the given char up to the given lenght</para>
        /// </summary>
        /// <param name="s">Quellstring</param>
        /// <param name="c">Füllzeichen</param>
        /// <param name="iLen">Länge</param>
        /// <returns>Der aufgefüllte String</returns>
        public static string FillCharLeft(string s, char c, int length)
        {
            if (s.Length < length)
                return new string(c, length - s.Length) + s;
            else
                return s;
        }

        /// <summary>
        /// <para>DE: Liefert einen String zurück indem evtl. Textbegrenzer (z.B. ") verdoppelt werden</para>
        /// <para>EN: Returns a quoted string</para>
        /// </summary>
        /// <param name="sQuelle"></param>
        /// <param name="cTextbegrenzer"></param>
        /// <returns></returns>
        public static string QuoteString(string s, char textbegrenzer)
        {
            StringBuilder sb = new StringBuilder(s.Length + 2);
            sb.Append(textbegrenzer);                          // erste zeichen links
            foreach (char c in s)
            {
                if (c == textbegrenzer)                          // wenn das Zeichen ein Quote, dann verdoppeln
                    sb.Append(textbegrenzer);

                sb.Append(c);
            }
            sb.Append(textbegrenzer);
            return sb.ToString();
        }
    }
}
