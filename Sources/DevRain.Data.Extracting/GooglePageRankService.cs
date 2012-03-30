// ============================================================================
// <copyright file="GooglePRChecker.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Google PageRank checker. 
    /// </summary>
    public class GooglePageRankService
    {
        public List<GooglePageRank> Results { get; private set; }
        
        public GooglePageRankService()
        {
            
        }

        public GooglePageRankService(IEnumerable<string> urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    this.Add(this.ProcessUrl(url));
                }
                catch (Exception ex)
                {
                    this.Add(new GooglePageRank { PageRank = "n/a", Url = url });
                }
            }
        }

        public GooglePageRank ProcessUrl(string url)
        {
            //Calculate URL checksum
            var checkSum = this.GoogleChecksum("info:" + url);
            var file = "http://toolbarqueries.google.com/tbr?features=Rank&sourceid=navclient-ff&client=navclient-auto-ff&ch=" + checkSum + "&q=info:" + url;

            //Request PR from Google
            var webClient = new WebClient();
            string data = webClient.DownloadString(new Uri(file));

            //Parse PR from string
            int pageRank = -1;
            if (data.IndexOf(':') != -1)
            {
                data = data.Substring(data.LastIndexOf(':') + 1);
            }

            int.TryParse(data, out pageRank);

            return new GooglePageRank { PageRank = pageRank.ToString(), Url = url };
        }

        private void Mix(ref uint a, ref uint b, ref uint c)
        {
            a -= b;
            a -= c;
            a ^= c >> 13;
            b -= c;
            b -= a;
            b ^= a << 8;
            c -= a;
            c -= b;
            c ^= b >> 13;
            a -= b;
            a -= c;
            a ^= c >> 12;
            b -= c;
            b -= a;
            b ^= a << 16;
            c -= a;
            c -= b;
            c ^= b >> 5;
            a -= b;
            a -= c;
            a ^= c >> 3;
            b -= c;
            b -= a;
            b ^= a << 10;
            c -= a;
            c -= b;
            c ^= b >> 15;
        }

        private void Add(GooglePageRank pageRank)
        {
            this.Results.Add(pageRank);
        }

        private string GoogleChecksum(string url)
        {
            this.Results = new List<GooglePageRank>();
            uint GoogleMagic = 0xE6359A60;

            uint a, b;
            uint c = GoogleMagic;

            a = b = 0x9E3779B9;

            int k = 0;
            int length = url.Length;

            //Algorithm
            while (length >= 12)
            {
                a += (uint)(url[k + 0] + (url[k + 1] << 8) + (url[k + 2] << 16) + (url[k + 3] << 24));
                b += (uint)(url[k + 4] + (url[k + 5] << 8) + (url[k + 6] << 16) + (url[k + 7] << 24));
                c += (uint)(url[k + 8] + (url[k + 9] << 8) + (url[k + 10] << 16) + (url[k + 11] << 24));

                Mix(ref a, ref b, ref c);

                k += 12;
                length -= 12;
            }

            c += (uint)url.Length;

            //All cases fall through
            switch (length)
            {
                case 11:
                    c += (uint)(url[k + 10] << 24);
                    goto case 10; //fall through
                case 10:
                    c += (uint)(url[k + 9] << 16);
                    goto case 9;
                case 9:
                    c += (uint)(url[k + 8] << 8);
                    goto case 8;
                case 8:
                    b += (uint)(url[k + 7] << 24);
                    goto case 7;
                case 7:
                    b += (uint)(url[k + 6] << 16);
                    goto case 6;
                case 6:
                    b += (uint)(url[k + 5] << 8);
                    goto case 5;
                case 5:
                    b += (uint)(url[k + 4]);
                    goto case 4;
                case 4:
                    a += (uint)(url[k + 3] << 24);
                    goto case 3;
                case 3:
                    a += (uint)(url[k + 2] << 16);
                    goto case 2;
                case 2:
                    a += (uint)(url[k + 1] << 8);
                    goto case 1;
                case 1:
                    a += (uint)(url[k + 0]);
                    break;
                default:
                    break;
            }

            Mix(ref a, ref b, ref c);

            return string.Format("6{0}", c);
        }
    }
}
