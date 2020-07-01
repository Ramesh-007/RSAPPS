using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

using BusinessEntities;
using BusinessLayer;


namespace LMSApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: DailyAttendance
        public ActionResult Employee()
        {
            UserViewModel user = (UserViewModel)TempData.Peek("User");

            if (user != null)
            {
                DateTime inputDate = DateTime.Today;

                user.CurrentDate = inputDate.Day.ToString() + " / " + inputDate.Month.ToString() + " / " 
                    + inputDate.Year.ToString();

                var d = inputDate;
                CultureInfo cul = CultureInfo.CurrentCulture;

                var firstDayWeek = cul.Calendar.GetWeekOfYear(
                    d,
                    CalendarWeekRule.FirstDay,
                    DayOfWeek.Monday);

                int weekNum = cul.Calendar.GetWeekOfYear(
                    d,
                    CalendarWeekRule.FirstDay,
                    DayOfWeek.Monday);

                string CurrentWeek = weekNum.ToString();
                user.CurrentWeek = CurrentWeek;

                
                EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();

                int Id = ebl.GetUserId(user.Name);

                List<EmployeeAttendance> attendances = ebl.GetEmployeeAttendance(Id, weekNum);
                user.Attendance = attendances;
                List<SelectListItem> ObjItem = new List<SelectListItem>();
                for (int i = 0; i < 52; ++i)
                {
                    if (i == Convert.ToUInt16(user.CurrentWeek))
                    {
                        SelectListItem item = new SelectListItem()
                        {
                            Text = i.ToString(),
                            Value = i.ToString(),
                            Selected = true
                        };
                        ObjItem.Add(item);
                    }
                    else
                    {
                        SelectListItem item = new SelectListItem()
                        {
                            Text = i.ToString(),
                            Value = i.ToString()
                        };
                        ObjItem.Add(item);
                    }
                }

                ViewBag.ListItem = new SelectList(ObjItem, "Text", "Value");
            }

            return View("Employee", user);
        }

        [HttpPost]
        public ActionResult SaveAttendance(UserViewModel userVM, string BtnSubmit)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = (UserViewModel)TempData.Peek("User");
                if (user != null)
                {
                    EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                    user.Status = userVM.Status;
                    EmployeeAttendance empAtt = new EmployeeAttendance();
                    empAtt.EmployeeId = empBal.GetUserId(user.Name);
                    if (user.Status == DailyStatus.Absent)
                        empAtt.Status = 0;
                    else
                        empAtt.Status = 1;
                    empAtt.Date = user.CurrentDate;
                    empBal.SaveEmployeeAttendance(empAtt);
                    return View("Employee", user);
                }
                return new EmptyResult();
            }
            return new EmptyResult();
        }

        public PartialViewResult GetAttendance(string SelectedIndex)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = (UserViewModel)TempData.Peek("User");
                if (user != null)
                {
                    EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                    int id = empBal.GetUserId(user.Name);
                    int selWeek = user.Weeks[Convert.ToInt32(SelectedIndex)];
                    user.Attendance = empBal.GetEmployeeAttendance(id, selWeek);
                    return PartialView("_EmpAttPartial", user);
                }
            }
            return new PartialViewResult();
        }
    }
}