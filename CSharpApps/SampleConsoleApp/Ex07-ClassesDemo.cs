using System;

//Class is a User defined Data type. It is a composite type. Its composed of multiple data types to represent a single unit. Class is purely a prototype. U should create the instance of it(Variable of it) to use it. 

namespace SampleConsoleApp
{

    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double EmpSalary { get; set; }

        public DateTime EmpDateOfBirth { get; set; }
        public int Age
        {
            get
            {
                TimeSpan timeSpan = DateTime.Now - EmpDateOfBirth;
                return (int)(timeSpan.TotalDays / 365.25);
            }
        }
    }
    internal class Ex07_ClassesDemo
    {
        static Employee createEmployee()
        {
            int empId = int.Parse(Util.GetString("Enter the Id"));
            string name = Util.GetString("Enter the Name");
            double salary = double.Parse(Util.GetString("Enter the Salary"));

            DateTime dateOfBirth = Util.GetDate();
            Employee employee = new Employee
            {
                EmpId = empId,
                EmpName = name,
                EmpSalary = salary,
                EmpDateOfBirth = dateOfBirth
            };//Object Initialization syntax of C# 4.0
            return employee;
        }
        static void Main(string[] args)
        {
            Employee emp = createEmployee();
            Console.WriteLine("The Age is " + emp.Age);
        }
    }
}
