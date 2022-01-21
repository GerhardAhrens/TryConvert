//-----------------------------------------------------------------------
// <copyright file="SafeEnumBase.cs" company="PTA GmbH">
//     Class: SafeEnumBase
//     Copyright © PTA GmbH 2021
// </copyright>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>20.07.2021</date>
//
// <summary>
// Base Class for Alternate Enum-Class
// </summary>
//-----------------------------------------------------------------------

namespace TryConvertLibrary.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public abstract class SafeEnumBase<TTyp, TClass> 
    {
        public TTyp Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public static IReadOnlyList<TClass> GetValues()
        {
            return typeof(TClass).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(property => (TClass)property.GetValue(null))
                .ToList();
        }

        public override string ToString() => this.Name;
    }
}
