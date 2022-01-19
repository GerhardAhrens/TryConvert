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
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public partial class TryConvert
    {
        public static string ToString(List<string> value, char separator)
        {
            return string.Join(separator,value);
        }

        public static string ToString(IEnumerable<string> value, char separator)
        {
            return string.Join(separator, value);
        }

        public static string ToString<TKey, TValue>(Dictionary<TKey,TValue> value, char separator = ';')
        {
            return value.Select(x => x.Key + "=" + x.Value).Aggregate((s1, s2) => $"{s1}{separator}{s2}");
        }

        public static string ToString(ITuple value, char separator = ';')
        {
            var result = new List<object>(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                result.Add(value[i].ToString());
            }

            return string.Join(separator, result);
        }

        public static string ToCapitalize(string value)
        {
            return ToCapitalize(value, CultureInfo.CurrentCulture);
        }

        public static string ToCapitalize(string value, CultureInfo culture)
        {
            culture.IsArgumentNull(nameof(culture));

            if (string.IsNullOrEmpty(value) == true)
            {
                return string.Empty;
            }

            if (value.Length == 0)
            {
                return string.Empty;
            }

            TextInfo textInfo = culture.TextInfo;

            return textInfo.ToTitleCase(value);
        }

        public static string ToCapitalizeWords(string value, params string[] dontCapitalize)
        {
            char[] delimiter = new char[] { ' ', '.', '-' };
            var split = value.Split(delimiter);
            for (int i = 0; i < split.Length; i++)
            {
                split[i] = i == 0
                  ? ToCapitalize(split[i])
                  : dontCapitalize.Contains(split[i])
                     ? split[i]
                     : ToCapitalize(split[i]);
            }

            return string.Join(" ", split);
        }

        /// <summary>
        /// Konvertiert den Wert dieser Instanz in seine äquivalente String-Darstellung
        /// <br>Sprachabhängig in Deutsch oder englisch (entweder "Ja/Yes" oder "Nein/No").</br>
        /// </summary>
        /// <param name="">bool Value</param>
        /// <returns>string</returns>
        public static string ToYesNoString(bool @this)
        {
            if (CultureInfo.CurrentCulture.Name == "de-DE")
            {
                return @this ? "Ja" : "Nein";
            }
            else
            {
                return @this ? "Yes" : "No";
            }
        }

        /// <summary>
        /// Konvertiert den Wert dieser Instanz in seine äquivalente String-Darstellung
        /// <br>Sprachabhängig in Deutsch oder englisch (entweder "Ja/Yes" oder "Nein/No")</br>
        /// <br>unter Berücksichtigung der übergeben Cultur.</br>
        /// </summary>
        /// <param name="this">bool Value</param>
        /// <param name="cultureInfo">Current CultureInfo</param>
        /// <returns></returns>
        public static string ToYesNoString(bool @this, CultureInfo cultureInfo)
        {
            if (cultureInfo.Name == "de-DE")
            {
                return @this ? "Ja" : "Nein";
            }
            else
            {
                return @this ? "Yes" : "No";
            }
        }

        public static string ToCamelCase(string @this)
        {
            if (string.IsNullOrEmpty(@this) == true)
            {
                return string.Empty;
            }

            if (@this.Length < 2)
            {
                return @this;
            }

            string[] words = @this.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            string result = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                result += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
            }

            return result;
        }

        public static string ToPascalCase(string @this)
        {
            if (string.IsNullOrEmpty(@this) == true)
            {
                return string.Empty;
            }

            if (@this.Length <= 2)
            {
                return @this.ToUpper();
            }

            string[] words = @this.ToLower().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            string result = "";
            foreach (string word in words)
            {
                result += word.Substring(0, 1).ToUpper() + word.Substring(1);
            }

            return result;
        }

        public static string ToProperCase(string @this)
        {
            if (string.IsNullOrEmpty(@this) == true)
            {
                return string.Empty;
            }

            if (@this.Length <= 2)
            {
                return @this.ToUpper();
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(@this);
        }

        public static string ToInitials(string @this, bool withNumber = true)
        {
            if (string.IsNullOrEmpty(@this) == true)
            {
                return "??";
            }

            // first remove all: punctuation, separator chars, control chars, and numbers (unicode style regexes)
            string initials = Regex.Replace(@this, @"[\p{P}\p{S}\p{C}]+", "");

            if (withNumber == true)
            {
                initials = Regex.Replace(initials, @"[\p{N}]+", "");
            }

            // Replacing all possible whitespace/separator characters (unicode style), with a single, regular ascii space.
            initials = Regex.Replace(initials, @"\p{Z}+", " ");

            // Remove all Sr, Jr, I, II, III, IV, V, VI, VII, VIII, IX at the end of names
            initials = Regex.Replace(initials.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);

            // Extract up to 2 initials from the remaining cleaned name.
            initials = Regex.Replace(initials, @"^(\p{L})[^\s]*(?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L}*)?)?$", "$1$2").Trim();

            if (initials.Length > 2)
            {
                // Worst case scenario, everything failed, just grab the first two letters of what we have left.
                initials = initials.Substring(0, 2);
            }

            return initials.ToUpperInvariant();
        }

        public static string ToInitials(string @this, int MaxLength = 3)
        {
            char space = ' ';

            if (string.IsNullOrEmpty(@this))
            {
                return @this;
            }


            StringBuilder sb = new StringBuilder();
            string[] words = @this.Split(space);

            if (words.Length <= 3)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    sb.Append(words[i].Substring(0, 1));
                }
            }
            else
            {

            }

            return sb.ToString().ToUpper();
        }

        public string EncryptToBase64(string originalText, string password = "Lifeprojects.de")
        {
            string result = string.Empty;

            try
            {
                byte[] userBytes = Encoding.UTF8.GetBytes(originalText); // UTF8 saves Space
                byte[] userHash = MD5.Create().ComputeHash(userBytes);
                SymmetricAlgorithm crypt = Aes.Create(); // (Default: AES-CCM (Counter with CBC-MAC))
                crypt.Key = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password)); // MD5: 128 Bit Hash
                crypt.IV = new byte[16]; // by Default. IV[] to 0.. is OK simple crypt
                using var memoryStream = new MemoryStream();
                using var cryptoStream = new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(userBytes, 0, userBytes.Length); // User Data
                cryptoStream.Write(userHash, 0, userHash.Length); // Add HASH
                cryptoStream.FlushFinalBlock();
                result = Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public string DecryptFromBase64(string encryptedText, string password = "Lifeprojects.de")
        {
            string result = string.Empty;

            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                SymmetricAlgorithm crypt = Aes.Create();
                crypt.Key = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
                crypt.IV = new byte[16];
                using var memoryStream = new MemoryStream();
                using var cryptoStream = new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                cryptoStream.FlushFinalBlock();
                var allBytes = memoryStream.ToArray();
                var userLen = allBytes.Length - 16;

                if (userLen < 0)
                {
                    throw new Exception("Invalid Len");   // No Hash?
                }

                var userHash = new byte[16];
                Array.Copy(allBytes, userLen, userHash, 0, 16); // Get the 2 Hashes
                var decryptHash = MD5.Create().ComputeHash(allBytes, 0, userLen);
                if (userHash.SequenceEqual(decryptHash) == false)
                {
                    throw new Exception("Invalid Hash");
                }

                result = Encoding.UTF8.GetString(allBytes, 0, userLen);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
