using System;
using System.Threading.Tasks;

namespace CrashReportScanner
{
    public class Crash
    {
        private const int DMG_THRESHOLD = 3000;

        private const int MAX_DAMAGE = 7000;

        private const int CONDITION_THRESHOLD = 4;

        private string af;
        public void setAF(string af) { this.af = af; }
        public string getAF() { return this.af; }

        public string firstName;
        public void setFirstName(string fn) { this.firstName = fn; }
        public string getFirstName() { return this.firstName; }

        public string lastName;
        public void setLastName(string ln) { this.lastName = ln; }
        public string getLastName() { return this.lastName; }

        public string streetAddress;
        public void setStreetAddress(string sa) { this.streetAddress = sa; }
        public string getStreedAddress() { return this.streetAddress; }

        public string city;
        public void setCity(string c) { this.city = c; }
        public string getCity() { return this.city; }

        public string state;
        public void setState(string state) { this.state = state; }
        public string getState() { return this.state; }

        public string zip;
        public void setZip(string z) { this.zip = z; }
        public string getZip() { return this.zip; }

        public string policeDept;
        public void setpoliceDept(string pd) { this.policeDept = pd; }
        public string getpoliceDept() { return this.policeDept; }

        public int damage;
        public void setDamage(int damage) { this.damage = damage; }
        public int getDamage() { return this.damage; }

        public int condition;
        public void setCondition(int condition) { this.condition = condition; }
        public int getContition() { return this.condition; }

        public Crash(string af, string firstName, string lastName, string streetAddress, string city, string state, string zip, string policeDept, int damage, int condition)
        {
            this.af = af;
            this.firstName = firstName;
            this.lastName = lastName;
            this.streetAddress = streetAddress;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.policeDept = policeDept;
            this.damage = damage;
            this.condition = condition;
        }

        public string toString()
        {
            return firstName + ", " + lastName + ", " +
                streetAddress + ", " + city + ", " + state +
                ", " + zip;
        }

        public bool isValid()
        {
            return ((((damage >= DMG_THRESHOLD) && (condition <= CONDITION_THRESHOLD) && (condition != 0)) && !isLiable()) ||
                 isPedestrian() || maxDamage());
        }

        public bool isPassenger()
        {
            return af.ToLower().Contains("passenger");
        }

        public bool isPedestrian()
        {
            return af.ToLower().Contains("pedestrian");
        }

        public bool isLiable()
        {
            return af.ToLower().Equals("af driver");
        }

        public bool maxDamage()
        {
            return damage >= MAX_DAMAGE;
        }

        public string[] toArray()
        {
            string[] strArr = new string[7];
            //strArr[0] = this.af;
            strArr[0] = this.firstName;
            strArr[1] = this.lastName;
            strArr[2] = this.streetAddress;
            strArr[3] = this.city;
            strArr[4] = this.state;
            strArr[5] = this.zip;
            strArr[6] = this.policeDept;
            //strArr[8] = this.damage.ToString();
            //strArr[9] = this.condition.ToString();

            return strArr;
        }
    }
}