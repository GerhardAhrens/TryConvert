//-----------------------------------------------------------------------
// <copyright file="TryConvert.cs" company="Lifeprojects.de">
//     Class: TryConvert
//     Copyright © Lifeprojects.de 2022
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>10.01.2022 17:32:34</date>
//
// <summary>
// Klasse zur Typen Konvertierung in String
// </summary>
//-----------------------------------------------------------------------

namespace TryConvertLibrary.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public partial class TryConvert
    {
        public static string ToString(List<string> value, char separator)
        {
            return string.Join(separator,value);
        }

        public static string ToString(IEnumerable<string> value, char separator)
        {
            return string.Join(separator, value);
        }

        public static string ToString<TKey, TValue>(Dictionary<TKey,TValue> value, char separator = ';')
        {
            return value.Select(x => x.Key + "=" + x.Value).Aggregate((s1, s2) => $"{s1}{separator}{s2}");
        }

        public static string ToCapitalize(string value)
        {
            return ToCapitalize(value, CultureInfo.CurrentCulture);
        }

        public static string ToCapitalize(string value, CultureInfo culture)
        {
            culture.IsArgumentNull(nameof(culture));

            if (string.IsNullOrEmpty(value) == true)
            {
                return string.Empty;
            }

            if (value.Length == 0)
            {
                return string.Empty;
            }

            TextInfo textInfo = culture.TextInfo;

            return textInfo.ToTitleCase(value);
        }

        public static string ToCapitalizeWords(string value, params string[] dontCapitalize)
        {
            char[] delimiter = new char[] { ' ', '.', '-' };
            var split = value.Split(delimiter);
            for (int i = 0; i < split.Length; i++)
            {
                split[i] = i == 0
                  ? ToCapitalize(split[i])
                  : dontCapitalize.Contains(split[i])
                     ? split[i]
                     : ToCapitalize(split[i]);
            }

            return string.Join(" ", split);
        }
    }
}
