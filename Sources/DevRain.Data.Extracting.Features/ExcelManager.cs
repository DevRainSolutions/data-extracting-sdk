// ============================================================================
// <copyright file="ExcelManager.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting.Office
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Xml;
    using System.Xml.Xsl;

    public class ExcelManager
    {
        private string XlsFileName { get; set; }

        public ExcelManager(string xlsFileName)
        {
            this.XlsFileName = xlsFileName;
        }

        public static DataSet exceldata(string filelocation)
        {

            DataSet ds = new DataSet();

            OleDbCommand excelCommand = new OleDbCommand(); OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();

            string excelConnStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filelocation + "; Extended Properties =Excel 8.0;";
            OleDbConnection excelConn = new OleDbConnection(excelConnStr);

            excelConn.Open();
            DataTable dtPatterns = new DataTable(); excelCommand = new OleDbCommand("SELECT UUID, `PATTERN` as PATTERN, `PLAN` as PLAN FROM [PATTERNS$]", excelConn);

            excelDataAdapter.SelectCommand = excelCommand;

            excelDataAdapter.Fill(dtPatterns);
            dtPatterns.TableName = "Patterns";

            ds.Tables.Add(dtPatterns);
            return ds;

        }

        public void SaveFromXml(string xmlFileName) 
        {
            
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFileName);
            string xml = CreateWorkbook(ds);
            File.WriteAllText(this.XlsFileName, xml);
        }

        private static string CreateWorkbook(DataSet ds)
        {
            XmlDataDocument xmlDataDoc = new XmlDataDocument(ds);
            XslTransform xt = new XslTransform();
            StreamReader reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Excel.xsl"));
            XmlTextReader xRdr = new XmlTextReader(reader);
            xt.Load(xRdr, null, null);
            StringWriter sw = new StringWriter();
            xt.Transform(xmlDataDoc, null, sw, null);
            return sw.ToString();
        }

        public DataSet GetDataSet(string spreadName) 
        {

            FileInfo fi = new FileInfo(this.XlsFileName);
            //File.Copy(this.XlsFileName, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fi.Name), true);

            // Put user code to initialize the page here
            // Create connection string variable. Modify the "Data Source"
            // parameter as appropriate for your environment.
            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                 "Data Source=" + this.XlsFileName + ";" +
                 @"Extended Properties=""Excel 8.0;HDR=YES;IMEX=1""";

            // Create connection object by using the preceding connection string.
            OleDbConnection objConn = new OleDbConnection(sConnectionString);

            // Open connection with the database.
            objConn.Open();

            // The code to follow uses a SQL SELECT command to display the data from the worksheet.

            // Create new OleDbCommand to return data from worksheet.
            OleDbCommand objCmdSelect = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", spreadName), objConn);


            // Create new OleDbDataAdapter that is used to build a DataSet
            // based on the preceding SQL SELECT statement.
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();

            // Pass the Select command to the adapter.
            objAdapter1.SelectCommand = objCmdSelect;

            // Create new DataSet to hold information from the worksheet.
            DataSet objDataset1 = new DataSet();

            // Fill the DataSet with the information from the worksheet.
            objAdapter1.Fill(objDataset1);

            // Clean up objects.
            objConn.Close();

            return objDataset1;
        }
    }
}


/*
 
 Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=filename.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim dGrid As New DataGrid
        dGrid.DataSource = tempDataset
        dGrid.DataBind()

        dGrid.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())
        Response.End()
 */

//http://www.csvreader.com/csv_benchmarks.php CSV Reader

//http://blogs.vertigosoftware.com/liam/archive/2005/04/05/Reading_Excel_data_into_a_DataGrid.aspx