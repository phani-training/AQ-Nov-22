using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp.Entities
{
    class Employee
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
    }
}
