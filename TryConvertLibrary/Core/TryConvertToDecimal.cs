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
        /// A Decimal extension method that converts the @this to a money.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a Decimal.</returns>
        public static decimal ToMoney(decimal @this)
        {
            return Math.Round(@this, 2);
        }

        /// <summary>
        /// A Decimal extension method that converts the @this to a money.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="decimals">Count decimals</param>
        /// <returns>@this as a Decimal.</returns>
        public static decimal ToMoney(decimal @this, int decimals)
        {
            return Math.Round(@this, decimals);
        }

        /// <summary>
        /// A Double extension method that converts the @this to a Decimal
        /// </summary>
        /// <param name="this"></param>
        /// <returns>@this as a Decimal.</returns>
        public static decimal ToDecimal(double @this)
        {
            return Convert.ToDecimal(@this);
        }

        /// <summary>
        /// A Double extension method that converts the @this to a money.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a Decimal.</returns>
        public static decimal ToMoney(double @this)
        {
            double result = Math.Round(@this, 2);
            return Convert.ToDecimal(result);
        }

        /// <summary>
        /// A Double extension method that converts the @this to a money.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="decimals">Count decimals</param>
        /// <returns>@this as a Decimal.</returns>
        public static decimal ToMoney(double @this, int decimals)
        {
            double result = Math.Round(@this, decimals);
            return Convert.ToDecimal(result);
        }
    }
}
