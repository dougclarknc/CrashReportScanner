using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrashReportScanner
{
    public partial class Form1 : Form
    {
        public CRS crs;
        public Form1()
        {
            crs = new CRS();
            InitializeComponent();
        }

        private void locationButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }

        private void createOutputButton_Click(object sender, EventArgs e)
        {
            // can be put in a method
            crs.date = "" + datePicker.SelectionStart.Month.ToString("d2") + datePicker.SelectionStart.Day.ToString("d2") +
                        datePicker.SelectionStart.Year.ToString().Substring(2);
            crs.outputFilePath = folderBrowserDialog1.SelectedPath;
            crs.crashExcel = new CrashExcel(crs.date, crs.outputFilePath);

            dataGridView1.DataSource = crs.crashExcel.excelToDataTable();
            dataGridView1.Update();
            
        }

        private void pdfButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            crs.crashPDF = new CrashPDF(crs.outputFilePath, crs.date);
            Cursor.Current = Cursors.Default;
            Application.DoEvents();
        }

        private void updateOutputButton_Click(object sender, EventArgs e) {
            crs.outputExcel = new CrashExcel(crs.date, crs.outputFilePath, crs.crashExcel.excelTable);
        }
    }
}
