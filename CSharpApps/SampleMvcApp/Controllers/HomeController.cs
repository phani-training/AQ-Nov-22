using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            var model = "Hello World from MVC";
            return model;
        }

        public string AnotherIndex() => "Testing another Action";

        public Employee GetEmployee() => new Employee
        {
            EmpID = 123, EmpName = "Phaniraj", EmpAddress ="Bangalore", EmpSalary = 67000
        };
        public ViewResult CurrentEmployee()
        {
            var model = new Employee
            {
                EmpAddress = "Bangalore",
                EmpID = 111,
                EmpName = "TestName",
                EmpSalary = 67000
            };
            return View(model);
        }
    }
}