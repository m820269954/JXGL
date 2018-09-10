using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jxgl.Data_Access_Layer;
using jxgl.Models;
using jxgl.Filters;
namespace jxgl.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Login()
        {
            this.HttpContext.Session["UserGroup"] = "null";
            return View("Login");
        }
        public ActionResult ChangePwd()
        {
            return View("ChangePwd");
        }
        [Authorize]
        [AdminFilters]
        public ActionResult AdminIndex(string name)
        {
            ViewBag.username = name;
            return View("AdminIndex");
        }
        [Authorize]
        [StudentFilters]
        public ActionResult StudentIndex(string name)
        {
            ViewBag.username = name;
            return View("StudentIndex");
        }
        [Authorize]
        public ActionResult TeacherIndex(string name)
        {
            ViewBag.username = name;
            return View("TeacherIndex");
        }
    }
}