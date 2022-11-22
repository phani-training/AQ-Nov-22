using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class CrudController : Controller
    {
        //Display all Records:
        public ViewResult AllRecords()
        {
            var context = new AQInsightsDBEntities();
            var records = context.EmpTables.ToList();//SELECT * FROM EMPTABLE....
            return View(records);
        }

        //Select one record and Display for Edit...
        public ViewResult ViewRec(string id)
        {
            var context = new AQInsightsDBEntities();
            var empId = int.Parse(id);
            var model = context.EmpTables.Where((emp) => emp.Id == empId).FirstOrDefault();//SELECT * From EmpTable where Id = empId;
            return View(model);
        }

        //Updating the Posted modified record...
        public ActionResult UpdateRec(EmpTable postedData)
        {
            //create the context object.
            var context = new AQInsightsDBEntities();
            //Find the matching record
            var model = context.EmpTables.FirstOrDefault((e) => e.Id == postedData.Id);
            if (model == null) throw new Exception("This is not found to update");
            //Set the new values to the old record
            model.EmpName = postedData.EmpName;
            model.EmpSalary = postedData.EmpSalary;
            model.EmpAddress = postedData.EmpAddress;
            //Save the changes
            context.SaveChanges();
            //Return to the view.
            return RedirectToAction("AllRecords");//Redirecting to the method called AllRecord
        }

        public ActionResult AddNew()
        {
            var newRec = new EmpTable();//Create a Blank object
            return View(newRec);//Inject it as model to the View...
        }

        [HttpPost]
        public ActionResult AddNew(EmpTable postedData)
        {
            //Create the Context object..
            var context = new AQInsightsDBEntities();
            //Add the new record to the EmpTables Collecion
            context.EmpTables.Add(postedData);
            //Save the changes
            context.SaveChanges();
            //Redirect to the AllRecords..
            return RedirectToAction("AllRecords");
        }

        public ActionResult Delete(string id)
        {
            var context = new AQInsightsDBEntities();
            var empId = int.Parse(id);
            var model = context.EmpTables.Where((emp) => emp.Id == empId).FirstOrDefault();//SELECT * From EmpTable where Id = empId;
            context.EmpTables.Remove(model);
            context.SaveChanges();
            return RedirectToAction("AllRecords");
        }
    }
}