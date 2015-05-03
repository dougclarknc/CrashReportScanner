using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using ExcelLibrary.SpreadSheet;

//maybe checkout OpenXML

namespace CrashReportScanner
{
    public class CrashExcel
    {
        private Workbook excel;
        private Worksheet sheet;
        private CellCollection cells;
        public DataTable excelTable;
        public List<string> localPD = new List<string> {
            "Apex PD", "Cary PD", "Garner PD", "Raleigh PD", "Wake Forest PD", "Wake HP", "Durham PD", "Durham HP", "Granville HP",
            "Clayton PD", "Smithfield PD", "Selma PD", "Johnston HP"
        };

        public string outputFilePath;       

        public CrashExcel(String date, String inputPath)
        {
            this.outputFilePath = inputPath + "\\" + date + ".xls";
            using (FileStream ouputFile = System.IO.File.Create(this.outputFilePath)) { } ;
            WebClient client = new WebClient();
            client.Credentials = new System.Net.NetworkCredential("hsfh", "trinity");
            client.DownloadFile("http://www.nccrashreports.com/download?file=triangle/" + date + ".xls", this.outputFilePath);
            
            this.excel = Workbook.Load(outputFilePath);
            this.sheet = excel.Worksheets[0];
            this.cells = sheet.Cells;

            client.Dispose();
        }

        public CrashExcel(String date, String inputPath, DataTable dataTable) {
            this.outputFilePath = inputPath + "//" + date + "output.xls";            
            this.excel = new Workbook();
            this.sheet = new Worksheet("" + date + "output");
            this.cells = sheet.Cells;

            dataTableToExcel(dataTable);
        }

        public DataTable excelToDataTable()
        {
            excelTable = new DataTable();
            excelTable.Columns.Add("First");
            excelTable.Columns.Add("Last");
            excelTable.Columns.Add("Address");
            excelTable.Columns.Add("City");
            excelTable.Columns.Add("State");
            excelTable.Columns.Add("Zip");
            excelTable.Columns.Add("Police Dept");

            int condition;
            int damage;
            bool cValid;
            bool dValid;
            for (int rowIndex = cells.FirstRowIndex + 1; rowIndex <= cells.LastRowIndex; rowIndex++)
            {
                if (localPD.Contains(cells[rowIndex, 7].ToString()))
                {
                    cValid = Int32.TryParse(cells[rowIndex, 10].ToString(), out condition);
                    dValid = Int32.TryParse(cells[rowIndex, 11].ToString(), out damage);

                    Crash newCrash = new Crash(cells[rowIndex, 0].ToString(),
                                           cells[rowIndex, 1].ToString(),
                                           cells[rowIndex, 2].ToString(),
                                           cells[rowIndex, 3].ToString(),
                                           cells[rowIndex, 4].ToString(),
                                           cells[rowIndex, 5].ToString(),
                                           cells[rowIndex, 6].ToString(),
                                           cells[rowIndex, 7].ToString(),
                                           (cValid) ? condition : 5,
                                           (dValid) ? damage : 0);
                    if (newCrash.isValid()) //also must be from Durham Granville Johnson Wake county
                    {
                        excelTable.LoadDataRow(newCrash.toArray(), true);
                    }
                }
            }
            return excelTable;
        }

        private void dataTableToExcel(DataTable table) {
            for (int i = 0; i < table.Columns.Count - 1 ; i++) {
                cells[0, i] = new Cell(table.Columns[i].ColumnName);
                for (int j = 0; j < table.Rows.Count; j++) {
                    cells[j + 1, i] = new Cell(table.Rows[j][i]);
                }
            }
            excel.Worksheets.Add(sheet);
            excel.Save(outputFilePath);
        }
    }
}
