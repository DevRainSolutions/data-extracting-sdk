namespace DevRain.Data.Extracting
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public sealed class WinScreenshotExtractor : BaseScreenshotExtractor
    {
        #region Constructors

        /// <summary>
        /// WebScreenshotExtractor class can be used for screenshots extracting in web-applications.
        /// </summary>
        public WinScreenshotExtractor(Uri uri)
            : base(uri)
        {

        }

        public WinScreenshotExtractor(Uri uri, int iWidth, int iHeight, bool scrollingEnabled)
            : base(uri, iWidth, iHeight, scrollingEnabled)
        {

        }

        #endregion

        #region Public Methods

        protected override void MakeScreenshot()
        {
            Thread m_thread = new Thread(new ThreadStart(GenerateWebSiteImage));
			m_thread.SetApartmentState(ApartmentState.STA);
            m_thread.Start();
            m_thread.Join();
        }

        #endregion

        #region Private Methods

        private void GenerateWebSiteImage()
        {
            WebBrowser wb = new WebBrowser();
            wb.ScriptErrorsSuppressed = true;
            wb.ScrollBarsEnabled = false;
            wb.Navigate(_uri);
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);

            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            wb.Dispose();
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            wb.ClientSize = new Size(_imageWidth, _imageHeight);
            wb.ScrollBarsEnabled = _scrollingEnabled;
            _image = new Bitmap(wb.Bounds.Width, wb.Bounds.Height);
            wb.BringToFront();
            wb.DrawToBitmap(Image, wb.Bounds);
            wb.Dispose();
        }

        #endregion
    }
}
