using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
 * Caching is a feature to Optmize the Web App to store the output of a Page to the end user if U want to handle large no of requests at the same time. 
 * To improve the performance, we will cache the page. This makes the page saved in the server and will be rendered every time the user requests for the page. The duration of the cache could be set in minutes. 
 * OutputCache is the directive used to cache the Web page in the Application
 * Its VaryByParam attribute is used to cache different versions of the page based on the QueryString. 
 */
namespace SampleWebApp
{
    public partial class CachingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var time = "";
            if (!IsPostBack)
            {
                lblTime.Text = DateTime.Now.ToLongTimeString();
                switch (Request.QueryString["City"])
                {
                    case "New York":
                        time = DateTime.Now.AddHours(-10.5).ToLongTimeString();
                        break;
                    case "London":
                        time = DateTime.Now.AddHours(-5.5).ToLongTimeString();
                        break;
                    case "Moscow":
                        time = DateTime.Now.AddHours(-2.5).ToLongTimeString();
                        break;
                    case "New Delhi":
                        time = DateTime.Now.ToLongTimeString();
                        break;
                    case "Sidney":
                        time = DateTime.Now.AddHours(5.5).ToLongTimeString();
                        break;
                    default:
                        time = DateTime.Now.ToLongTimeString();
                        break;
                }
                lblTime.Text = time;
            }
        }
        //SelectedIndexChanged is the event triggered when the User selects an item in the listbox/dropdownlist box.
        //protected void dpList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string time = string.Empty;
        //    switch (dpList.SelectedValue)
        //    {
                //case "New York":
                //        time = DateTime.Now.AddHours(-10.5).ToLongTimeString();
                //        break;
                //    case "London":
                //        time = DateTime.Now.AddHours(-5.5).ToLongTimeString();
                //        break;
                //    case "Moscow":
                //        time = DateTime.Now.AddHours(-2.5).ToLongTimeString();
                //        break;
                //    case "New Delhi":
                //        time = DateTime.Now.ToLongTimeString();
                //        break;
                //    case "Sidney":
                //        time = DateTime.Now.AddHours(5.5).ToLongTimeString();
                //        break;
                //    default:
                //        time = DateTime.Now.ToLongTimeString();
                //        break;
        //    }
        //    lblTime.Text = time;
        //}

        protected void btnTime_Click(object sender, EventArgs e)
        {
            var city = dpList.SelectedValue;
            var url = $"CachingPage.aspx?City={city}";//Set the QueryString to the Url and Redirect it. 
            Response.Redirect(url);
        }
    }
}