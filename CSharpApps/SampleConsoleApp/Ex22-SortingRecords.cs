using System;
using SampleConsoleApp.Entities;
using System.Collections.Generic;
/*
 * Sorting can happen when U compare 2 objects on a criteria. 
 * In .NET, sorting of 2 objects is possible if any one object's class implements IComparable. 
 * If U want to compare 2 objects on multiple conditions, then U should create a new Implementor class that implements IComparer<T> 
 */
namespace SampleConsoleApp
{
    class SortingExample
    {
        static void Main(string[] args)
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                employees.Add(new Employee { EmpName = "Robert", EmpAddress = "New York", EmpSalary = 45000 });
                employees.Add(new Employee { EmpName = "Andrew", EmpAddress = "New Jersy", EmpSalary =15000 });
                employees.Add(new Employee { EmpName = "Allan", EmpAddress = "London" , EmpSalary = 100000});
                employees.Add(new Employee { EmpName = "Tim", EmpAddress = "Rome", EmpSalary = 67890 });
                employees.Add(new Employee { EmpName = "Bill", EmpAddress = "Paris" , EmpSalary = 78300});


                Console.WriteLine("Enter the Sorting criteria as :");
                Array values = Enum.GetValues(typeof(ComparisonCriteria));
                foreach (var value in values) Console.WriteLine(value);
                ComparisonCriteria criteria = (ComparisonCriteria)Enum.Parse(typeof(ComparisonCriteria), Console.ReadLine());
                employees.Sort(new EmployeeComparer(criteria));
                
                foreach (var emp in employees)
                    Console.WriteLine(emp);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Sorting Error");
                Console.WriteLine(ex.Message);
            }
        }
    }
}