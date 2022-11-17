using System;
using SampleLibrary.Data;
using SampleLibrary.Entities;
using SampleLibrary;

namespace SampleConsoleApp
{
    class UsingDataDllExample
    {
        static void Main(string[] args)
        {
            addRecordToDatabase();
        }

        private static void addRecordToDatabase()
        {
            IEmployeeDB db = EmployeeFactory.GetComponent();
            var name = Util.GetString("Enter the Name of the Employee to Add");
            var address = Util.GetString("Enter the Address of the Employee to Add");
            var salary = Util.GetDouble("Enter the salary of the new Employee");
            var emp = new Employee
            {
                EmpAddress = address,
                EmpName = name,
                EmpSalary = salary
            };
            try
            {
                db.AddNewEmployee(emp);
                Console.WriteLine("Employee added successfully to the database");
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}