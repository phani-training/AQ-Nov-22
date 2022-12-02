using RecapMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RecapMvcApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Application["userList"] = getAllUsers();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private Dictionary<string, string> getAllUsers()
        {
            Dictionary<string, string> userList = new Dictionary<string, string>();
            var context = new TravelAppDemoEntities();
            var users = context.UserTables.ToList();
            var keyPair = new Dictionary<string, string>();
            foreach(var user in users)
            {
                //var pair = new KeyValuePair<string, string>(user.Username, user.Password);
                userList[user.Username] = user.Password;
            }
            return userList;
        }
    }
}
