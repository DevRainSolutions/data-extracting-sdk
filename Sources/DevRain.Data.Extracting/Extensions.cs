// ============================================================================
// <copyright file="Extensions.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extensions class contains extension methods.
    /// </summary>
    public static class Extensions
    {
        #region Bitmap extensions

        /// <summary>
        /// Converts Bitmap to grayscale
        /// </summary>
        /// <param name="bitmap">Bitmap object</param>
        /// <returns>Grayscaled Bitmap object</returns>
        public static Bitmap ToGreyScale(this Bitmap bitmap)
        {
            // <pex>
            if (bitmap == (Bitmap)null)
                throw new ArgumentNullException("bitmap");
            // </pex>
            Bitmap grays = bitmap;
            int width = grays.Size.Width;
            int height = grays.Size.Height;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Color col = grays.GetPixel(i, j);
                    grays.SetPixel(i, j, Color.FromArgb((col.R + col.G + col.B) / 3, (col.R + col.G + col.B) / 3, (col.R + col.G + col.B) / 3));
                }
            }
            return grays;
        }

        /// <summary>
        /// Scales the Bitmap image
        /// </summary>
        /// <param name="bitmap">Bitmap object</param>
        /// <param name="percent">Scale percent</param>
        /// <returns></returns>
        public static Bitmap Scale(this Bitmap bitmap, int percent)
        {
            // <pex>
            if (bitmap == (Bitmap)null)
                throw new ArgumentNullException("bitmap");
            // </pex>
            float nPercent = ((float)percent / 100);

            int sourceWidth = bitmap.Width;
            int sourceHeight = bitmap.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(bitmap,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        /// <summary>
        /// Resizes the image wuth crop
        /// </summary>
        /// <param name="bitmap">Bitmap object</param>
        /// <param name="width">New width</param>
        /// <param name="height">New height</param>
        /// <param name="anchor">Anchor: top, bottom, right, left</param>
        /// <returns>Resized image</returns>
        public static Bitmap ResizeWithCrop(Bitmap bitmap, int width, int height, string anchor)
        {
            // <pex>
            if (bitmap == (Bitmap)null)
                throw new ArgumentNullException("bitmap");
            // </pex>
            int sourceWidth = bitmap.Width;
            int sourceHeight = bitmap.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)width / (float)sourceWidth);
            nPercentH = ((float)height / (float)sourceHeight);

            if (nPercentH < nPercentW)
            {

                nPercent = nPercentW;
                switch (anchor)
                {

                    case "top":
                        destY = 0;
                        break;
                    case "bottom":
                        destY = (int)
                            (height - (sourceHeight * nPercent));
                        break;
                    default:
                        destY = (int)
                            ((height - (sourceHeight * nPercent)) / 2);
                        break;
                }
            }
            else
            {
                nPercent = nPercentH;
                switch (anchor)
                {
                    case "left":
                        destX = 0;
                        break;
                    case "right":
                        destX = (int)
                          (width - (sourceWidth * nPercent));
                        break;
                    default:
                        destX = (int)
                          ((width - (sourceWidth * nPercent)) / 2);
                        break;
                }
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(width,
                    height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(bitmap.HorizontalResolution,
                    bitmap.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(bitmap,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        /// <summary>
        /// Recizes the image
        /// </summary>
        /// <param name="bitmap">Bitmap object</param>
        /// <param name="width">New width</param>
        /// <param name="height">New height</param>
        /// <returns>Resized image</returns>
        public static Bitmap Resize(this Bitmap bitmap, int width, int height)
        {
            // <pex>
            if (bitmap == (Bitmap)null)
                throw new ArgumentNullException("bitmap");
            // </pex>

            int sourceWidth = bitmap.Width;
            int sourceHeight = bitmap.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)width / (float)sourceWidth);
            nPercentH = ((float)height / (float)sourceHeight);

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((width - (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((height - (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(bitmap,
                new Rectangle(0, 0, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;
        }

        /// <summary>
        /// Gets thumbnail image from bitmap.
        /// </summary>
        /// <param name="bitmap">Bitmap to be processed.</param>
        /// <param name="width">Thumbnail width.</param>
        /// <param name="height">Thumbnail height.</param>
        /// <returns>Thumbnail bitmap.</returns>
        public static Bitmap GetThumbnail(this Bitmap bitmap, int width, int height)
        {
            return (Bitmap)bitmap.GetThumbnailImage(width, height, null, IntPtr.Zero);
        }

        /// <summary>
        /// Gets image size type.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <returns>ImageSizeTypes object.</returns>
        public static ImageSizeTypes GetImageSizeType(this Bitmap image)
        {
            int size = image.Width * image.Height;

            int Level1 = 5625;
            int Level2 = 22500;
            int Level3 = 480000;
            int Level4 = 786432;

            if (size == 0)
                return ImageSizeTypes.None;

            if (size > 0 && size <= Level1)
                return ImageSizeTypes.VerySmall;

            if (size > Level1 && size <= Level2)
                return ImageSizeTypes.Small;

            if (size > Level2 && size <= Level3)
                return ImageSizeTypes.Middle;

            if (size > Level3 && size <= Level4)
                return ImageSizeTypes.Big;

            if (size > Level4)
                return ImageSizeTypes.VeryBig;

            return ImageSizeTypes.None;
        }

        #endregion

        #region DataTable extensions

        /// <summary>
        /// Writes all data from the DataTable to CSV file
        /// </summary>
        /// <param name="dt">DataTable object</param>
        /// <param name="path">File path to be saved in</param>
        public static void SaveAsCsv(this DataTable dt, string path)
        {
            // <pex>
            if (dt == (DataTable)null)
                throw new ArgumentNullException("dt");
            // </pex>
            string[] output = new string[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                object[] obj = row.ItemArray;

                StringBuilder sb = new StringBuilder();

                foreach (string s in obj)
                {
                    sb.Append(string.Format("\"{0}\", ", s));
                }

                output[i] = sb.ToString();
            }
            File.WriteAllLines(path, output);
        }

        /// <summary>
        /// Saves as csv 2.
        /// </summary>
        /// <param name="dt">DataTable object.</param>
        /// <param name="path">Path where csv file will be saved.</param>
        public static void SaveAsCsv2(this DataTable dt, string path)
        {

            // Create the CSV file to which grid data will be exported.
            StreamWriter sw = new StreamWriter(path, false);
            // First we will write the headers.
            //DataTable dt = m_dsProducts.Tables[0];
            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            // Now write all the rows.
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        /// <summary>
        /// Loads data from csv file to DataTable object.
        /// </summary>
        /// <param name="dt">DataTable object.</param>
        /// <param name="filePath">File path to be loaded from.</param>
        /// <param name="separator">Separator string value.</param>
        /// <returns>DataTable object.</returns>
        public static DataTable LoadFromCsv(this DataTable dt, string filePath, string separator)
        {
            string[] lines = File.ReadAllLines(filePath);
            dt = new DataTable();

            if (lines.Length != 0)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];

                    if (i == 0)
                    {
                        string[] headerLine = line.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string column in headerLine)
                        {
                            dt.Columns.Add(column);
                        }
                        continue;
                    }

                    string[] values = line.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);

                    DataRow row = dt.NewRow();
                    row.ItemArray = values;
                    dt.Rows.Add(row);

                }
            }

            return dt;
        }


        #endregion

        #region List extensions

        /// <summary>
        /// Gets list of countries.
        /// <see>http://www.iso.org/iso/country_codes/iso_3166_code_lists/english_country_names_and_code_elements.htm</see>
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCountries()
        {
            StringDictionary dic = new StringDictionary();
            List<string> col = new List<string>();

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures))
            {
                try
                {
                    RegionInfo ri = new RegionInfo(ci.LCID);
                    if (!dic.ContainsKey(ri.EnglishName))
                        dic.Add(ri.EnglishName, ri.TwoLetterISORegionName.ToLowerInvariant());

                    if (!col.Contains(ri.EnglishName))
                        col.Add(ri.EnglishName);
                }
                catch { }
            }

            col.Sort();

            return col;
        }

        /// <summary>
        /// Gets list of stop words.
        /// </summary>
        public static List<string> GetStopWords()
        {
            #region stop words

            string wordList = @"a
a's
able
about
above
according
accordingly
across
actually
after
afterwards
again
against
ain't
all
allow
allows
almost
alone
along
already
also
although
always
am
among
amongst
an
and
another
any
anybody
anyhow
anyone
anything
anyway
anyways
anywhere
apart
appear
appreciate
appropriate
are
aren't
around
as
aside
ask
asking
associated
at
available
away
awfully
b
be
became
because
become
becomes
becoming
been
before
beforehand
behind
being
believe
below
beside
besides
best
better
between
beyond
both
brief
but
by
c
c'mon
c's
came
can
can't
cannot
cant
cause
causes
certain
certainly
changes
clearly
co
com
come
comes
concerning
consequently
consider
considering
contain
containing
contains
corresponding
could
couldn't
course
currently
d
definitely
described
despite
did
didn't
different
do
does
doesn't
doing
don't
done
down
downwards
during
e
each
edu
eg
eight
either
else
elsewhere
enough
entirely
especially
et
etc
even
ever
every
everybody
everyone
everything
everywhere
ex
exactly
example
except
f
far
few
fifth
first
five
followed
following
follows
for
former
formerly
forth
four
from
further
furthermore
g
get
gets
getting
given
gives
go
goes
going
gone
got
gotten
greetings
h
had
hadn't
happens
hardly
has
hasn't
have
haven't
having
he
he's
hello
help
hence
her
here
here's
hereafter
hereby
herein
hereupon
hers
herself
hi
him
himself
his
hither
hopefully
how
howbeit
however
i
i'd
i'll
i'm
i've
ie
if
ignored
immediate
in
inasmuch
inc
indeed
indicate
indicated
indicates
inner
insofar
instead
into
inward
is
isn't
it
it'd
it'll
it's
its
itself
j
just
k
keep
keeps
kept
know
knows
known
l
last
lately
later
latter
latterly
least
less
lest
let
let's
like
liked
likely
little
look
looking
looks
ltd
m
mainly
many
may
maybe
me
mean
meanwhile
merely
might
more
moreover
most
mostly
much
must
my
myself
n
name
namely
nd
near
nearly
necessary
need
needs
neither
never
nevertheless
new
next
nine
no
nobody
non
none
noone
nor
normally
not
nothing
novel
now
nowhere
o
obviously
of
off
often
oh
ok
okay
old
on
once
one
ones
only
onto
or
other
others
otherwise
ought
our
ours
ourselves
out
outside
over
overall
own
p
particular
particularly
per
perhaps
placed
please
plus
possible
presumably
probably
provides
q
que
quite
qv
r
rather
rd
re
really
reasonably
regarding
regardless
regards
relatively
respectively
right
s
said
same
saw
say
saying
says
second
secondly
see
seeing
seem
seemed
seeming
seems
seen
self
selves
sensible
sent
serious
seriously
seven
several
shall
she
should
shouldn't
since
six
so
some
somebody
somehow
someone
something
sometime
sometimes
somewhat
somewhere
soon
sorry
specified
specify
specifying
still
sub
such
sup
sure
t
t's
take
taken
tell
tends
th
than
thank
thanks
thanx
that
that's
thats
the
their
theirs
them
themselves
then
thence
there
there's
thereafter
thereby
therefore
therein
theres
thereupon
these
they
they'd
they'll
they're
they've
think
third
this
thorough
thoroughly
those
though
three
through
throughout
thru
thus
to
together
too
took
toward
towards
tried
tries
truly
try
trying
twice
two
u
un
under
unfortunately
unless
unlikely
until
unto
up
upon
us
use
used
useful
uses
using
usually
uucp
v
value
various
very
via
viz
vs
w
want
wants
was
wasn't
way
we
we'd
we'll
we're
we've
welcome
well
went
were
weren't
what
what's
whatever
when
whence
whenever
where
where's
whereafter
whereas
whereby
wherein
whereupon
wherever
whether
which
while
whither
who
who's
whoever
whole
whom
whose
why
will
willing
wish
with
within
without
won't
wonder
would
would
wouldn't
x
y
yes
yet
you
you'd
you'll
you're
you've
your
yours
yourself
yourselves
z
zero";

            #endregion

            string[] words = wordList.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return words.ToList<string>();
        }

        #region Regular expression helpers

        public static bool IsMatch(this string str, string regex)
        {
            return Regex.IsMatch(str, regex);
        }

        /// <summary>
        /// Gets regex match.
        /// </summary>
        /// <param name="text">Text string.</param>
        /// <param name="regex">Regex string.</param>
        /// <returns>String that matches the regex.</returns>
        public static List<string> GetMatches(this string text, string regex)
        {
            List<string> matches = new List<string>();
            var collection = Regex.Matches(text, regex, RegexOptions.Singleline);

            foreach (var item in collection)
            {
                matches.Add(item.ToString());
            }
            return matches;
        }

        public static bool EndsWithDigits(this string str, int length)
        {
            return str.Substring(str.Length - length, length).IsDigits();
        }

        public static bool IsDigits(this string str)
        {
            return Regex.IsMatch(str, Regexes.NonNegativeInteger);
        }

        #endregion

        /// <summary>
        /// Saves List of strings in text file (one item per line)
        /// </summary>
        /// <param name="list">List to be saved.</param>
        /// <param name="filePath">File path to be saved in.</param>
        public static void SaveAsTxt(this List<string> list, string filePath)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            File.WriteAllLines(filePath, list.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToCommaString(this List<string> list)
        {
            return string.Join(", ", list.ToArray()).Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        #endregion

        #region String extensions

        /// <summary>
        /// Replace \r\n or \n by <br />
        /// from http://weblogs.asp.net/gunnarpeipman/archive/2007/11/18/c-extension-methods.aspx
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReplaceNewLine2Br(this string s)
        {
            return s.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }

        public static NameValueCollection ParseTag(string html, string tagName)
        {
            MatchCollection m1 = Regex.Matches(html, @"(<" + tagName + @"(.*?)>)", RegexOptions.IgnoreCase);
            string parse = m1[0].Groups[2].Value;

            var opt = StringSplitOptions.RemoveEmptyEntries;
            var split = parse.Split(new string[] { "=" }, opt);

            NameValueCollection tags = new NameValueCollection();

            for (int ii = 0; ii < split.Count(); ii++)
            {
                var newSplit = split[ii].Split(new string[] { " " }, StringSplitOptions.None);

                if (ii == 0)
                {
                    tags.Add(split[0].Trim(), split[1].Substring(0, split[1].LastIndexOf(" ")).Trim());
                }
                else if (ii == split.Count() - 1)
                {
                    var index = split[ii - 1].LastIndexOf(" ");
                    var prev = split[ii - 1];
                    tags.Add(prev.Substring(index, prev.Length - index).Trim(), split[ii].Trim());
                }
                else
                {
                    var index = split[ii - 1].LastIndexOf(" ");
                    var prev = split[ii - 1];
                    tags.Add(prev.Substring(index, prev.Length - index).Trim(), split[ii].Substring(0, split[ii].LastIndexOf(" ")).Trim());
                }
            }
            return tags;
        }

        /// <summary>
        /// Removes all FONT and SPAN tags, and all Class and Style attributes.
        /// Designed to get rid of non-standard Microsoft Word HTML tags.
        /// </summary>
        public static string GetCleanedWordHtml(this string html)
        {
            // start by completely removing all unwanted tags 
            html = Regex.Replace(html, @"<[/]?(font|span|xml|del|ins|[ovwxp]:\w+)[^>]*?>", "", RegexOptions.IgnoreCase);
            // then run another pass over the html (twice), removing unwanted attributes 
            html = Regex.Replace(html, @"<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<([^>]*)(?:class|lang|style|size|face|[ovwxp]:\w+)=(?:'[^']*'|""[^""]*""|[^\s>]+)([^>]*)>", "<$1$2>", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<style[^>]*?>[\s\S]*?<\/style>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<!--\[if [^>]*?\]>[\s\S]*?<!\[endif\]-->", "", RegexOptions.IgnoreCase);
            //<!--[if gte mso 10]>
            return html.TrimSafe();
        }

        /// <summary>
        /// Fix wrong url strings.
        /// </summary>
        /// <param name="url">Url string.</param>
        /// <param name="baseUri">Base Uri object.</param>
        /// <returns>Fixed uri string.</returns>
        public static string FixUrl(this string url, Uri baseUri = null)
        {
            if (url == null && string.IsNullOrEmpty(url))
                return url;

            url = url.Replace("about:", null).Replace("mailto:", null);

            if (url.StartsWith("www.") || url.StartsWith("http://www."))
                url = url.Replace("www.", null).Replace("http://www.", null);

            if (!url.StartsWith("http://"))
                url = "http://" + url;

            if (baseUri != null)
                return new Uri(baseUri, url).ToString();

            return url;
        }

        /// <summary>
        /// Removes HTML tags.
        /// </summary>
        /// <param name="html">Html code.</param>
        /// <returns>Cleaned text.</returns>
        public static string RemoveHtmlTags(this string html)
        {
            if (html == null)
                return null;

            string regularExpresion = "<[^<>]*>";
            Regex regex = new Regex(regularExpresion, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string bodyNoHTML = regex.Replace(html, "").Replace("&nbsp;", null).Trim();
            return bodyNoHTML;
        }

        /// <summary>
        /// Gets html string placed between passed strings
        /// </summary>
        /// <param name="originalString">String to be processed.</param>
        /// <param name="before">Before string</param>
        /// <param name="after">After string</param>
        /// <param name="boundType">BoundTypes value</param>
        /// <param name="comparison">StringComparison type</param>
        /// <returns>First found Html string</returns>
        public static string GetHtmlString(this string originalString, string before, string after, BoundTypes boundType = BoundTypes.None, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            if (string.IsNullOrEmpty(originalString)) return string.Empty;
            if (string.IsNullOrEmpty(before)) return string.Empty;
            if (string.IsNullOrEmpty(after)) return string.Empty;

            int a = originalString.IndexOf(before, 0, comparison);

            if (a == -1)
                return string.Empty;

            int val_start_idx = a + before.Length;

            int b = originalString.IndexOf(after, val_start_idx, comparison);

            if (b == -1)
                return string.Empty;

            int backup_a = originalString.LastIndexOf(before, b - 1, b - a, comparison);
            if (backup_a != -1)
            {
                a = backup_a;
                val_start_idx = a + before.Length;
            }

            string[] bx = new string[] { string.Empty, before, string.Empty, before };
            string[] ax = new string[] { string.Empty, string.Empty, after, after };

            return string.Concat(bx[(int)boundType], originalString.Substring(val_start_idx, b - val_start_idx), ax[(int)boundType]).Trim();
        }

        /// <summary>
        /// Checks if word is stop-word.
        /// </summary>
        /// <param name="word">Word to be checked.</param>
        /// <returns>True is stop-word, false otherwize.</returns>
        public static bool IsStopWord(this string str)
        {
            return DataCollections.StopWords.ToList().IndexOf(str) != -1;
        }

        /// <summary>
        /// Calculated words density.
        /// </summary>
        /// <param name="text">Text to be processed.</param>
        /// <param name="word">Word to be searched.</param>
        /// <returns>Word density.</returns>
        public static double GetWordDensity(this string text, string word)
        {
            return (double)text.GetWordOccurence(word) * 100.0 / (double)text.SplitToWords().Count();
        }

        /// <summary>
        /// Counts word occurance in text.
        /// </summary>
        /// <param name="text">Text to be searched in.</param>
        /// <param name="word">Word to be searched.</param>
        /// <returns>Number of word ocurence.</returns>
        public static int GetWordOccurence(this string text, string word)
        {
            var wordlist = text.SplitToWords();
            var g = wordlist.GroupBy(i => i);

            foreach (var grp in g)
            {
                if (grp.Key.Equals(word, StringComparison.OrdinalIgnoreCase))
                    return grp.Count();
            }
            return 0;
        }


        /// <summary>
        /// Safe trim.
        /// </summary>
        /// <param name="text">Text to be trimmed.</param>
        /// <returns>Trimmed string.</returns>
        public static string TrimSafe(this string text)
        {
            return (string.IsNullOrEmpty(text)) ? string.Empty : text.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int IndexOfAny(this string text, IEnumerable<string> array)
        {
            foreach (var item in array)
            {
                if (text.IndexOf(item) != -1)
                    return text.IndexOf(item);
            }
            return -1;
        }

        /// <summary>
        /// Removes whitespaces and special characters from string.
        /// </summary>
        /// <param name="text">Text string.</param>
        /// <returns>Cleaned string.</returns>
        public static string RemoveSpecialCharacters(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            string chars = @"./\|}{[:;+=_)(*&^%$#@!?~`"",><-";
            string temp = text;



            foreach (char ch in chars.ToCharArray())
            {
                temp = temp.Replace(ch.ToString(), null);
            }

            return temp.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Removes dublicated characters.
        /// </summary>
        /// <param name="str">String to be processed.</param>
        /// <param name="character">Character to be removed.</param>
        /// <returns>Cleaned string.</returns>
        public static string RemoveDublicatedCharacters(this string str, string character)
        {
            StringBuilder sb = new StringBuilder(str);

            string template = character + character;

            while (sb.ToString().Contains(template))
                sb.Replace(template, character);

            return sb.ToString();
        }

        /// <summary>
        /// Removes tabs, double whitespaces from string.
        /// </summary>
        /// <param name="text">String to be processed.</param>
        /// <returns>Cleaned string.</returns>
        public static string RemoveWhitespaces(this string text)
        {
            Regex r = new Regex(@"\s+");
            return r.Replace(text, " ");
        }

        /// <summary>
        /// Splits text to words
        /// </summary>
        /// <param name="text">Text to be splitted</param>
        /// <returns>List of words</returns>
        public static List<string> SplitToWords(this string text)
        {
            return text.GetMatches(@"[^\W\d](\w|[-']{1,2}(?=\w))*");
            /*
            var list = new List<string>();
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Replace(System.Environment.NewLine, " ");
                string[] arrWords = text.Split(new string[] { " ", "-", "]", "[", "/", ")", "(", "{", "}" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in arrWords)
                {
                    list.Add(word.RemoveSpecialCharacters());
                }
            }
            return list;*/
        }

        /// <summary>
        /// Counts words occurence.
        /// </summary>
        /// <param name="text">Text to be processed.</param>
        /// <returns>SortedList with words and their occurences.</returns>
        public static SortedList<string, int> GetWordsWithOccurences(this string text)
        {
            var wordlist = text.SplitToWords();
            var g = wordlist.GroupBy(i => i);

            SortedList<string, int> list = new SortedList<string, int>();

            foreach (var grp in g)
                list.Add(grp.Key, grp.Count());

            return list;
        }

        /// <summary>
        /// Converts string from one encoding to another.
        /// </summary>
        /// <param name="value">String to be converted.</param>
        /// <param name="src">Source encoding.</param>
        /// <param name="trg">Target encoding.</param>
        /// <returns>Encoded string.</returns>
        public static string Encode(this string value, Encoding src, Encoding trg)
        {
            if (value == (string)null)
                throw new ArgumentNullException("value");
            if (trg == (Encoding)null)
                throw new ArgumentNullException("trg");
            if (src == (Encoding)null)
                throw new ArgumentNullException("src");

            Decoder dec = src.GetDecoder();
            byte[] ba = trg.GetBytes(value);
            int len = dec.GetCharCount(ba, 0, ba.Length);
            char[] ca = new char[len];
            dec.GetChars(ba, 0, ba.Length, ca, 0);
            return new string(ca);
        }


        [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
        private static extern bool PathCompactPathEx([Out] StringBuilder pszOut, string szPath, int cchMax, int dwFlags);

        /// <summary>
        /// Gets short path.
        /// </summary>
        /// <param name="path">Original path.</param>
        /// <param name="length">Path length.</param>
        /// <returns>Short path.</returns>
        public static string GetShortPath(this string path, int length)
        {
            StringBuilder sb = new StringBuilder();
            PathCompactPathEx(sb, path, length, 0);
            return sb.ToString();
        }

        /// <summary>
        /// Gets short path.
        /// </summary>
        /// <param name="path">Original path.</param>
        /// <param name="maxLength">Max length.</param>
        /// <returns>Short path.</returns>
        public static string GetShortPath2(this string path, int maxLength)
        {
            // <pex>
            if (path == (string)null)
                throw new ArgumentNullException("path");
            // </pex>
            const string Ellipses = "...";
            int length = path.Length;
            string returnPath;
            if (length > maxLength)
            {
                if (maxLength <= 3)
                {
                    returnPath = Ellipses;
                }
                else
                {
                    int i = path.LastIndexOf('\\');
                    if (i < 0)
                    {
                        returnPath = path.Substring(0, maxLength - 3) + Ellipses;
                    }
                    else
                    {
                        int delta = length + 3 - maxLength;
                        if (i < delta)
                        {
                            returnPath = path.Substring(0, maxLength - 3) + Ellipses;
                        }
                        else
                        {
                            returnPath = path.Substring(0, i - delta) + Ellipses + path.Substring(i);
                        }
                    }
                }
            }
            else
            {
                returnPath = path;
            }
            return returnPath;
        }

        /// <summary>
        /// Converts string from UTF-8 to Windows-1251
        /// </summary>
        /// <param name="value">String to be converted.</param>
        /// <returns>String in Windows-1251 encoding.</returns>
        private static string ToWindows1251(this string value)
        {
            if (value == (string)null)
                throw new ArgumentNullException("value");

            Decoder dec = Encoding.UTF8.GetDecoder();
            byte[] ba = Encoding.GetEncoding("windows-1251").GetBytes(value);
            int len = dec.GetCharCount(ba, 0, ba.Length);
            char[] ca = new char[len];
            dec.GetChars(ba, 0, ba.Length, ca, 0);
            return new string(ca);
        }

        ///// <summary>
        ///// Processes string to uri object.
        ///// Relative addresses are processed to absolute ones.
        ///// Links are cleaned from "about" and "blank" text.
        ///// </summary>
        ///// <param name="href">Url string to be processed.</param>
        ///// <param name="baseUri">Base Uri.</param>
        ///// <returns></returns>
        //public static Uri ToAbsoluteUri(this string href, Uri baseUri)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(href)) return null;

        //        // Clean href
        //        href = href.Replace("about:", null).Replace("blank#", null);

        //        if (href.Contains("../") || href.StartsWith("/"))
        //        {
        //            if (baseUri != null)
        //                return new Uri(baseUri, href);
        //        }

        //        return new Uri(href);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public static Uri ToAbsoluteUri(this string href, string baseUri)
        //{

        //    return href.ToAbsoluteUri(new Uri(baseUri));
        //}

        /// <summary>
        /// Reduce string to shorter preview which is optionally ended by some string (...).
        /// </summary>
        /// <param name="s">string to reduce</param>
        /// <param name="count">Length of returned string including endings.</param>
        /// <param name="endings">optional edings of reduced text</param>

        /// <example>
        /// string description = "This is very long description of something";
        /// string preview = description.Reduce(20,"...");
        /// produce -> "This is very long..."
        /// </example>
        /// <returns></returns>
        public static string Reduce(this string s, int count, string endings)
        {
            if (count < endings.Length)
                throw new Exception("Failed to reduce to less then endings length.");
            int sLength = s.Length;
            int len = sLength;
            if (endings != null)
                len += endings.Length;
            if (count > sLength)
                return s; //it's too short to reduce
            s = s.Substring(0, sLength - len + count);
            if (endings != null)
                s += endings;
            return s;
        }

        // Get Ip Address from DomainName
        public static List<IPAddress> GetIPAddress(this string hostname)
        {
            return Dns.GetHostAddresses(hostname).ToList();
        }

        // Get HostName from IPAddress
        static List<string> GetDomainNames(this string ipaddress)
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(ipaddress);
            return hostEntry.Aliases.ToList();
        }

        /// <summary>
        /// Remove accent from strings 
        /// </summary>
        /// <example>
        ///  input:  "Příliš žluťoučký kůň úpěl ďábelské ódy."
        ///  result: "Prilis zlutoucky kun upel dabelske ody."
        /// </example>
        /// <param name="s"></param>
        /// <remarks>Founded at http://stackoverflow.com/questions/249087/
        /// how-do-i-remove-diacritics-accents-from-a-string-in-net</remarks>
        /// <returns>String without accents.</returns>
        public static string RemoveDiacritics(this string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }


        #endregion

        #region Uri extensions

        /// <summary>
        /// Determines if connection exists.
        /// </summary>
        /// <param name="uri">Uri to be checked.</param>
        /// <returns>True is exists, false otherwize.</returns>
        public static bool ConnectionExists(this Uri uri)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets domain level.
        /// </summary>
        /// <param name="uri">Uri to be processed.</param>
        /// <returns>Domain level.</returns>
        public static int GetDomainLevel(this Uri uri)
        {
            if (uri == (Uri)null)
                throw new ArgumentNullException("uri");

            return uri.Host.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Gets Google PageRank.
        /// </summary>
        /// <param name="uri">Uri to be checked.</param>
        /// <returns>Google PageRank.</returns>
        public static string GetGooglePageRank(this Uri uri)
        {
            return new GooglePageRankService().ProcessUrl(uri.ToString()).PageRank;
        }

        /// <summary>
        /// Gets zone name.
        /// </summary>
        /// <example>'http://microsoft.com/' will return '.com'</example>
        /// <example>'http://microsoft.com.ua/' will return '.com.ua'</example>
        /// <param name="uri">Uri to be processed.</param>
        /// <returns>Zon name.</returns>
        public static string GetZone(this Uri uri)
        {
            int index = uri.Host.IndexOf(".");
            return uri.Host.Substring(index, uri.Host.Length - index);
        }

        /// <summary>
        /// Gets server status code.
        /// </summary>
        /// <param name="uri">Uri to be processed.</param>
        /// <returns>Server status code.</returns>
        public static HttpStatusCode GetServerStatusCode(this Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            var response = (HttpWebResponse)request.GetResponse();
            return response.StatusCode;
        }

        #endregion
    }
}
