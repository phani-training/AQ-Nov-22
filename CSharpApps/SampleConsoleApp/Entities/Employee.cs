using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp.Entities
{
    class Employee : IComparable<Employee>
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public override int GetHashCode()//Gets a unique no identifying the object. 
        {
            return EmpId;
        }
        //Equals method defines the logical Equivalence of the object with the other
        public override bool Equals(object other)
        {
            var otherEmp = other as Employee;//UNBOXING...
            return EmpId == otherEmp.EmpId;
            
        }

        public override string ToString()
        {
            return string.Format("Name:{0}, Address: {1}, Salary:{2}", EmpName, EmpAddress, EmpSalary);
            //return $"Name:{EmpName}\tAddress:{EmpAddress}\tSalary:{EmpSalary}";
        }

        /// <summary>
        /// Copies the data of the emp into the current object
        /// </summary>
        /// <param name="emp">The Employee data to be copied.</param>
        public void Copy(Employee emp)
        {
            EmpAddress = emp.EmpAddress;
            EmpName = emp.EmpName;
            EmpSalary = emp.EmpSalary;
        }

        public int CompareTo(Employee other)
        {
            return EmpName.CompareTo(other.EmpName);
        }
    }

    enum ComparisonCriteria
    {
        Name, Address, Salary
    }
    class EmployeeComparer : IComparer<Employee>
    {
        private ComparisonCriteria criteria;
        public EmployeeComparer(ComparisonCriteria criteria)
        {
            this.criteria = criteria;
        }
        public int Compare(Employee first, Employee second)
        {
            switch (criteria)
            {
                case ComparisonCriteria.Name:
                    return first.CompareTo(second);
                case ComparisonCriteria.Address:
                    return first.EmpAddress.CompareTo(second.EmpAddress);
                case ComparisonCriteria.Salary:
                    if (first.EmpSalary > second.EmpSalary)
                        return 1;
                    else if (first.EmpSalary < second.EmpSalary)
                        return -1;
                    else
                        return 0;
            }
            return 0;
        }
    }
}
