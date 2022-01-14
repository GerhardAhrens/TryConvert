namespace TryConvertDemo
{
    using System;
    using System.Collections.Generic;

    using TryConvertLibrary.Core;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<int,string> dict = new Dictionary<int, string>() 
            {
                { 1, "value1" },
                { 2, "value2" }
            };

            string text = TryConvert.ToString<int,string>(dict);

            string t1 = TryConvert.ToCapitalize("test");

            string t2 = TryConvert.ToCapitalizeWords("test.hallo.Test", "hallo");

            Console.ReadKey();
        }
    }
}
