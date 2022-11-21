using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SampleLibrary.Data;
namespace SampleWebApp
{
    public partial class RecipiantPage : System.Web.UI.Page
    {
        //Page Load event is an important event of the Page life cycle that is triggered when the page is loaded into the memory of the Application process. 
        protected void Page_Load(object sender, EventArgs e)
        {
            //var content = $"The Name: {Request.QueryString["name"]}<br/>The Email Address: {Request.QueryString["email"]}";
            //lblContent.Text = content;
            queryStringDisplay();
            cookiesDisplay();
        }

        private void cookiesDisplay()
        {
            //Check for Cookies
            if(Request.Cookies["EmpInfo"] != null)
            {
                var cookie = Request.Cookies["EmpInfo"] as HttpCookie;
                var content = $"The Name part of the Data is {cookie.Values["name"]} from {cookie.Values["email"]}";
                lblCookies.Text = content;
            }
            else
            {
                lblCookies.Text = "No Cookie Info is stored with the Client machine";
            }
        }

        private void queryStringDisplay()
        {
            if (Request.QueryString["EmpId"] != null)
            {
                var id = int.Parse(Request.QueryString["EmpId"]);
                var component = EmployeeFactory.GetComponent();
                var foundRec = component.FindEmployee(id);
                var content = $"The Name of the Employee is {foundRec.EmpName} from {foundRec.EmpAddress} with a Salary of {foundRec.EmpSalary:C}";
                lblContent.Text = content;
            }
            else
                lblContent.Text = "U should visit the QueryString Page to select the View the details";
        }
    }
}