namespace HabraPdfReader
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using DevRain.Data.Extracting;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool EndsWithInt(string link) 
        {
            var s = link.Split(new string[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
            string last = s.Last();
            int result;
            return int.TryParse(last, out result);
        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            try
            {
                List<ResultItem> list = new List<ResultItem>();

                for (int i = 1; i <= (int)pCount.Value; i++)
                {
                    HtmlProcessor proc = new HtmlProcessor(new Uri(string.Format("http://habrahabr.ru/new/page{0}/", i)));

                    var links = from l in proc.Links
                                where l.Attributes["class"] == "topic" && l.Attributes["href"].IndexOf("#") == -1
                                select new ResultItem
                                {
                                    Link = l.Attributes["href"],
                                    TopicName = l.InnerText
                                };

                    //var links = from l in proc.Links
                    //            where l.Class == "topic" && EndsWithInt(l.Href) == true
                    //            select new ResultItem
                    //            {
                    //                Link = l.Href,
                    //                TopicName = l.Text.ToWindows1251()
                    //            };

                    foreach (var item in links.Distinct()) 
                    {
                        list.Add(item);
                    }
                }

                dataGridView.DataSource = list;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error!!!!");
            }

        }

        private delegate void MyDelegate();

        private void Download() 
        {
            List<Uri> list = new List<Uri>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value == null) continue;
                
                if ((bool)row.Cells[0].Value == true)
                    list.Add(new Uri(string.Format("http://www.htm2pdf.co.uk/?url={0}", row.Cells["Link"].Value)));
            }

            
            this.Invoke((MyDelegate)delegate
            {
                progressBar1.Maximum = list.Count;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;
                groupBox1.Controls.Add(progressBar1);
            });

            int i = 1;
            foreach (var link in list)
            {
                try
                {
                    //HtmlProcessor pp = new HtmlProcessor(new UriHtmlExtractor(link).DocumentHtml);
                    //var pdf = pp.Links.Where(ll => ll.InnerText == "Download PDF").FirstOrDefault();

                    //if (pdf != null)
                    //{
                    //    Uri u = pdf.Attributes["href"].FixUrl(new Uri("http://www.htm2pdf.co.uk/"));
                    //    UriHtmlExtractor dProc = new UriHtmlExtractor(u);
                    //    dProc.Download(Path.Combine(folderBrowserDialog.SelectedPath, i.ToString() + ".pdf"));

                    //    this.Invoke((MyDelegate)delegate
                    //    {
                    //        tbLog.Text += "Download " + i.ToString() + ".pdf\n\n";
                    //    });

                    //    i++;
                    //}
                }
                catch (Exception ex)
                {
                    this.Invoke((MyDelegate)delegate
                    {
                        tbLog.Text += ex.Message + "\n\n";
                    });
                }

                this.Invoke((MyDelegate)delegate
                {
                    ++progressBar1.Value;
                });
            }

            MessageBox.Show("Done!");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowNewFolderButton = true;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Thread t = new Thread(new ThreadStart(Download));
                t.Start();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != -1) 
            { 
                Process.Start(dataGridView.Rows[e.RowIndex].Cells["Link"].Value.ToString());
            }
        }

        private void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows) 
            {
                row.Cells[0].Value = cbCheckAll.Checked;
            }
        }
    }
}
