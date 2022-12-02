using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecapMvcApp.Models;
/*
 * ViewBag and ViewData are the ways of sending additional info from the Action to the View. 
 * But the Data is scoped to the Action only, U cannot use them in other Action methods. 
 * However, for Short durations, we can use TempData Dictionary object. U must call Keep method to retain the values across the Action methods of the controller. 
 */
namespace RecapMvcApp.Controllers
{
    public class PropertyController : Controller
    {
        public ActionResult AllProperties()
        {
            //create the Context object.
            var context = new AQInsightsDBEntities();
            var data = context.PropertyTables.ToList();
            return View(data);
        }
        private void putDropDownValues()
        {
            var context = new AQInsightsDBEntities();
            //Add additional data that U want to pass to the View...
            List<SelectListItem> statusList = new List<SelectListItem>
                {
                    new SelectListItem{ Text = "Open"},
                    new SelectListItem{ Text = "Closed"}
                };

            ViewBag.StatusList = statusList;

            //List<SelectListItem> propertyTypes = context.PropertyTypeTables.Select((prop) => new SelectListItem { Text = prop.PropertyType, Value = prop.TypeId.ToString() }).ToList();
            //ViewBag.PropertyTypes = propertyTypes;

            var propTypes = context.PropertyTypeTables.ToList();//Get All the data from the DB
            List<SelectListItem> items = new List<SelectListItem>();//Create a black List
            foreach (var prop in propTypes)//iterate thro the data
            {
                items.Add(new SelectListItem { Text = prop.PropertyType, Value = prop.TypeId.ToString() });//Add each row into the items List
            }
            ViewBag.PropertyTypes = items;//SEt the items list to the ViewBag. 
        }
        public ActionResult OnView(string id)
        {
            try
            {
                putDropDownValues();
                if (string.IsNullOrEmpty(id))
                {
                    throw new Exception("ID of the Property not set to View");
                }
                var propId = int.Parse(id);
                var context = new AQInsightsDBEntities();
                var selectedProp = context.PropertyTables.FirstOrDefault((prop) => prop.PropertyId == propId);
                if (selectedProp == null)
                {
                    throw new Exception("The Property Details are not available with Us!!!");
                }
                return View(selectedProp);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult OnView(PropertyTable postedData)
        {
            try
            {
                putDropDownValues();
                var context = new AQInsightsDBEntities();
                var selectedRec = context.PropertyTables.FirstOrDefault(p => p.PropertyId == postedData.PropertyId);
                if (selectedRec == null) throw new Exception("Record not found to update!!");
                selectedRec.PropertyOwner = postedData.PropertyOwner;
                selectedRec.PropertyAddress = postedData.PropertyAddress;
                selectedRec.PropertyTypeId = postedData.PropertyTypeId;
                selectedRec.PropertyStatus = postedData.PropertyStatus;
                context.SaveChanges();
                TempData["Message"] = "Record updated to the System successfully";
                TempData.Keep("Message");
                return RedirectToAction("AllProperties");
            }catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}