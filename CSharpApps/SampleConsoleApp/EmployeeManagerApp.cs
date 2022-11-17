using SampleConsoleApp.Entities;
using System.Collections.Generic;
using System.IO;
namespace SampleConsoleApp.Demo
{

    interface IEmployeeComponent
    {
        void AddNewEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
        List<Employee> Find(string name);
        Employee Find(int id);
    }

    class EmployeeManager : IEmployeeComponent
    {
        private List<Employee> empList = new List<Employee>();
        public void AddNewEmployee(Employee emp)
        {
            empList.Add(emp);//We are not checking the Uniqueness
        }

        public void DeleteEmployee(int id)
        {
            foreach (var emp in empList)
            {
                if (emp.EmpId == id)
                {
                    empList.Remove(emp);
                    return;
                }
            }
            throw new System.Exception("Employee not found to delete");

        }

        public List<Employee> Find(string name)
        {
            return empList.FindAll((emp) => emp.EmpName.Contains(name));
        }

        public Employee Find(int id)
        {
            return empList.Find((emp) => emp.EmpId == id);
        }

        public void UpdateEmployee(Employee emp)
        {
            var rec = empList.Find((e) => e.EmpId == emp.EmpId);
            if (rec == null) throw new System.Exception("Employee not found to update");
            rec.Copy(emp);
        }
    }

    //User interface of the Application.....
    class EmployeeDemo
    {
        const string menuFile = @"C:\Trainings\AQ-Dotnet\CSharpApps\SampleConsoleApp\EmployeeManagement.txt";
        static EmployeeManager mgr = new EmployeeManager();
        static void Main(string[] args)
        {
            string menu = File.ReadAllText(menuFile);
            bool processing = false;
            do
            {
                var answer = Util.GetString(menu);
                processing = processMenu(answer);
            } while (processing);
        }

        private static bool processMenu(string answer)
        {
            switch (answer.ToUpper())
            {
                case "A":
                    addingHelper();
                    return true;
                case "I":
                case "N":
                    displayByName();
                    return true;
                case "R":
                case "D":
                    return true;
                default:
                    return false;
            }
        }

        private static void displayByName()
        {
            //Take input on the name of the Employee
            string name = Util.GetString("Enter the Name or part of the name to find");
            //Call the API
            var records = mgr.Find(name);
            //Display using foreach..
            foreach(var rec in records)
                System.Console.WriteLine(rec);
        }

        private static void addingHelper()
        {
            //take inputs from the user.
            int id = int.Parse(Util.GetString("Enter the ID of the Employee"));
            string name = Util.GetString("Enter the Name");
            string address = Util.GetString("Enter the Address");
            double salary = double.Parse(Util.GetString("Enter the Salary"));
            //create the Employee object
            var emp = new Employee
            {
                EmpId = id,
                EmpAddress = address,
                EmpName = name,
                EmpSalary = salary
            };
            //add the employee object to the addEmployee Function
            mgr.AddNewEmployee(emp);
        }
    }
}