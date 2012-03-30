// ============================================================================
// <copyright file="MainForm.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace GooglePageRankChecker
{
    using System;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;
    using DevRain.Data.Extracting;
    using DevRain.Data.Extracting.Features;
     
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                ExcelCreator excel = new ExcelCreator((DataTable)dataGridView1.DataSource);

                saveFileDialog1.Filter = "xls files (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
                {
                    excel.Save(saveFileDialog1.FileName);
                }
            }
            else 
            {
                MessageBox.Show("List is empty!");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Text = File.ReadAllText(openFileDialog1.FileName);
            }           
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = richTextBox.Text.Split(new string[] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);

                dataGridView1.AutoGenerateColumns = true;

                DataTable dt = new DataTable("Test");
                dt.Columns.Add("Website", typeof(string));
                dt.Columns.Add("PageRank", typeof(string));
                object[] dr = new object[2];

                foreach (var line in lines)
                {
                    dr[0] = line;
                    UriHtmlExtractor proc = new UriHtmlExtractor(new Uri(line));
                    dr[1] = proc.GooglePageRank;
                    dt.Rows.Add(dr);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Update();
                }

                btnSave.Enabled = true;

                MessageBox.Show("Done!");
            }
            catch (Exception exept)
            {
                //Let the user know what went wrong.
                MessageBox.Show(exept.Message + " \n" + exept.Source);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            richTextBox.Text = @"http://google.com/
http://microsoft.com/
http://apple.com/
http://stackoverflow.com/";
        }
    }
}