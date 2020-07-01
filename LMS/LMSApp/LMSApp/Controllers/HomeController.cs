using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Leave Management System";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact.";
            return View();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Login", "Login");
        }        
    }
}