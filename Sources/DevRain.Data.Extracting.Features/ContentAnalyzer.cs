// ============================================================================
// <copyright file="ContentAnalyzer.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting.Features
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DevRain.Data.Extracting;

    /// <summary>
    /// ContentAnalyzer is used for content analysis.
    /// </summary>
    public class ContentAnalyzer : HtmlProcessor
    {
        /// <summary>
        /// Gets collection of words.
        /// </summary>
        public List<string> Words
        {
            get
            {
                return this.InnerText.SplitToWords();
            }
        }

        /// <summary>
        /// Gets list of sentences.
        /// </summary>
        public List<string> Sentences
        {
            get
            {
                var sentences = new List<string>();
                string text = this.InnerText.TrimSafe() + " ";

                text = text.Replace("Dr.", "Dr").Replace("Ms.", "Ms").Replace("Mr.", "Mr").Replace("Dept.", "Dept");
                text = text.Replace(System.Environment.NewLine, " ~~ ");

                if (!string.IsNullOrEmpty(text))
                {
                    string[] split = text.Split(new string[] { " ~~ " }, StringSplitOptions.RemoveEmptyEntries);

                    //string[] splitSentences = Regex.Split(text, @"(?<=['""A-Za-z0-9][\.\!\?])\s+(?=[A-Z])");
                    foreach (string str in split)
                    {
                        if (str.IndexOfAny(new string[] { "...", ".", "!", "?" }) != -1)
                        {
                            string[] splitSentences = str.Split(
                                    new string[] { "... ", ". ", "! ", "? " }, StringSplitOptions.RemoveEmptyEntries);

                            // loop the sentences
                            for (int i = 0; i < splitSentences.Length; i++)
                            {
                                // clean up the sentence one more time, trim it, and add it to the array list
                                string sSingleSentence = splitSentences[i];

                                string sent = splitSentences[i];
                                int wordsCount = sent.SplitToWords().Count;

                                if (wordsCount > 2 && wordsCount < 30)
                                {
                                    sentences.Add(sent);
                                    this.WordsInSentencesCount += wordsCount;
                                }
                            }
                        }
                    }
                }
                return sentences;
            }
        }

        /// <summary>
        /// Average sentences length (only words which are the part of sentences are taken). 
        /// </summary>
        public double SentencesAvgLength
        {
            get
            {
                return (this.Sentences.Count == 0) ? 0 : (double)this.WordsInSentencesCount / (double)this.Sentences.Count;
            }
        }

        /// <summary>
        /// Gets list of known stop words
        /// </summary>
        public List<string> StopWords
        {
            get
            {
                List<string> stopWordsList = Extensions.GetStopWords();
                var stopWords = new List<string>();

                foreach (string stopWord in stopWordsList)
                {
                    if (this.InnerText.ToUpperInvariant().Contains(stopWord.ToUpperInvariant()))
                    {
                        stopWords.Add(stopWord);
                    }
                }
                return stopWords;
            }
        }

        /// <summary>
        /// Gets number of words which are links
        /// </summary>
        public List<string> WordsAsLinks
        {
            get
            {
                List<string> list = new List<string>();
                foreach (var link in this.Links)
                    list.AddRange(link.InnerText.SplitToWords());
                return list;
            }

        }

        /// <summary>
        /// Gets words in lists ("li").
        /// </summary>
        public List<string> WordsAsLists
        {
            get
            {
                List<string> words = new List<string>();

                var collection = this.GetElementsByTagName("li");

                foreach (var li in collection)
                {
                    words.AddRange(li.InnerText.SplitToWords());
                }
                return words;
            }
        }

        public ContentAnalyzer(string html): base(html) { }
        public ContentAnalyzer(Uri uri) : base(uri) { }

        public double GetSeoRank(string keyword)
        {

            double[] _rates = new double[] { 
            0.66,
            0.63,
            0.60,
            0.49,
            0.47,
            0.45,
            0.45,
            0.42,
            0.38,
            0.37,
            0.35,
            0.33,
            0.33,
            0.26,
            0.25,
            0.23,
            0.22,
            0.21,
            0.19,
            0.12,
            0.06,
            0.05
        };

            double rank = 0.0;
            keyword = keyword.ToLower();

            // Title contains keyword
            if (this.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
                rank += _rates[0];

            // Keyword is first in Title
            if (this.Title.StartsWith(keyword))
                rank += _rates[1];

            //// Keyword is a part of URL (e.g. keyword.com)
            //if (this._uri.Host.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
            //    rank += _rates[2];

            foreach (var header in this.Headers)
            {
                if (header.InnerText.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    rank += _rates[3];
                    break;
                }
            }

            foreach (var link in this.Links)
            {
                if (link.InnerText.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    rank += _rates[4];
                    break;
                }
            }

            foreach (var header in this.Headers)
            {
                if (header.InnerText.StartsWith(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    if (header.TagName.ToUpperInvariant() == "H1")
                    {
                        rank += _rates[5];
                        break;
                    }
                    else
                    {
                        rank += _rates[10];
                        break;
                    }
                }

            }

            int i = 0;
            foreach (var word in this.Words)
            {
                if (i == 100) break;

                if (word.Equals(keyword, StringComparison.OrdinalIgnoreCase))
                    rank += _rates[6];

                i++;
            }

            foreach (var image in this.Images)
            {
                if (image.Attributes["alt"].IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    rank += _rates[11];
                    break;
                }
            }


            foreach (var image in this.Images)
            {
                if (image.Attributes["src"].IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    rank += _rates[12];
                    break;
                }
            }

            foreach (var word in this.WordsAsLists)
            {
                if (word.Equals(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    rank += _rates[15];
                    break;
                }
            }

            if (this.MetaDescription.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
                rank += _rates[16];
            
            if (this.MetaKeywords.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) != -1)
                rank += _rates[17];

            return rank / (_rates.Length - 9);
        }

        /// <summary>
        /// Gets document content uniqueness.
        /// </summary>
        /// <param name="documents">List of all documents.</param>
        /// <param name="index">Index of document to be checked.</param>
        /// <param name="minimumSentenseLength">Minimum sentense length to be taken.</param>
        /// <returns>Calcilated document uniqueness in range [0; 1].</returns>
        public static double GetDocumentUniqueness(List<string> documents, int index, int minimumSentenseLength)
        {
            ContentAnalyzer a = new ContentAnalyzer(documents[index]);
            var sentenses = a.Sentences.Where(s => s.Length > minimumSentenseLength);

            int count = 0;

            for (int i = 0; i < documents.Count; i++)
            {
                if (i == index) continue;

                a = new ContentAnalyzer(documents[i]);

                foreach (var sentense in sentenses)
                {
                    if (a.Sentences.Contains(sentense))
                    {
                        count++;
                    }
                }
            }
            return ((double)sentenses.Count() - (double)count) / (double)sentenses.Count();
        }


        public int WordsInSentencesCount { get; protected set; }
    }
}
