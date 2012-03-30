// ============================================================================
// <copyright file="DataExtractor.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a class for data extracting.
    /// </summary>
    public class DataExtractor
    {
        #region Private properties

        /// <summary>
        /// Sets data types to extract.
        /// </summary>
        private DataTypes _dataTypesToExtract;

        /// <summary>
        /// UriHtmlProcessor object.
        /// </summary>
        private HtmlProcessor _htmlProcessor;

        private string _innerHtml;
              
        /// <summary>
        /// List of regex strings.
        /// </summary>
        private List<DataTypes> _regexStrings;

        private TextSources _extractingSource;
        
        /// <summary>
        /// Dictionaty with custom regex strings.
        /// </summary>
        private Dictionary<string, string> _customRegexStrings;

        /// <summary>
        /// List of extracting items.
        /// </summary>
        private List<ExtractedItemInfo> _results;

        #endregion

        #region Constructors

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="html">Html string to be processed.</param>
        /// <param name="dataTypesToExtract">Data types need to be extracted.</param>
        public DataExtractor(string html, DataTypes dataTypesToExtract = DataTypes.None) 
        {
            _innerHtml = html;
            _customRegexStrings = new Dictionary<string, string>();
            _dataTypesToExtract = dataTypesToExtract;
        }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="uri">Uri object.</param>
        /// <param name="dataTypesToExtract">Data types need to be extracted.</param>
        public DataExtractor(Uri uri, DataTypes dataTypesToExtract = DataTypes.None) :
            this(new UriHtmlExtractor(uri).DocumentText, dataTypesToExtract)
        {
        
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets extracted results by group name.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <returns>Extracted results.</returns>
        public List<ExtractedItemInfo> GetExtractedResults(string groupName) 
        {
            return this.GetExtractedResults().Where(item => item.GroupName == groupName).ToList();
        }

        /// <summary>
        /// Gets extracted data.
        /// </summary>
        public List<ExtractedItemInfo> GetExtractedResults()
        {
            _htmlProcessor = new HtmlProcessor(_innerHtml);
            _regexStrings = new List<DataTypes>();
            _results = new List<ExtractedItemInfo>();

            //if ((_dataTypesToExtract & DataTypes.All) == DataTypes.None)
            //{
            //    throw new ArgumentException("DataTypesToExtract can not be undefined!");
            //}

            foreach (string dtName in Enum.GetNames(typeof(DataTypes)))
            {
                DataTypes dataType = (DataTypes)Enum.Parse(typeof(DataTypes), dtName);

                if (dataType == DataTypes.All) continue;

                if ((_dataTypesToExtract & dataType) != 0)
                {
                    _regexStrings.Add(dataType);
                }

                dataType = DataTypes.None;
            }

            foreach (var regex in this._regexStrings)
            {
                this.AddCustomRegex(regex.GetStringValue(), regex.ToString().Trim());
            }

            foreach (var regex in _customRegexStrings.Keys)
            {
                string groupName = string.Empty;
                _customRegexStrings.TryGetValue(regex, out groupName);
                this.AddCustomRegex((string)regex, groupName);
            }

            return _results;
        }

        /// <summary>
        /// Adds extracted data items with passed regex and group name.
        /// </summary>
        /// <param name="regex">Regex to be used.</param>
        /// <param name="groupName">Group name of data patterns.</param>
        private void AddCustomRegex(string regex, string groupName)
        {
            List<string> items = _innerHtml.GetMatches(regex);

            foreach (var item in items)
            {
                ExtractedItemInfo info = new ExtractedItemInfo
                {
                    GroupName = groupName,
                    Value = item.Trim()
                };

                if (_results.IndexOf(info) == -1)
                {
                    _results.Add(info);
                }
            }
        }

        /// <summary>
        /// Adds custom regex to collection.
        /// </summary>
        /// <param name="regex">Regex to be used.</param>
        /// <param name="groupName">Group name.</param>
        public void AddRegex(string regex, string groupName)
        {
            _customRegexStrings.Add(regex, groupName);

        }

        #endregion
    }
}

