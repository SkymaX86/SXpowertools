using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SXpowertools.Extensions
{
    public static class EnumExtensions
    {
        #region Wird nur bei Localized Enums benötigt
        #region Declarations / Fields

        /// <summary>
        /// <para>DE: Eine Mögliche implementation für localisation</para>
        /// <para>EN: An oportunity for enumLocalizations</para>
        /// </summary>
        private static List<KeyValuePair<string, string>> enumLocalizations;

        private static bool initialized;

        #endregion

        #region Properties

        /// <summary>
        /// <para>DE: Gibt zurück <see cref="EnumExtensions"/> ob initialisiert ist.</para>
        /// <para>EN: Gets a value indicating whether this <see cref="EnumExtensions"/> is initialized.</para>
        /// </summary>
        /// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
        public static bool Initialized
        {
            get { return initialized; }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// <para>DE: Initialsiert die classe mit den vordefinierten Localizations.</para>
        /// <para>EN: Initializes this class with predefined enum localizations.</para>
        /// </summary>
        /// <param name="localizations">The localizations.</param>
        public static void Initialize(List<KeyValuePair<string, string>> localizations)
        {
            enumLocalizations = localizations;
            initialized = true;
        }

        #endregion
        #endregion

        #region Enum helper methods

        /// <summary>
        /// <para>DE: Wandelt den übergebenen String in den dazugehörigen EnumValue.</para>
        /// <para>EN: Parses the specified string into the corresponding enum value.</para>
        /// </summary>
        /// <typeparam name="T">The resulting <see cref="Enum"/> type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T Parse<T>(string value)
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
                throw new ArgumentException("GetEnumValues supports only enum types.");

            var typeName = enumType.FullName + ".";

            if (enumLocalizations != null)
            {
                var query = enumLocalizations.Where(e => e.Value == value && e.Key.StartsWith(typeName) &&
                               e.Key.LastIndexOf(".") == typeName.Length - 1).Select(e => e.Key).FirstOrDefault();
                if (query != null)
                    return (T)Enum.Parse(enumType, query.Replace(typeName, ""));
            }

            return (T)Enum.Parse(enumType, value);
        }

        /// <summary>
        /// <para>DE: Liefert die Namen für den <see cref="Enum"/> als Dictionary. Namen werden lokalisiert wenn eine Lokalisation verfügbar ist.</para>
        /// <para>EN: Gets the values and names for the <see cref="Enum"/> as a dictionary. The names will be localized if localized versions are available.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IDictionary<int, string> GetEnumValues<T>()
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
                throw new ArgumentException("GetEnumValues supports only enum types.");

            //get the available values of the enum
            var values = (T[])Enum.GetValues(enumType);

            var enumValues = new Dictionary<int, string>(values.Length);

            for (var i = 0; i < values.Length; i++)
            {
                var localizedEnum = Localize(values[i] as Enum);
                enumValues.Add(Convert.ToInt32(values.GetValue(i)), localizedEnum);
            }

            return enumValues;
        }

        /// <summary>
        /// <para>DE: Wandelt den übergebenen String anhand des EnumValueDataAttribute in den dazugehörigen EnumValue.</para>
        /// <para>EN: Parses the specified string using the EnumValueDataAttribute into the corresponding enum value.</para>
        /// </summary>
        /// <typeparam name="T">The resulting <see cref="Enum"/> type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T ParseNameValue<T>(string value)
        {
            var enumType = typeof(T);

            if (!enumType.IsEnum)
                throw new ApplicationException("ParseListName does not support non-enum types");

            foreach (FieldInfo field in enumType.GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public))
            {
                foreach (Attribute currAttr in field.GetCustomAttributes(true))
                {
                    EnumValueDataAttribute valueAttribute = currAttr as EnumValueDataAttribute;

                    if (valueAttribute != null)
                    {
                        if (valueAttribute.Name == value && valueAttribute.Show)
                            return (T)Enum.Parse(enumType, field.Name);
                    }
                }
            }

            return (T)Enum.Parse(enumType, value);
        }

        /// <summary>
        /// <para>DE: Liefert die Namen aus dem EnumValueDataAttribute für den <see cref="Enum"/> als Dictionary.</para>
        /// <para>EN: Gets the values and names from the EnumValueDataAttribute for the <see cref="Enum"/> as a dictionary.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IDictionary<int, string> GetEnumNameValues<T>()
        {
            var enumType = typeof(T);

            if (!enumType.IsEnum)
                throw new ApplicationException("GetEnumListValues does not support non-enum types");

            Dictionary<int, string> list = new Dictionary<int, string>();

            foreach (FieldInfo field in enumType.GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public))
            {
                int value;
                string display;
                value = (int)field.GetValue(null);
                display = Enum.GetName(enumType, value);
                foreach (Attribute currAttr in field.GetCustomAttributes(true))
                {
                    EnumValueDataAttribute valueAttribute = currAttr as EnumValueDataAttribute;
                    if (valueAttribute != null)
                    {
                        if (valueAttribute.Show)
                            display = valueAttribute.Name;
                        else
                            display = "";
                    }
                }
                if (display != "")
                    list.Add(value, display);
            }

            return list;
        }

        #endregion

        #region Enum extension methods

        /// <summary>
        /// <para>DE: Liefert den lokalisierten Namen für den <see cref="Enum"/> Value. Wenn keine Lokalisazion existiert wird der reguläre Name zurückgegeben</para>
        /// <para>EN: Gets the localized name for the current <see cref="Enum"/> value. If no localized name exists, the enums regular name will be returned.</para>
        /// </summary>
        /// <param name="enumType">The enum value.</param>
        /// <returns></returns>
        public static string Localize(this Enum enumType)
        {
            if (enumLocalizations != null)
            {
                var enumKey = enumType.GetType().FullName + "." + enumType;
                if (enumLocalizations.Exists(e => e.Key == enumKey))
                    return enumLocalizations.First(e => e.Key == enumKey).Value;
            }

            return enumType.ToString();
        }

        /// <summary>
        /// <para>DE: Liefert den Namen aus dem EnumValueDataAttribute für den <see cref="Enum"/> als string.</para>
        /// <para>EN: Get the name from the EnumValueDataAttribute for the <see cref="Enum"/> as a string.</para>
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string GetEnumNameValue(this Enum enumType)
        {
            var type = enumType.GetType();

            FieldInfo fieldInfo = type.GetField(enumType.ToString());
            foreach (Attribute currAttr in fieldInfo.GetCustomAttributes(true))
            {
                if (((EnumValueDataAttribute)currAttr) != null)
                    return ((EnumValueDataAttribute)currAttr).Name;
            }
            return enumType.ToString();
        }

        /// <summary>
        /// Dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        static public Dictionary<string, object> ToDictionary<T>(this Enum e)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            foreach (int s in Enum.GetValues(typeof(T)))
            {
                dict.Add(Enum.GetName(typeof(T), s), s);
            }

            return dict;
        }

        #endregion
    }

    /// <summary>
    /// <para>Mithilfe dieses Attributes ist es möglich zusätzlich einen String für einen Enum zu hinterlegen.</para>
    /// <para>Die Eigenschaft Show wird beim holen aller EnumValues berücksichtigt. Steht Show auf False taucht der Eintrag nicht auf.</para>
    /// <para> </para>
    /// <example>
    /// <code>
    /// <para>public enum SalutationTypes</para>
    /// <para>{</para>
    /// <para>  [EnumValueData(Name = "None", Show=false)]</para>
    /// <para>  None = 0,</para>
    /// <para> </para>
    /// <para>  [EnumValueData(Name = "Herr/ Frau")]</para>
    /// <para>  HerrFrau = 1,</para>
    /// <para> </para>
    /// <para>  [EnumValueData(Name = "Herr")]</para>
    /// <para>  Herr = 2,</para>
    /// <para> </para>
    /// <para>  [EnumValueData(Name = "Frau")]</para>
    /// <para>  Frau = 3,</para>
    /// <para> </para>
    /// <para>  [EnumValueData(Name = "Firma")]</para>
    /// <para>  Firma = 4,</para>
    /// <para> </para>
    /// <para>  [EnumValueData(Name = "Doktor")]</para>
    /// <para>  Dr = 5,</para>
    /// <para>}</para>
    /// </code>
    /// </example>
    /// <para> </para>
    /// <para>Die Funktion <see cref="GetEnumNameValues"/> würde folgende Liste ausgeben:</para>
    /// <para>  Herr/ Frau</para>
    /// <para>  Herr</para>
    /// <para>  Frau</para>
    /// <para>  Firma</para>
    /// <para>  Doktor</para>
    /// </summary>
    public class EnumValueDataAttribute : Attribute
    {
        private string _name;
        private bool _show = true;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool Show
        {
            get { return _show; }
            set { _show = value; }
        }
    }
}
