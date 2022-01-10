namespace TryConvertDemo
{
    using System;

    using TryConvertLibrary.Core;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string result = TryConvert.ToString(0);
            Console.ReadKey();
        }
    }
}
