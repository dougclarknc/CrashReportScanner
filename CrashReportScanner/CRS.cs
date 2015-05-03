using System;
using System.Threading.Tasks;

namespace CrashReportScanner
{
    public class CRS
    {
        public String date;
        public CrashExcel crashExcel;
        public CrashExcel outputExcel;
        public String outputFilePath;
        public CrashPDF crashPDF;
        public CRS(string date, string filePath, CrashExcel cxl)
        {
this.date = date;
this.outputFilePath = filePath;
this.outputExcel = cxl;
        }
    }
}
