using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SampleWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var data = Database.AllProducts;
            Application["AllData"] = data;
        }

        //Event handler for Session starting
        public void Session_Start(object sender, EventArgs e)
        {
            var cart = new List<Product>();
            Session["cart"] = cart;

            var recentList = new Queue<Product>();
            Session["recent"] = recentList;
        }
    }
}