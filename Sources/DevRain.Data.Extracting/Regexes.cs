// ============================================================================
// <copyright file="Regexes.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting
{

    /// <summary>
    /// Class holds common regexes.
    /// </summary>
    public static class Regexes
    {
        /// <summary>
        /// Email regex.
        /// </summary>
        public const string Email = @"[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)";

        /// <summary>
        /// Email regex used in .NET 1.1.
        /// </summary>
        private const string EmailDotNet11 = @"^(([^<>()[\]\\.,;:\s@\""]+"
                    + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                    + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                    + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                    + @"[a-zA-Z]{2,}))$";

        /// <summary>
        /// IP regex.
        /// </summary>
        public const string IP = @"\d\d?\d?\.\d\d?\d?\.\d\d?\d?\.\d\d?\d?";

        /// <summary>
        /// Caps words regex.
        /// "This IS a Test OF ALL Caps";
        /// </summary>
        public const string CapsWord = @"(\b[^\Wa-z0-9_]+\b)";

        /// <summary>
        /// Url regex.
        /// </summary>
        public const string Url = @"(ht|f)tp(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?";
        //^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$

        /// <summary>
        /// Extract data in format "N/N/N H:M:S AM/PM"
        /// <example>01/02/2008 5:20:50 PM.</example>
        /// </summary>
        public const string DateTimeLong = @"(?x)(?i)(\d{1,4}) [./-](\d{1,2}) [./-](\d{1,4}) [\sT]  (\d+):(\d+):(\d+) \s? (A\.?M\.?|P\.?M\.?)?";

        /// <summary>
        /// Phone regex.
        /// </summary>
        public const string Phone = @"(?x)( \d{3}[-\s] | \(\d{3}\)\s? )\d{3}[-\s]?\d{4}";

        /// <summary>
        /// Number regex.
        /// </summary>
        public static string Number = @"(\d+\.?\d*|\.\d+)";

        #region Single-line regexes

        /// <summary>
        /// Keyword = Value regex.
        /// <example>"myval = 3" is valid.</example>
        /// </summary>
        public const string KeyValuePair = @"(\w+)\s*=\s*(.*)\s*$";

        /// <summary>
        /// Validates the format, type, and length of the supplied input field. The input must consist of 3 numeric characters followed by a dash, then 2 numeric characters followed by a dash, and then 4 numeric characters.
        /// <example>"111-11-1111" is valid.</example>
        /// </summary>
        public const string SocialSecurityNumber = @"^\d{3}-\d{2}-\d{4}$";

        /// <summary>
        /// Validates a strong password. It must be between 8 and 10 characters, contain at least one digit and one alphabetic character, and must not contain special characters.
        /// </summary>
        public const string StrongPassword = @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$";

        /// <summary>
        /// Validates that the field contains an integer greater than zero.
        /// </summary>
        public const string NonNegativeInteger  = @"^\d+$";

        /// <summary>
        /// Validates a U.S. ZIP Code. The code must consist of 5 or 9 numeric characters.
        /// </summary>
        public const string ZipCode = @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$";

        /// <summary>
        /// Roman numbers regex.
        /// <example>vii</example>
        /// </summary>
        public const string RomanNumber = "^m*(d?c{0,3}|c[dm])(l?x{0,3}|x[lc])(v?i{0,3}|i[vx])$";

        /// <summary>
        /// Regex for C style comments.
        /// <example>
        /// /*
        ///  * this is an old cstyle comment block
        ///  */
        /// </example>
        /// </summary>
        public const string CStyleComments = @"
  /\*  # match the opening delimiter
  .*?	 # match a minimal numer of chracters
  \*/	 # match the closing delimiter
";

        //http://msdn.microsoft.com/en-us/library/ff650303.aspx
        //http://tim.oreilly.com/pub/a/oreilly/windows/news/csharp_0101.html

        #endregion

        
    }
}
