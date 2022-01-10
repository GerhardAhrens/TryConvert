//-----------------------------------------------------------------------
// <copyright file="ITryConvert.cs" company="Lifeprojects.de">
//     Class: ITryConvert
//     Copyright © Lifeprojects.de yyyy
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>dd.MM.yyyy</date>
//
// <summary>
// Interface Klasse für TryConvert
// </summary>
//-----------------------------------------------------------------------


namespace TryConvertLibrary.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITryConvert
    {
        object Value { get; set; }
    }
}
