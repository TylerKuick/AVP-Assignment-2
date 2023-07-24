# Section C
# Calculate total cost reduced by the company from the retrenchment and print out the calculated amount in the console

from functools import *
from datetime import *

# Employee Class to store employee information
class Employee: 
    def __init__(self, nric, name, salutation, start_date, designation, department, mobile, hiretype, salary, monthly_payout):
        self.NRIC = nric
        self.Name = name
        self.Salutation = salutation
        self.StartDate = start_date
        self.Designation = designation
        self.Department = department
        self.Mobile = mobile
        self.HireType = hiretype
        self.Salary = salary
        self.MonthlyPayout = monthly_payout

# Read from HRMasterlistB.txt 
def read_HRMaster(fileA):
    hr_list = []
    with open(fileA, 'r') as hr:
        for line in hr:
            employee_attr = line.strip().split("|")
            employee = Employee(
                employee_attr[0],
                employee_attr[1],
                employee_attr[2],
                datetime.strptime(employee_attr[3], "%d/%m/%Y").date(),
                employee_attr[4],
                employee_attr[5],
                employee_attr[6],
                employee_attr[7],
                int(employee_attr[8]),
                int(employee_attr[9])
            )
            hr_list.append(employee)
    hr.close()
    return hr_list

# Filter HR List and calculate 
def calculateCostReduced():
    hr_list = read_HRMaster("HRMasterlistB.txt")    # Read and store employee records into a list
    total_saved = reduce(lambda x,y: x + y,                                                          # Sum all of the salaries found to get total cost reduced
                        map(lambda x: x.Salary - x.MonthlyPayout,                                    # Extract only the Salaries of those found from the two filters 
                             filter(lambda x: x.HireType == "PartTime",                              # Second filter to find part-time employees 
                                    filter(lambda x: 1995 < x.StartDate.year < 1999, hr_list))))     # First filter to find employees hired within 1995 to 1999
    
    total_payout = reduce(lambda x,y: x + y, 
                          map(lambda x: x.MonthlyPayout, 
                              filter(lambda x: x.HireType == "PartTime",
                                     filter(lambda x: 1995 < x.StartDate.year < 1999, hr_list))))
    
    print(f"Total costs saved from retrenching part-time employees who joined between the year 1995 and 1999 was ${total_saved}.")
    print(f"Total amount of salaries paid to retrenched employees was ${total_payout}.")


# Main Program
calculateCostReduced()
