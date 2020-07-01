using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLayer;
using BusinessEntities;
using ViewModel;
using System.Web.Security;

namespace LMSApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(UserViewModel u)
        {
            if (ModelState.IsValid)
            {
                LoginBusinessLayer bal = new LoginBusinessLayer();
                User uObj = new User();
                
                uObj.Name = u.Name;
                uObj.Password = u.Password;

                UserStatus status = bal.GetUserValidity(uObj);
                for (int i = 0; i < 52; ++i)
                {
                    if (u.Weeks == null)
                    {
                        u.Weeks = new List<int>();
                        u.Weeks.Add(i);
                    }
                    else
                    {
                        u.Weeks.Add(i);
                    }
                }

                u.WeekOfYear = new Dictionary<int, string>();
                for (int i = 0; i < 52; ++i)
                {
                    u.WeekOfYear.Add(i, i.ToString());
                }

                if (status != UserStatus.NonAutheticatedUser)
                {
                    u.UState = (int)status;
                    TempData["User"] = u;

                    //TempData["Attendance"] = ObjItem;
                    return RedirectToAction("Employee", "Employee");
                }

                return View("Login");
            }
            else
            {
                return View("Login");
            }
        }
    }
}