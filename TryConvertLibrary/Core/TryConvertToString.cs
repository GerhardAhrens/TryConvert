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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;



    public partial class TryConvert
    {
        public static string ToString(int value)
        {
            return value.ToString();
        }

        public static string ToString(int value, string format)
        {
            if (string.IsNullOrEmpty(format) == false)
            {
                return value.ToString(format);
            }
            else
            {
                return value.ToString();
            }
        }

        public static string ToString(int value, string format = "", IFormatProvider provider = null)
        {
            if (string.IsNullOrEmpty(format) == false)
            {
                if (provider == null)
                {
                    return value.ToString(format);
                }
                else
                {
                    return value.ToString(format, provider);
                }
            }
            else
            {
                if (provider == null)
                {
                    return value.ToString();
                }
                else
                {
                    return value.ToString(provider);
                }
            }
        }

        public static string ToString(long value, IFormatProvider provider = null)
        {
            return default;
        }
    }
}
