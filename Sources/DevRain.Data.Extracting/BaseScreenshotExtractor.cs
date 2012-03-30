// ============================================================================
// <copyright file="BaseScreenshotExtractor.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================
namespace DevRain.Data.Extracting
{
    using System;

    /// <summary>
    /// BaseScreenshotExtractor class is an abstract class for screenshots extractors.
    /// </summary>
    public abstract class BaseScreenshotExtractor
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="uri">Uri to be processed.</param>
        protected BaseScreenshotExtractor(Uri uri)
        {
            //this.MakeScreenshot();
        }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="uri">Uri to be processed.</param>
        /// <param name="imageWidth">Image width.</param>
        /// <param name="imageHeight">Image height.</param>
        /// <param name="scrollingEnabled">Determines if scrolling is enabled.</param>
        protected BaseScreenshotExtractor(Uri uri, int imageWidth, int imageHeight, bool scrollingEnabled = true)
        {
            this.MakeScreenshot();
        }

        /// <summary>
        /// Makes screenshot virtual method.
        /// </summary>
        protected virtual void MakeScreenshot()
        {
            
        }
    }
}
