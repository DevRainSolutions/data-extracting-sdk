// ============================================================================
// <copyright file="LinksExtractor.cs" company="DevRain">
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
    using System.Net;
    using System.Text;

    /// <summary>
    /// LinksExtractor class is used for extract links from search engines.
    /// </summary>
    public class LinksExtractor
    {
        /// <summary>
        /// Gets list of extracted links.
        /// </summary>
        public List<DomElement> Links { get { return _links; } }

        private SearchEngines _engine;
        private WebProxy _proxy;
        private List<DomElement> _links;

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="query">Query to be processed.</param>
        /// <param name="engine">Search engine to be used.</param>
        /// <param name="pageCount">Pages count to be processed (50 is a maximum).</param>
        /// <param name="proxy">WebProxy object if needed (use null if not).</param>
        public LinksExtractor(string query, SearchEngines engine, int pageCount = 1, WebProxy proxy = null)
        {
            if (pageCount < 1)
                throw new ArgumentOutOfRangeException("pageCount");

            if (pageCount > 50)
                pageCount = 50;

            if (query == null)
                throw new ArgumentNullException("query");

            _links = new List<DomElement>();
            query = GetEngineReadyQuery(query);
            _engine = engine;
            _proxy = proxy;
            
            string url = string.Empty;

            for (int i = 0; i < pageCount; i++)
            {
                switch(engine)
                {
                    case SearchEngines.Google:
                        url = string.Format("http://www.google.com/search?hl=en&q={0}&start={1}", query, (i + 1) * 10);
                        break;
                    case SearchEngines.Yandex:
                        url = string.Format("http://yandex.ru/yandsearch?p={1}&lr=187&text={0}", query, i);
                        break;
                    case SearchEngines.Bing:
                        url = string.Format("http://www.bing.com/search?q={0}&first={1}", query, i*10+1);
                        break;
                    default:
                        throw new ArgumentException("Not supported search engine.");
                        
                }

                _links.AddRange(this.GetExtractedLinks(new Uri(url)));
            }
        }

        /// <summary>
        /// Extracts links.
        /// </summary>
        /// <param name="uri">Uri to be processed.</param>
        /// <returns>Extracted links.</returns>
        protected List<DomElement> GetExtractedLinks(Uri uri)
        {
            List<DomElement> links = new List<DomElement>();
            UriHtmlExtractor uriProc = new UriHtmlExtractor(uri, proxy: _proxy);
            HtmlProcessor proc = new HtmlProcessor(uriProc.DocumentHtml);

            switch (_engine)
            {
                case SearchEngines.Google:
                    links = proc.Links.Where(
                        l => 
                            l.Attributes["href"].Contains("google.") == false
                            && l.Attributes["href"].Contains("cache:") == false
                            && l.Attributes["href"].Contains("related:") == false
                    ).ToList();
                    break;
                case SearchEngines.Yandex:
                    links = proc.Links.Where(
                        l =>
                            l.Attributes["href"] != null
                            && l.Attributes["href"].Contains("yandex.") == false
                            && l.Attributes["href"].Contains("ya.ru") == false
                            && l.Attributes["href"].Contains("moikrug") == false
                    ).ToList();
                    break;
                case SearchEngines.Bing:
                    links = proc.Links.Where(
                        l =>
                            l.Attributes["href"] != null
                            && l.Attributes["href"].Contains("bingj.") == false
                            && l.Attributes["href"].Contains("msn.") == false
                            && l.Attributes["href"].Contains("live.") == false
                            && l.Attributes["href"].Contains("bing.") == false
                            && l.Attributes["href"].Contains("google.com") == false
                            && l.Attributes["href"].Contains("go.microsoft.com") == false
                            && l.Attributes["href"].Contains("microsofttranslator") == false
                    ).ToList();
                    break;
                default:
                    break;
            }

            links = links.Where(l => Uri.IsWellFormedUriString(l.Attributes["href"], UriKind.Absolute)).ToList();

            return links;
        }

        /// <summary>
        /// Formats query string.
        /// </summary>
        /// <param name="query">Query string.</param>
        /// <returns>Formatted query string.</returns>
        protected static string GetEngineReadyQuery(string query)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            string[] queryArray = query.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string q in queryArray)
            {
                sb.AppendFormat("{0}+", q);
            }
            string value = sb.ToString().Substring(0, sb.ToString().Length - 1);
            return value;
        }
    }
}

