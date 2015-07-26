namespace Telerik.ILS.Common
{
    /// <summary>
    /// Namespace contains class for string extenshions.
    /// </summary>
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The StringExtensions class. Consists of methods which handle string manipulations and string extensions.
    /// </summary>
    public static class TelerikStringExtensions
    {
        /// <summary>
        /// The ToMd5Hash method. Takes an ordinary string and converts it to its hexidecimal equivalent.
        /// This is done by first converting it to a byte array and computing the hash. Afterwards, the hashed
        /// data is stored in a StringBuilder and looped through to format the hexidecimal string.
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <returns>Returns hexidecimal string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// The ToBoolean method. Checks if the string input is one of the following: 
        ///  "true", "ok", "yes", "1", "да".
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <returns>Boolean value of the input string.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// The toShort method. Converts an appropriate string to its equivalent short value type.
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <returns>Short value of the input string.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// The ToInteger method. Tries to convert input string to integer form.
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <returns>Integer value of the input string.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// The ToLong method. Tries to convert the input string to long type form. 
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <returns>Long value of the input string.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// The ToDateTime method. Tries to convert the input string to DateTime format.
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <returns>DateTime value of the input string.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// The CapitalizeFirstLetter method. Capitalizes the first letter of the input string.
        /// If input is null or empty, the method will return nothing.
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <returns>Capitalized string value of the input string.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// The GetStringBetween method. If no startString and endString parameters passed, method will return empty
        /// string. In case of invalid input, empty string is also returned. The return value will be a substring
        /// of the input.
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <param name="startString">Starting string to look for.</param>
        /// <param name="endString">Ending string to look for.</param>
        /// <param name="startFrom">Index to start looking from.</param>
        /// <returns>Substring created from input with specified startString and endString.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// The ConvertCyrillicToLatinLetters method. Converts every Cyrillic letter of the input string to its
        /// equivalent Latin letter.
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <returns>String consisting of only Latin letters.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// The ConvertLatinToCyrillicKeyboard method. Converts each Latin letter of the input string to
        /// its equivalent Bulgarian keyboard representation.
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <returns>Bulgarian keyboard representation string of the input.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// The ToValidUsername method. Checks if the input username is valid. All Cyrillic letters
        /// are replaced with their Latin equivalent and forbidden symbols are removed.
        /// </summary>
        /// <param name="input">Username variable of type string.</param>
        /// <returns>Valid username of type string.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// The ToValidLatinFileName method. Produces a valid Latin file name from the input by 
        /// converting Cyrillic to Latin letters.
        /// </summary>
        /// <param name="input">String file name.</param>
        /// <returns>Valid Latin file name.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// The GetFirstCharacters method. Returns a substring with length equal to the specified charsCount variable value.
        /// </summary>
        /// <param name="input">Primitive type string.</param>
        /// <param name="charsCount">The number of characters to be taken from the beginning of the input.</param>
        /// <returns>The first characters of the input.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// The GetFileExtension method. Returns the file extension of the given filename.
        /// </summary>
        /// <param name="fileName">The string (filename) the method is called upon.</param>
        /// <returns>The file extension of the filename</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// The ToContentType. Returns the content type of a file depending on its extension.
        /// </summary>
        /// <param name="fileExtension">The file extension</param>
        /// <returns>The content type associated with the given file extension</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// The ToByteArray method. Converts a string into an array of bytes
        /// </summary>
        /// <param name="input">The string the method is called upon</param>
        /// <returns>An array of bytes derived from converting every character 
        /// in the given string to its byte representation</returns>
        /// <exception cref="OverflowException">The array is multidimensional and contains more than 
        /// <see cref="F:System.Int32.MaxValue" /> elements.</exception>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}