using System;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;
using System.Net;

namespace CrashReportScanner {
    public class CrashPDF {
        private string outputDirectory;
        private string date;
        private string outputFilePath;
        private string[] downloadTowns = new string[]
        {
            "wake", "wake_forest", "apex", "cary", "garner", "raleigh", "durham_pd", "durham", "granville", "clayton", "smithfield", "selma", "johnston"
        };
        private string[] downloadPD = new string[] 
        {
            "wakeHP", "wakeforestPD", "apexPD", "caryPD", "garnerPD", "raleighPD", "durhamPD",
            "durhamHP", "granvilleHP", "claytonPD", "smithfieldPD", "selmaPD", "johnstonHP"
        };

        public string getDate() {
            return this.date;
        }

        public void setDate(string d) {
            this.date = d;
        }

        public string getOutputDirecory() {
            return outputDirectory;
        }
        public void setOutputDirectory(string dir) {
            this.outputDirectory = dir;
        }

        public void generatePDF() {
            downloadPDF();
            combinePDFs();
        }

        public void downloadPDF() {
            bool moreFiles = true;
            int fileCount = 1;
            string downloadLocation;
            string downloadTest;
            for (int i = 0; i < downloadTowns.Length; i++) {
                while (moreFiles) { //check for multiple parts
                    try {
                        WebClient client = new WebClient();
                        client.Credentials = new NetworkCredential("hsfh", "trinity");
                        this.outputFilePath = outputDirectory + "\\" + date + downloadPD[i] + " pt" + fileCount + ".pdf";
                        using (FileStream outputFile = System.IO.File.Create(@outputFilePath)) {
                        };
                        downloadLocation = "http://www.nccrashreports.com/download?&location=triangle&file=triangle/" +
                            downloadTowns[i] + "/" + date + downloadPD[i] + " pt" + fileCount + ".pdf";
                        downloadTest = client.DownloadString(downloadLocation);
                        if (!downloadTest.Contains("Not Found!")) {
                            client.DownloadFile(downloadLocation, @outputFilePath);
                            fileCount++;
                        } else { //file doesnt exist, no multiple files
                            moreFiles = false;
                            fileCount = 1;
                            System.IO.File.Delete(@outputFilePath);
                        }
                        client.Dispose();
                    } catch (Exception e) {
                        Console.Write(e);
                    }
                } 
                try { //only one file
                    WebClient client = new WebClient();
                    client.Credentials = new NetworkCredential("hsfh", "trinity");
                    this.outputFilePath = outputDirectory + "\\" + date + downloadPD[i] + ".pdf";
                    using (FileStream outputFile = System.IO.File.Create(@outputFilePath)) {
                    };
                    downloadLocation = "http://www.nccrashreports.com/download?&location=triangle&file=triangle/" +
                        downloadTowns[i] + "/" + date + downloadPD[i] + ".pdf";
                    downloadTest = client.DownloadString(downloadLocation);
                    if (!downloadTest.Contains("Not Found!")) {
                        client.DownloadFile(downloadLocation, @outputFilePath);
                    } else { //file doesnt exist, no multiple files
                        moreFiles = false;
                        fileCount = 1;
                        System.IO.File.Delete(@outputFilePath);
                    }
                    client.Dispose();
                } catch (Exception e) {
                    Console.Write(e);
                }
                moreFiles = true;
            }
        }

        public CrashPDF(string output, string date) {
            this.date = date;
            this.outputDirectory = output;
            generatePDF();
        }

        private void combinePDFs() {
        //find pd of each person in dataTable
            //search pd pdf for that persons name
            //get how many pages that report is
            //add that report to new combinedPDF
            //alert user to unsearchable drivers
        }
    }
}
