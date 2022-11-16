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
                    empList.Remove(emp);
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
            throw new System.NotImplementedException();
        }
    }

    //User interface of the Application.....
    class EmployeeDemo
    {
        const string menuFile = @"C:\Trainings\AQ-Dotnet\CSharpApps\SampleConsoleApp\EmployeeManagement.txt";
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
                case "I":
                case "N":
                case "R":
                case "D":
                    return true;
                default:
                    return false;
            }
        }
    }
}