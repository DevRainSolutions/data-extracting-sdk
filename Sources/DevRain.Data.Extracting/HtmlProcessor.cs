// ============================================================================
// <copyright file="HtmlProcessor.cs" company="DevRain">
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
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using mshtml;

    /// <summary>
    /// HtmlProcessor is used for rich HTML processing.
    /// </summary>
    public class HtmlProcessor
    {
        #region Parameters from webpage header section  

        private List<DomElement> _elements;

        /// <summary>
        /// Gets page title.
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// Gets page keywords string.
        /// </summary>
        public string MetaKeywords
        {
            get
            {
                var keyword = this.Metas.Find(m => m.Attributes["name"].ToUpperInvariant() == "keywords".ToUpperInvariant());
                return (keyword == null) ? null : keyword.Attributes["content"];
            }
        }

        /// <summary>
        /// Gets page keywords string.
        /// </summary>
        public string MetaDescription
        {
            get
            {
                var keyword = this.Metas.Find(m => m.Attributes["name"].ToUpperInvariant() == "description".ToUpperInvariant());
                return (keyword == null) ? null : keyword.Attributes["content"];
            }
        }

        /// <summary>
        /// Gets collection of webpage meta info.
        /// <see cref="http://habrahabr.ru/blogs/webdev/72141/"/>
        /// </summary>
        public List<DomElement> Metas
        {
            get
            {
                return this.GetElementsByTagName("meta");
            }
        }

        #endregion

        public string DocumentStringFull
        {
            get
            {
                var document = this.doc3.getElementsByTagName("html").item(0, 0) as HTMLBody;
                return document.outerHTML;
            }

        }

        /// <summary>
        /// Document source.
        /// </summary>
        private string documentSource;

        #region Public properties

        /// <summary>
        /// Gets document sourse.
        /// </summary>
        public string DocumentSource
        {
            get { return documentSource; }
        }

        /// <summary>
        /// Gets or sets IHTMLDocument object
        /// </summary>
        [Browsable(false)]
        protected IHTMLDocument doc;

        /// <summary>
        /// Gets or sets IHTMLDocument2 object
        /// </summary>
        [Browsable(false)]
        protected IHTMLDocument2 doc2;

        /// <summary>
        /// Gets or sets IHTMLDocument3 object
        /// </summary>
        [Browsable(false)]
        protected IHTMLDocument3 doc3;

        /// <summary>
        /// Gets or sets IHTMLDocument4 object
        /// </summary>
        [Browsable(false)]
        protected IHTMLDocument4 doc4;

        /// <summary>
        /// Gets or sets IHTMLDocument5 object
        /// </summary>
        [Browsable(false)]
        protected IHTMLDocument5 doc5;

        /// <summary>
        /// Gets or sets text string
        /// </summary>
        public string InnerText { get; protected set; }

        public List<DomElement> Controls {
            get 
            { 
                return this.GetElementsByTags(new string[] { "input", "select", "button", "textarea", "fieldset" });   
            }
        }

        public List<DomElement> Objects
        {
            get
            {
                return this.GetElementsByTagName("object");
            }
        }

        /// <summary>
        /// Gets collection of page scripts
        /// </summary>
        public List<DomElement> Scripts
        {
            get
            {
                return this.GetElementsByTagName("script");   
            }
        }

        /// <summary>
        /// Gets collection of page images
        /// </summary>
        public List<DomElement> Images
        {
            get
            {
                return this.GetElementsByTagName("img");   
            }
        }

        public List<DataTable> HtmlTables {
            get 
            {
                return GetTables(TextFormats.HTML);       
            }
        }

        /// <summary>
        /// Gets list of DataTable objects
        /// </summary>  
        /// <returns>List of DataTable objects</returns>
        public List<DataTable> Tables
        {
            get
            {
               return GetTables(TextFormats.Text);
            }
        }

        private List<DataTable> GetTables(TextFormats format) {
            IHTMLElementCollection tableCollection = this.doc3.getElementsByTagName("table");
            List<DataTable> list = new List<DataTable>();

            if (tableCollection != null)
            {
                foreach (var tableObject in tableCollection)
                {
                    HTMLTable table = tableObject as HTMLTable;

                    if (table != null)
                    {
                        DataTable dt = new DataTable();


                        foreach (HTMLTableRow htmlRow in table.rows)
                        {
                            DataRow row = dt.NewRow();

                            for (int i = 0; i < htmlRow.cells.length; i++)
                            {
                                if (dt.Columns.Count < i + 1)
                                {
                                    dt.Columns.Add();
                                }

                                HTMLTableCell cell = htmlRow.cells.item(i, i) as HTMLTableCell;
                                if (format == TextFormats.Text)
                                    row[i] = cell.innerText;

                                if (format == TextFormats.HTML)
                                    row[i] = cell.innerHTML;
                            }

                            dt.Rows.Add(row);
                        }

                        list.Add(dt);
                    }
                }
            }

            return list;
        }

        public List<DomElement> Elements {
            get 
            {
                return this._elements;
            }
        }

        /// <summary>
        /// Headers collection
        /// </summary>
        public List<DomElement> Headers
        {
            get
            {
                string[] headerTags = new string[] { "H1", "H2", "H3", "H4", "H5", "H6" };
                return this._elements.Where(e => Array.Exists(headerTags, s => s.ToUpperInvariant().Contains(e.TagName))).ToList();
            }
        }

        /// <summary>
        /// Gets collection of page links.
        /// </summary>
        public List<DomElement> Links
        {
            get
            {
                return this.GetElementsByTagName("a");   
            }
        }

        public List<DomElement> GetElementsByTagName(string tagName)
        {
            return this._elements
                .Where(e => e.TagName.ToUpperInvariant() == tagName.ToUpperInvariant())
                .ToList();
        }

        public List<DomElement> GetElementsByName(string name) {
            return this._elements
                .Where(e => e.Attributes["name"] == name)
                .ToList();
        }

        public DomElement GetElementById(string id) {
            return this._elements
                .Find(e => e.Id == id);
        }
        

        /// <summary>
        /// Determines if flash exists.
        /// </summary>
        public bool HasFlash
        {
            get
            {
                return this.GetElementsByTagName("object")
                    .Where(e => e.InnerHtml.TrimSafe().ToLowerInvariant().Contains("application/x-shockwave-flash"))
                    .Count() > 0;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor.
        /// </summary>
        protected HtmlProcessor() { }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="uri">Uri to be processed.</param>
        public HtmlProcessor(Uri uri)
            : this(new UriHtmlExtractor(uri).DocumentHtml)
        {

        }

        public void ExecuteJavaScript(object doc, string script) {
            
                var parentWindow = ((IHTMLDocument2)doc).parentWindow;
                if (parentWindow != null)
                    parentWindow.execScript(script, "javascript");
        }


        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="html">Html string to be processed.</param>
        public HtmlProcessor(string html)
        {
            if (string.IsNullOrEmpty(html))
                throw new ArgumentException("HTML string can not be null or empty.", "html");

            this.documentSource = html;

            this.doc2 = new HTMLDocumentClass();
            this.doc2.write(new object[] { html });

            //while (this.doc2.readyState != "complete" && this.doc2.readyState != "interactive")
            //{
            //    System.Windows.Forms.Application.DoEvents();
            //}
            
            this.doc3 = (IHTMLDocument3)this.doc2;
            this.doc4 = (IHTMLDocument4)this.doc2;
            this.doc5 = (IHTMLDocument5)this.doc2;

            this.InnerText = (this.doc2.body == null) ? null : this.doc2.body.innerText;
            this.Title = this.doc2.title;


            this._elements = new List<DomElement>();

            IHTMLElementCollection collection = this.doc2.all;

            foreach (var item in collection)
            {
                var element = (IHTMLElement)item;

                if (element != null)
                {
                    DomElement domElement = new DomElement
                    {
                        Class = element.className,
                        InnerHtml = element.innerHTML.TrimSafe(),
                        OuterHtml = element.outerHTML.TrimSafe(),
                        InnerText = element.innerText.TrimSafe(),
                        Id = element.id,
                        TagName = element.tagName.ToLowerInvariant()
                    };

                    domElement.Attributes = new NameValueCollection();


                    if (element.outerHTML.IsNullOrEmpty()) continue;

                    //@"<INPUT onblur=google&amp;&amp;google.fade&amp;&amp;google.fade() class=lst title='Google Search' value=TESTING maxLength=2048 size=55 name=q autocomplete='off' init='true'/>";
                    string node = element.outerHTML.Substring(0, element.outerHTML.IndexOf(">") + 1);



                    string pattern = @"
(?:<)(?<Tag>[^\s/>]+)       # Extract the tag name.
(?![/>])                    # Stop if /> is found
                     # -- Extract Attributes Key Value Pairs  --
 
((?:\s+)             # One to many spaces start the attribute
 (?<Key>[^=]+)       # Name/key of the attribute
 (?:=)               # Equals sign needs to be matched, but not captured.
 
(?([\x22\x27])              # If quotes are found
  (?:[\x22\x27])
  (?<Value>[^\x22\x27]+)    # Place the value into named Capture
  (?:[\x22\x27])
 |                          # Else no quotes
   (?<Value>[^\s/>]*)       # Place the value into named Capture
 )
)+                  # -- One to many attributes found!";

                    //http://omegacoder.com/?p=512
                    var attr = (from Match mt in Regex.Matches(node, pattern, RegexOptions.IgnorePatternWhitespace)
                                select new
                                {
                                    Name = mt.Groups["Tag"],
                                    Attrs = (from cpKey in mt.Groups["Key"].Captures.Cast<Capture>().Select((a, i) => new { a.Value, i })
                                             join cpValue in mt.Groups["Value"].Captures.Cast<Capture>().Select((b, i) => new { b.Value, i }) on cpKey.i equals cpValue.i
                                             select new KeyValuePair<string, string>(cpKey.Value, cpValue.Value)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                                }).FirstOrDefault();

                    if (attr != null)
                    {
                        var attributes = attr.Attrs;
                        foreach (KeyValuePair<string, string> kvp in attributes)
                        {
                            if (!string.IsNullOrEmpty(kvp.Value))
                                domElement.Attributes.Add(kvp.Key.ToLowerInvariant(), kvp.Value);
                        }
                    }

                    this._elements.Add(domElement);
                }
            }
        }

        public void Close()
        {
            this.doc2.close();
            Marshal.ReleaseComObject(doc2);
            Marshal.ReleaseComObject(doc3);
            Marshal.ReleaseComObject(doc4);
            Marshal.ReleaseComObject(doc5);
        }

        #endregion

        /// <summary>
        /// Gets IHTMLElementCollection by tag name.
        /// </summary>
        /// <param name="tag">Tag name.</param>
        /// <returns>IHTMLElementCollection element collection.</returns>
        protected IHTMLElementCollection GetIHTMLElementCollectionByTag(string tag)
        {
            return this.doc3.getElementsByTagName(tag) as IHTMLElementCollection;
        }

        /// <summary>
        /// Gets number of elements by tag names.
        /// </summary>
        /// <param name="сontrolNames">Array of tags.</param>
        /// <returns>Number of elements.</returns>
        protected List<DomElement> GetElementsByTags(IEnumerable<string> tags)
        {
            List<DomElement> list = new List<DomElement>();

            foreach (string tag in tags)
                list.AddRange(this.GetElementsByTagName(tag));

            return list;
        }

        /// <summary>
        /// Gets Body element.
        /// </summary>
        public DomElement Body
        {
            get
            {
                return this.GetElementsByTagName("body").FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets HtmlProcessor object from content of file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>HtmlProcessor object.</returns>
        public static HtmlProcessor FromFile(string path)
        {
            return new HtmlProcessor(File.ReadAllText(path));
        }

        private Microsoft.JScript.Vsa.VsaEngine Engine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();

        public object EvalJScript(string JScript)
        {
            object script = this.doc2.Script;
            script.GetType().InvokeMember(JScript, BindingFlags.InvokeMethod, null, script, null);

            return null;
            object Result = null;

            try
            {
                Result = Microsoft.JScript.Eval.JScriptEvaluate(JScript, Engine);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return Result;
        }
        
    }
}
