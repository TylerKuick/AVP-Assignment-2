using EmployeeClass;
using System.Globalization;

namespace SectionA {
    public class Program {

        // Part (b)
        public static List<Employee> readHRMasterList() {
            List<Employee> emp_list = new List<Employee>();
            // Read HRMasterlist file for employee records
            StreamReader sr = new StreamReader("../HRMasterlist.txt");
            var line = sr.ReadLine();
            while (line != null) {
                // Split each line by their attributes
                string[] args = line.Split("|"); 

                // Add employee objects into a list
                emp_list.Add(new Employee(
                    args[0],  // NRIC 
                    args[1],  // Name
                    args[2],  // Salutation
                    DateTime.Parse(args[3], // Start Date
                        new CultureInfo("en-SG")), 
                    args[4],  // Designation
                    args[5],  // Department
                    args[6],  // Mobile No
                    args[7],  // Hire Type
                    Double.Parse(args[8]) // Salary
                    )
                );
                
                // Read next line
                line = sr.ReadLine(); 
            }
            // Close File
            sr.Close();
            
            return emp_list;
        }


        // Part (c)
        static void generateInfoForCorpAdmin(List<Employee> emp_list) {
            // Output file to output folder
            StreamWriter sw = new StreamWriter("./output/CorporateAdmin.txt");
            foreach (var emp in emp_list){
                sw.WriteLine(emp.formatCorpAdmin());
            }
            // Close File
            sw.Close();
        }

        static void generateInfoForProcurement(List<Employee> emp_list) {
            // Output file to output folder
            StreamWriter sw = new StreamWriter("./output/Procurement.txt");
            foreach (var emp in emp_list){
                sw.WriteLine(emp.formatProcDep());
            }
            // Close File
            sw.Close();
        }

        static void generateInfoForITDepartment(List<Employee> emp_list) {
            // Output file to output folder
            StreamWriter sw = new StreamWriter("./output/ITDepartment.txt");
            foreach (var emp in emp_list){
                sw.WriteLine(emp.formatITDep());
            }
            // Close File
            sw.Close();
        }
        
        // Part (d)
        public delegate void generateInfo(List<Employee> emp_list);

        static void Main() {
            List<Employee> emp_list = readHRMasterList(); // Read employee records and store into a list
            generateInfo CorpAdmin = new generateInfo(generateInfoForCorpAdmin);    // Delegate object
            generateInfo ProcDep = new generateInfo(generateInfoForProcurement);    // Delegate object
            generateInfo ITDep = new generateInfo(generateInfoForITDepartment);     // Delegate object
            generateInfo del = CorpAdmin + ProcDep + ITDep;     // Calling multiple delegate objects with one call 

            del(emp_list);  // Invoke CorpAdmin, ProcDep, and ITDep delegates with the list of employee objects as argument
        }
    }
}


