namespace DevRain.Data.Extracting
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// WebScreenshotExtractor class can be used for screenshots extracting in web-applications.
    /// </summary>
    public sealed class WebScreenshotExtractor 
    {
        /// <summary>
        /// Gets extracted image.
        /// </summary>
        public Bitmap Image { get { return _image; } }

        /// <summary>
        /// Uri to be processed.
        /// </summary>
        protected Uri _uri;

        /// <summary>
        /// Image bitmap.
        /// </summary>
        protected Bitmap _image;

        /// <summary>
        /// Determines is scrolling is enabled. 
        /// </summary>
        protected bool _scrollingEnabled;

        /// <summary>
        /// Image height.
        /// </summary>
        protected int _imageHeight;

        /// <summary>
        /// Image width.
        /// </summary>
        protected int _imageWidth;

        /// <summary>
        /// Private constructor.
        /// </summary>
        private WebScreenshotExtractor() { }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="uri">Uri to be processed.</param>
        public WebScreenshotExtractor(Uri uri) : this(uri, 1024, -1, false)
		{
		}

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="uri">Uri to be processed.</param>
        /// <param name="iWidth">Image width.</param>
        /// <param name="iHeight">Image height.</param>
        /// <param name="scrollingEnabled">Determines if scrolling is enabled.</param>
        public WebScreenshotExtractor(Uri uri, int imageWidth, int imageHeight, bool scrollingEnabled = false) 
            
		{
            if (uri == null)
                throw new ArgumentNullException("uri");

            _uri = uri;
            _scrollingEnabled = scrollingEnabled;
            _imageWidth = imageWidth;
            _imageHeight = imageHeight;
            
            Thread m_thread = new Thread(new ThreadStart(MakeScreenshot));
            m_thread.SetApartmentState(ApartmentState.STA);
            m_thread.Start();
            m_thread.Join();
		}

        /// <summary>
        /// Makes screenshot.
        /// </summary>
        protected void MakeScreenshot()
        {
            // Load the webpage into a WebBrowser control
            WebBrowser wb = new WebBrowser();
            wb.ScrollBarsEnabled = _scrollingEnabled;
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(_uri);
            while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }

            // Set the size of the WebBrowser control
            wb.Width = _imageWidth;
            wb.Height = _imageHeight;

            // Take Screenshot of the web pages full width
            if (_imageHeight < 0)
            {
                wb.Width = wb.Document.Body.ScrollRectangle.Width;
                wb.Height = wb.Document.Body.ScrollRectangle.Height;
            }

            // Get a Bitmap representation of the webpage as it's rendered in the WebBrowser control
            Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
            wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
            wb.Dispose();

            _image = bitmap;
        }
    }
}