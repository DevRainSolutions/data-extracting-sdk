// ============================================================================
// <copyright file="UriHtmlExtractor.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;

    /// <summary>
    /// BaseUriExtractor class is a base class for uri-enabled data extracting classes.
    /// </summary>
    public class UriHtmlExtractor
    {
        #region Private members
        /// <summary>
        /// WebClient object.
        /// </summary>
        private WebClient _webClient;

        /// <summary>
        /// Uri object.
        /// </summary>
        private Uri _uri;

        /// <summary>
        /// User agent.
        /// </summary>
        private string _userAgent;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets html code string
        /// </summary>
        public string DocumentHtml { get; protected set; }
        
        /// <summary>
        /// Gets text string.
        /// </summary>
        public string DocumentText { get; protected set; }

        /// <summary>
        /// Gets query status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; protected set; }

        #endregion

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="uri">Uri to be processed.</param>
        /// <param name="proxy">WebProxy to be used.</param>
        /// <param name="postParameters">Collection of parameters for POST request.</param>
        public UriHtmlExtractor(Uri uri, NameValueCollection postParameters = null, WebProxy proxy = null, string userAgent = UserAgents.Default)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");

            this._uri = uri;
            this._userAgent = userAgent;

            var myRequest = WebRequest.Create(uri) as HttpWebRequest;
            myRequest.UserAgent = this._userAgent;
            
            if (proxy != null)
                myRequest.Proxy = proxy;

            if (postParameters != null)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                string postData = string.Empty;
                for (int i = 0; i < postParameters.Count; i++)
                {
                    string key = postParameters.GetKey(i);
                    string value = postParameters.Get(i);

                    if (i == 0)
                        postData += string.Format("{0}={1}", key, value);
                    else
                        postData += string.Format("&{0}={1}", key, value);
                }

                byte[] data = encoding.GetBytes(postData);

                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
            }

            HttpWebResponse resp = myRequest.GetResponse() as HttpWebResponse;

            Encoding respenc;
            try
            {

                if ((resp.ContentEncoding != null) && (resp.ContentEncoding.Length > 0))
                    respenc = Encoding.GetEncoding(resp.ContentEncoding);
            }
            catch (Exception ex) { }

            var reader = new StreamReader(resp.GetResponseStream());
            this.DocumentHtml = reader.ReadToEnd();
            this.StatusCode = resp.StatusCode;
            reader.Close();
            resp.Close();

            this._webClient = new WebClient { Proxy = proxy }; //new WebProxy("http://10.30.6.2:3128/", true);
            this._webClient.Headers.Add("user-agent", this._userAgent);
            
            this.DocumentText = this.DocumentHtml.RemoveHtmlTags();
        }

        #region Public methods

        ///// <summary>
        ///// Saves HTML to local file.
        ///// </summary>
        ///// <param name="filePath">File path to be saved in.</param>
        public void SaveHtml(string filePath)
        {
            File.WriteAllText(filePath, this.DocumentHtml);
        }

        ///// <summary>
        ///// Saves Uri text to local file.
        ///// </summary>
        ///// <param name="filePath">File path to be saved in.</param>
        public void SaveText(string filePath)
        {
            File.WriteAllText(filePath, this.DocumentText);
        }

        /// <summary>
        /// Checks is specific page exists
        /// </summary>
        /// <param name="pageName">Page name to be checked.</param>
        /// <returns>True if exists, false otherwise.</returns>
        public bool IsPageExists(string pageName) {

            try
            {
                //Create a request for the URL.
                WebRequest request = WebRequest.Create(Path.Combine(_uri.ToString(), pageName));
                //Get the response.
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                //Display the status.
                return response.StatusDescription == "OK";
            }
            catch(WebException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Searches for pages with suggested name.
        /// </summary>
        /// <param name="pageName">Page name to be searched.</param>
        /// <returns>Uri if found, null otherwise.</returns>
        public Uri FindPage(string pageName) {
            HtmlProcessor proc = new HtmlProcessor(this.DocumentHtml);

            foreach (var item in proc.Links)
            {
                if (item.Attributes["href"].IndexOf(pageName, StringComparison.OrdinalIgnoreCase) != -1)
                    return new Uri(item.Attributes["href"].FixUrl(_uri));
            }
            return null;
        }

        /// <summary>
        /// Searches for any page from the array.
        /// </summary>
        /// <param name="pageNames">Array of pages</param>
        /// <returns>Uri if found, false otherwise.</returns>
        public Uri FindPage(IEnumerable<string> pageNames)
        {
            return pageNames.Select(this.FindPage).FirstOrDefault(page => page != null);
        }

        /// <summary>
        /// Checks if contentType is text/html.
        /// </summary>
        /// <param name="contentType">Content type string.</param>
        /// <returns>True if text/html, false otherwise.</returns>
        private bool IsHtmlContent(string contentType)
        {
            return contentType.ToLower().StartsWith("text/html");
        }

        /// <summary>
        /// Checks if HTML markup is valid.
        /// </summary>
        /// <see cref="http://validator.w3.org/"/>
        /// <returns>True if valid, false otherwise.</returns>
        public bool IsHtmlMarkupValid()
        {
            var result = this._webClient.DownloadString(string.Format("http://validator.w3.org/check?uri={0}&output=soap12", this._uri));
            return bool.Parse(result.GetHtmlString("<m:validity>", "</m:validity>"));
        }

        /// <summary>
        /// Checks if CSS markup is valid.
        /// </summary>
        /// <see cref="http://jigsaw.w3.org/css-validator/"/>
        /// <returns>True if valid, false otherwise.</returns>
        public bool IsCSSValid()
        {
            var result = this._webClient.DownloadString(string.Format("http://jigsaw.w3.org/css-validator/validator?uri={0}&output=soap12", this._uri));
            return bool.Parse(result.GetHtmlString("<m:validity>", "</m:validity>"));
        }

        /// <summary>
        /// Checks is favicon.ico exists.
        /// </summary>
        /// <returns>True if exists, false otherwise.</returns>
        public bool IsFaviconExists()
        {
            string url = this._uri.Scheme + "://" + this._uri.Host + "/favicon.ico";
            byte[] body = this._webClient.DownloadData(url); // note should be 0-length
            string type = this._webClient.ResponseHeaders["content-type"];
            return (type == "image/x-icon");
        }

        /// <summary>
        /// Checks if robots.txt file exists.
        /// </summary>
        /// <returns>True if exists, false otherwise.</returns>
        public bool IsRobotsTxtExists()
        {
            string url = this._uri.Scheme + "://" + this._uri.Host + "/robots.txt";
            byte[] body = this._webClient.DownloadData(url); // note should be 0-length
            string type = this._webClient.ResponseHeaders["content-type"];
            return (type == "text/plain");
        }

        /// <summary>
        /// Gets Google PageRank.
        /// </summary>
        public string GooglePageRank
        {
            get
            {
                return _uri.GetGooglePageRank();
            }
        }

        #endregion
    }
}
