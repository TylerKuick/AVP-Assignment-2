using System;
using SectionA;

namespace SectionB {
    public class Program {
        // Part (a)
        public enum hire_Types {
            FullTime,
            PartTime,
            Hourly
        }

        // Part (c)
        public static void processPayroll(List<EmployeeClass.Employee> emp_list) {
            double total_payout = 0;
            string ft = hire_Types.FullTime.ToString();
            string pt = hire_Types.PartTime.ToString();
            string hr = hire_Types.Hourly.ToString();
            
            foreach (var emp in emp_list) {
                if (emp.HireType == ft) {
                    emp.MonthlyPayout = emp.Salary;
                }
                else if (emp.HireType == pt) {
                    emp.MonthlyPayout = emp.Salary * 0.4;
                }
                else if (emp.HireType == hr) {
                    emp.MonthlyPayout = emp.Salary * 0.2;
                }
                Console.WriteLine(@$"
                    {emp.FullName} ({emp.Nric})
                    {emp.Designation}
                    {emp.HireType} Payout: ${emp.MonthlyPayout}
                    ------------------------------------");
                total_payout += emp.MonthlyPayout;
            }
            Console.WriteLine($@"
                    Total Payroll Amount: ${total_payout} to be paid to {emp_list.Count} employees.
            ");
        }

        // Part (d)
        public static async Task updateMonthlyPayoutToMasterlist() {
            List<EmployeeClass.Employee> emp_list = SectionA.Program.readHRMasterList();
            Console.WriteLine("Process payroll...");
            await Task.Run(() => processPayroll(emp_list));
            StreamWriter sw = new StreamWriter("../HRMasterlistB.txt");
            foreach (var emp in emp_list) {
                sw.WriteLine($"{emp.Nric}|{emp.FullName}|{emp.Salutation}|{emp.StartDate.ToString("dd/MM/yyyy")}|{emp.Designation}|{emp.Department}|{emp.MobileNo}|{emp.HireType}|{emp.Salary}|{emp.MonthlyPayout}");
            }
            sw.Close();
            Console.WriteLine("Complete!");
        }
        static void Main() {
            updateMonthlyPayoutToMasterlist().Wait();
        }
    }
}
