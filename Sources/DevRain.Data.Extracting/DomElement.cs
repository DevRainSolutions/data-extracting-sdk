// ============================================================================
// <copyright file="DomElement.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting
{
    using System.Collections.Specialized;

    /// <summary>
    /// Represents DOM element class.
    /// </summary>
    public class DomElement
    {
        /// <summary>
        /// Gets or sets inner HTML string.
        /// </summary>
        public string InnerHtml { get; set; }

        public string OuterHtml { get; set; }

        public string InnerText { get; set; }

        public string TagName { get; set; }

        /// <summary>
        /// Gets or sets CSS class name.
        /// </summary>
        public string Class { get; set; }
        
        /// <summary>
        /// Gets or sets element's id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HtmlProcessor Processor
        {
            get 
            { 
                return new HtmlProcessor(this.InnerHtml); 
            }
        }

        public NameValueCollection Attributes
        {
            get;
            set;
        }

    }
}
