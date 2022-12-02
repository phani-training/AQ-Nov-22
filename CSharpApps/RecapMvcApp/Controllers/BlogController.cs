using RecapMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecapMvcApp.Controllers
{
    
    [Authorize]
    public class BlogController : Controller
    {
        /// <summary>
        /// Should return all the blogs of the Web Site..
        /// </summary> 
        [AllowAnonymous]
        public ActionResult AllBlogs()
        {
            var context = new TravelAppDemoEntities();
            var data = context.Blogs.ToList();
            return PartialView(data);
        }
        
        public ActionResult AllEditableBlogs()
        {
            if(Session["currentUser"] == null)
            {
                ViewBag.ErrorInfo = "Please login Before U Post a Blog!!!";
                return PartialView(null);
            }
            var user = Session["currentUser"] as UserTable;
            var context = new TravelAppDemoEntities();
            var blogs = context.Blogs.Where(b => b.UserId == user.UserId).ToList();
            return PartialView(blogs);
        }

        public ActionResult AddNew()
        {
            if (Session["currentUser"] == null)
            {
                TempData["ErrorInfo"] = "Please login Before U Post a Blog!!!";
                TempData.Keep();
                return RedirectToAction("Index", "Login");
            }
            var user = Session["currentUser"] as UserTable;
            var blog = new Blog();
            blog.UserId = user.UserId;
            blog.UserTable = user;
            return PartialView(blog);
        }

        [HttpPost]
        public ActionResult AddNew(Blog blog)
        {
            var context = new TravelAppDemoEntities();
            context.Blogs.Add(blog);
            context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}