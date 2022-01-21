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
    using System.Linq;

    public partial class TryConvert
    {
        /// <summary>
        /// Map Properties von Object TInput auf ein neues Object TResult
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value">Object</param>
        /// <returns>Ergebnis nach dem mappen</returns>
        public static TResult ToMap<TInput, TResult>(TInput value) where TResult : class, new()
        {
            var result = new TResult();
            typeof(TInput).GetProperties().ToList().ForEach(p =>
            {
                var property = typeof(TResult).GetProperty(p.Name);
                if (property != null)
                {
                    property.SetValue(result, p.GetValue(value));
                }
            });

            return result;
        }
    }
}
