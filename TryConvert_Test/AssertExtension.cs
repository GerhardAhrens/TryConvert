namespace TryConvert_Test
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public static class AssertExtension
    {
        public static bool CompareContent<TTyp>(this Assert @this,TTyp object1, TTyp object2)
        {
            Type type = typeof(TTyp);

            if (object1 == null || object2 == null)
            {
                return false;
            }

            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.Name != "ExtensionData")
                {
                    string object1Value = string.Empty;
                    string object2Value = string.Empty;

                    if (type.GetProperty(property.Name).GetValue(object1, null) != null)
                    {
                        object1Value = type.GetProperty(property.Name).GetValue(object1, null).ToString();
                    }

                    if (type.GetProperty(property.Name).GetValue(object2, null) != null)
                    {
                        object2Value = type.GetProperty(property.Name).GetValue(object2, null).ToString();
                    }

                    if (object1Value.Trim() != object2Value.Trim())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static T Throws<T>(Action expressionUnderTest,
                                  string exceptionMessage = "Expected exception has not been thrown by target of invocation."
                                 ) where T : Exception
        {
            try
            {
                expressionUnderTest();
            }
            catch (T exception)
            {
                return exception;
            }

            Assert.Fail(exceptionMessage);
            return null;
        }

        public static bool GreaterZero(this Assert @this, object input) 
        {
            bool result = false;

            if (input is float n1)
            {
                result = n1 > 0 ? true : false;
            }
            else if (input is double n2)
            {
                result = n2 > 0 ? true : false;
            }
            else if (input is decimal n3)
            {
                result = n3 > 0 ? true : false;
            }
            else if (input is int n4)
            {
                result = n4 > 0 ? true : false;
            }
            else if (input is long n5)
            {
                result = n5 > 0 ? true : false;
            }
            else
            {
                throw new ArgumentException($"Für 'input' muß ein nummerischer Typ verwendet werden. Übergebener Typ ist: {input.GetType().Name}");
            }

            return result;
        }

        public static void CountGreaterZero<Ttype>(this Assert @this, object input)
        {
            bool result = false;
            string typeAsText = string.Empty;

            if (input == null)
            {
                return;
            }

            if (IsEnumerable<Ttype>(input) == true)
            {
                typeAsText = "IEnumerable";
                IEnumerable<Ttype> collection = (IEnumerable<Ttype>)input;
                if (collection.Count() > 0)
                {
                    result = true;
                }
            }
            else if (IsIDictionary(input) == true)
            {
                typeAsText = "Dictionary";
                int count = ((IDictionary)input).Values.Count;
                if (count > 0)
                {
                    result = true;
                }
            }
            else if (IsList(input) == true)
            {
                typeAsText = "List";
                int count = ((IList)input).Count;
                if (count > 0)
                {
                    result = true;
                }
            }

            if (result == true)
            {
                return;
            }

            throw new AssertFailedException($"{typeAsText }<{typeof(Ttype).Name}> == 0");
        }

        public static void HaveCount<Ttype>(this Assert @this, object input, int equalCount)
        {
            bool result = false;
            string typeAsText = string.Empty;

            if (input == null)
            {
                return;
            }

            if (IsEnumerable<Ttype>(input) == true)
            {
                typeAsText = "IEnumerable";
                IEnumerable<Ttype> collection = (IEnumerable<Ttype>)input;
                if (collection.Count() == equalCount)
                {
                    result = true;
                }
            }
            else if (IsIDictionary(input) == true)
            {
                typeAsText = "IDictionary";
                int count = ((IDictionary)input).Values.Count;
                if (count == equalCount)
                {
                    result = true;
                }
            }
            else if (IsList(input) == true)
            {
                typeAsText = "List";
                int count = ((IList)input).Count;
                if (count == equalCount)
                {
                    result = true;
                }
            }

            if (result == true)
            {
                return;
            }

            throw new AssertFailedException($"{typeAsText }<{typeof(Ttype).Name}> != {equalCount}");
        }

        public static void StringEquals(this Assert @this, string expected, string actual)
        {
            if (expected.Equals(actual) == true)
            {
                return;
            }

            throw new AssertFailedException(GetMessage(expected, actual));
        }

        public static void StringContains(this Assert @this, string expected, string actual)
        {
            if (expected.Contains(actual) == true)
            {
                return;
            }

            throw new AssertFailedException(GetMessage(expected, actual));
        }

        public static void StringNotEquals(this Assert @this, string expected, string actual)
        {
            if (expected.Equals(actual) == false)
            {
                return;
            }

            throw new AssertFailedException(GetMessage(expected, actual));
        }

        private static string GetMessage(string expected, string actual)
        {
            var expectedFormat = ReplaceInvisibleCharacters(expected);
            var actualFormat = ReplaceInvisibleCharacters(actual);

            // Get the index of the first different character
            var index = expectedFormat.Zip(actualFormat, (c1, c2) => c1 == c2).TakeWhile(b => b).Count();
            var caret = new string(' ', index) + "^";

            return $@"Strings are differents.
                        Expect: <{expectedFormat}>
                        Actual: <{actualFormat}>
                                 {caret}";
        }

        private static string ReplaceInvisibleCharacters(string value)
        {
            return value
                .Replace(' ', '·')
                .Replace('\t', '→')
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");
        }

        public static bool IsList(object testedObject)
        {
            Type t = testedObject.GetType();
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>);
        }

        public static bool IsEnumerable<T>(object testedObject)
        {
            return (testedObject is IEnumerable<T>);
        }

        private static bool IsIDictionary(object testedObject)
        {
            Type t = testedObject.GetType();
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>);
        }
    }
}