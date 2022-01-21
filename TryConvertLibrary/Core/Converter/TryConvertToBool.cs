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
    using System.Globalization;
    using System.Linq;

    public partial class TryConvert
    {
        /// <summary>
        /// Es wird geprüft ob der übergebene String einem Bool-Wert entspricht<br/>
        /// Gültige Werte für True: 1,y,yes,true,ja, j, wahr<br/>
        /// Gültige Werte für False: 0,n,no,false,nein,falsch<br/>
        /// Groß- und Kleinschrebung wird ignoriert<br/>
        /// </summary>
        /// <param name="this">Übergebener String</param>
        /// <param name="ignorException">True = es wird keine Exception bei einem falschen Wert ausgelöst,<br/>False = Es wird eine InvalidCastException alsgelöst bei einem Fehler</param>
        /// <returns>Wenn der Wert einem entsprechendem Bool-Wert entspricht, wird True oder False zurückgegeben.</returns>
        public static bool ToBool(string @this, bool ignorException = false)
        {
            string[] trueStrings = { "1", "y", "yes", "true", "ja", "j", "wahr" };
            string[] falseStrings = { "0", "n", "no", "false", "nein", "falsch" };

            if (string.IsNullOrEmpty(@this) == true)
            {
                return false;
            }

            if (trueStrings.Contains(@this.ToString(), StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }

            if (falseStrings.Contains(@this.ToString(), StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            if (ignorException == true)
            {
                return false;
            }
            else
            {
                string msg = "only the following are supported for converting strings to boolean: ";
                throw new InvalidCastException($"{msg} {string.Join(",", trueStrings)} and {string.Join(",", falseStrings)}");
            }
        }
    }
}
