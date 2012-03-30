// ============================================================================
// <copyright file="ExcelCreator.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting.Features
{
    using System.Data;
    using CarlosAg.ExcelXmlWriter;
    
    /// <summary>
    /// http://www.carlosag.net/Tools/ExcelXmlWriter/
    /// </summary>
    public class ExcelCreator
    {
        private Workbook book;

        public ExcelCreator(DataTable dt) 
        {
            if (string.IsNullOrEmpty(dt.TableName))
                dt.TableName = "table";

            book = new Workbook();
            Worksheet sheet = book.Worksheets.Add(dt.TableName ?? "Worksheet 1");

            WorksheetRow wRow = sheet.Table.Rows.Add();

            foreach (DataColumn col in dt.Columns) 
            {
                wRow.Cells.Add(col.Caption);
            }

            foreach (DataRow row in dt.Rows) 
            {
                wRow = sheet.Table.Rows.Add();

                foreach (object cell in row.ItemArray)
                {
                    string cellValue = (cell.GetType().Equals(typeof(System.DBNull))) ? string.Empty : (string)cell;
                    wRow.Cells.Add(cellValue);
                }
            }
        }

        public void Save(string path) 
        {
            book.Save(path);
        }
    }
}
