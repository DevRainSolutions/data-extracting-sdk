// ============================================================================
// <copyright file="EnumDescriptionAttribute.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================
namespace DevRain.Data.Extracting
{
    using System;
    using System.Reflection;

    /// <summary>
    /// EnumDescriptionAttribute attribute is used for Enums description.
    /// </summary>
    public sealed class EnumDescriptionAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// Gets or sets a string value for enum item.
        /// </summary>
        public string StringValue { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used tpublic const string init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public EnumDescriptionAttribute(string value)
        {
            this.StringValue = value;
        }

        #endregion
    }

    /// <summary>
    /// Extensions for Enums.
    /// </summary>
    public static class ExtentionUtils
    {
        /// <summary>
        /// Will get the string value for a given enums value, this will
        /// only work if you assign the StringValue attribute to
        /// the items in your enum.
        /// </summary>
        /// <param name="value">Enum's value.</param>
        /// <returns>Enum's string value.</returns>
        public static string GetStringValue(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            
            // Get the type
            Type type = value.GetType();

            // Get field info for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the string value attributes
            var attribs = fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false) as EnumDescriptionAttribute[];

            // Return the first if there was a match.
            return attribs != null && attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }

    /// <summary>
    /// Web page header types
    /// </summary>
    public enum HeaderTypes
    {
        /// <summary>
        /// H1.
        /// </summary>
        H1,

        /// <summary>
        /// H2.
        /// </summary>
        H2,
        /// <summary>
        /// H3.
        /// </summary>
        H3,

        /// <summary>
        /// H4.
        /// </summary>
        H4,

        /// <summary>
        /// H5.
        /// </summary>
        H5,

        /// <summary>
        /// H6.
        /// </summary>
        H6
    }


   /// <summary>
   /// Http methods enumeration.
   /// </summary>
    public enum HttpMethods
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// GET method.
        /// </summary>
        GET,

        /// <summary>
        /// POST method.
        /// </summary>
        POST
    }

    /// <summary>
    /// Bound types enumeration.
    /// </summary>
    public enum BoundTypes
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// Save before type.
        /// </summary>
        SaveBefore,

        /// <summary>
        /// Save after type.
        /// </summary>
        SaveAfter,

        /// <summary>
        /// Save both type.
        /// </summary>
        SaveBoth
    }

    /// <summary>
    /// Data types enumeration.
    /// </summary>
    [Flags]
    public enum DataTypes
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Email data type.
        /// </summary>
        [EnumDescription(Regexes.Email)]
        Email = 1,

        /// <summary>
        /// IP data type.
        /// </summary>
        [EnumDescription(Regexes.IP)]
        IP = 2,

        /// <summary>
        /// Phone data type.
        /// </summary>
        [EnumDescription(Regexes.Phone)]
        Phone = 4,

        [EnumDescription(Regexes.CapsWord)]
        CapsWord = 8,

        [EnumDescription(Regexes.Url)]
        Url = 16,

        [EnumDescription(Regexes.DateTimeLong)]
        DateTimeLong = 32,

        /// <summary>
        /// All data types.
        /// </summary>
        All = Email | IP | Phone | CapsWord | Url | DateTimeLong 
    }

    /// <summary>
    /// Text sources enumeration.
    /// </summary>
    public enum TextSources {
        
        /// <summary>
        /// Text source.
        /// </summary>
        Text,

        /// <summary>
        /// Html source.
        /// </summary>
        Html
    }

    /// <summary>
    /// Search engines enumeration.
    /// </summary>
    public enum SearchEngines
    {
        /// <summary>
        /// Google search engine. 
        /// <see>http://google.com/</see>
        /// </summary>
        Google,

        /// <summary>
        /// Yandex search engine.
        /// <see>http://yandex.ru/</see>
        /// </summary>
        Yandex,

        /// <summary>
        /// Bing search engine.
        /// <see>http://bing.com/</see>
        /// </summary>
        Bing
    }

    /// <summary>
    /// Image sizes enumeration.
    /// </summary>
    public enum ImageSizeTypes
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Very small size.
        /// </summary>
        VerySmall = 1,

        /// <summary>
        /// Small size.
        /// </summary>
        Small = 3,

        /// <summary>
        /// Middle size.
        /// </summary>
        Middle = 5,

        /// <summary>
        /// Big size.
        /// </summary>
        Big = 10,

        /// <summary>
        /// Very big size.
        /// </summary>
        VeryBig = 15
    }

    public enum Browsers { 
        IE6,
        IE7,
        IE8,
        IE9,
        FF3,
        FF4,
        Chrome,
        Safari,
        Opera
    }

    public enum TextFormats { 
        Text,
        HTML
    }
}
