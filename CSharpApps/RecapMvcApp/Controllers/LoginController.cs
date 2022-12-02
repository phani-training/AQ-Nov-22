﻿using RecapMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RecapMvcApp.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SignIn()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SignIn(string username, string password)
        {
            var data = HttpContext.Application["userList"] as Dictionary<string, string>;
            var context = new TravelAppDemoEntities();
            var user = context.UserTables.FirstOrDefault(u => u.Username == username && u.Password == password);
            if(user !=null)
            {
                Session["currentUser"] = user; //To store it till the User logs off!!!
                FormsAuthentication.RedirectFromLoginPage(username, true);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorInfo = "Login has failed!";
                return PartialView();
            }
        }
        public ActionResult Register()
        {
            UserTable newUser = new UserTable();
            return PartialView(newUser);
        }

        [HttpPost]
        public ActionResult Register(UserTable user)
        {
            var context = new TravelAppDemoEntities();
            if (ValidateUserName(user.Username))
            {
                context.UserTables.Add(user);
                context.SaveChanges();
                //save the data to the ApplicationState without a need to get the user details again from the Database. 
                var data = HttpContext.Application["UserList"] as Dictionary<string, string>;
                data.Add(user.Username, user.Password);
                HttpContext.Application["userList"] = data;
                return RedirectToAction("Index");
            }
            ViewBag.ErrorInfo = "User Already Exists, Please use another name!!!";
            return PartialView(user);
        }

        //To check the Unique UserName..
        private bool ValidateUserName(string name)
        {
            var data = HttpContext.Application["userList"] as Dictionary<string, string>;
            return !data.ContainsKey(name);
        }
    }
}