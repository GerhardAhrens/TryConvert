//-----------------------------------------------------------------------
// <copyright file="UnitTestClass1.cs" company="Lifeprojects.de">
//     Class: UnitTestClass1
//     Copyright © Lifeprojects.de 2022
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>21.01.2022 19:56:14</date>
//
// <summary>
// Klasse für 
// </summary>
//-----------------------------------------------------------------------

namespace TryConvert_Test.ToString
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TryConvertLibrary.Core;

    [TestClass]
    public class ToString_Test
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToString_Test"/> class.
        /// </summary>
        public ToString_Test()
        {
        }

        [TestMethod]
        public void ToStringFromDictionary()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>()
            {
                { 1, "value1" },
                { 2, "value2" }
            };

            string result = TryConvert.ToString(dict);
            Assert.IsTrue(result == "1=value1;2=value2");
        }

        [DataRow("", "")]
        [TestMethod]
        public void DataRowInputTest(string input, string expected)
        {
        }

        [TestMethod]
        public void ExceptionTest()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(Exception));
            }
        }
    }
}
