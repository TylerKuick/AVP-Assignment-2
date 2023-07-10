using System.IO;

namespace EmployeeClass {

    // Part (a)
    public class Employee {
        // Private attributes
        private string nric = "";
        private string fullName = "";
        private string salutation = "";
        private string designation = "";
        private string department = "";
        private string mobileNo = "";
        private string hireType = "";
        private double salary;
        private double monthlyPayout;
        private DateTime startDate;

        // Public get and set methods 
        public string Nric {
            get { return this.nric; } 
            set { this.nric = value; }
        }

        public string FullName {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        public string Salutation {
            get { return this.salutation; }
            set { this.salutation = value; }
        }

        public string Designation {
            get { return this.designation; }
            set { this.designation = value; }
        }

        public string Department {
            get { return this.department; }
            set { this.department = value; } 
        }

        public string MobileNo {
            get { return this.mobileNo; }
            set { this.mobileNo = value; }
        }

        public string HireType {
            get { return this.hireType; }
            set { this.hireType = value; }
        }

        public double Salary { 
            get { return this.salary; }
            set { this.salary = value; } 
        }

        public double MonthlyPayout {
            get { return this.monthlyPayout; }
            set { this.monthlyPayout = value; }
        }

        public DateTime StartDate {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        // Initialise object
        public Employee (string nric, string fullName, string salutation, DateTime startDate, string designation, string department, string mobileNo, string hireType, double salary) {
            this.Nric = nric;
            this.FullName = fullName;
            this.Salutation = salutation;
            this.Designation = designation;
            this.Department = department;
            this.MobileNo = mobileNo;
            this.HireType = hireType;
            this.Salary = salary;
            this.MonthlyPayout = 0.0;
            this.StartDate = startDate;
        }

        // Formating Methods 
        public string formatCorpAdmin() {
            string info = $"{this.FullName},{this.Designation},{this.Department}";
            return info;
        }

        public string formatProcDep() {
            string info = $"{this.Salutation},{this.FullName},{this.MobileNo},{this.Designation},{this.Department}";
            return info;
        }

        public string formatITDep() {
            string info = $"{this.Nric},{this.FullName},{this.StartDate.ToString("dd/MM/yyyy")},{this.Department},{this.MobileNo}";
            return info;
        }
    }     
}
