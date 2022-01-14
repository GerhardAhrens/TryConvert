//-----------------------------------------------------------------------
// <copyright file="TryConvert.cs" company="Lifeprojects.de">
//     Class: TryConvert
//     Copyright � Lifeprojects.de 2022
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
        /// Es wird gepr�ft ob der �bergebene String einem Bool-Wert entspricht<br/>
        /// G�ltige Werte f�r True: 1,y,yes,true,ja, j, wahr<br/>
        /// G�ltige Werte f�r False: 0,n,no,false,nein,falsch<br/>
        /// Gro�- und Kleinschrebung wird ignoriert<br/>
        /// </summary>
        /// <param name="this">�bergebener String</param>
        /// <param name="ignorException">True = es wird keine Exception bei einem falschen Wert ausgel�st,<br/>False = Es wird eine InvalidCastException alsgel�st bei einem Fehler</param>
        /// <returns>Wenn der Wert einem entsprechendem Bool-Wert entspricht, wird True oder False zur�ckgegeben.</returns>
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
