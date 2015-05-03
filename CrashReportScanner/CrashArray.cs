using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelLibrary.SpreadSheet;

namespace CrashReportScanner {
    public class CrashArray {
        private Crash[] crashArr;

        public CrashArray(int size)
        {
            this.crashArr = new Crash[size];
        }

        public void add(int location, Crash crash)
        {
            if (location < this.crashArr.Length)
            {
                this.crashArr[location] = crash;
            } else { //user is implementing manual add
                this.crashArr = manualAdd(location, crash);
            }
        }

        private Crash[] manualAdd(int location, Crash crash)
        {
            Crash[] manAddArr = new Crash[this.crashArr.Length];
            for (int i = 0; i < this.crashArr.Length; i++)
            {
                manAddArr[i] = this.crashArr[i];
            }
            manAddArr[location] = crash;
            return manAddArr;
        }

        public Crash getCrash(int location)
        {
            return this.crashArr[location];
        }

        public String getCrashString(int location)
        {
            return this.crashArr[location].toString();
        }

        public String getCrashPD(int location)
        {
            return this.crashArr[location].policeDept;
        }

        public void populateArray() {

        }
    }
}
