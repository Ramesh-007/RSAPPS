using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessEntities;

namespace ViewModel
{
    public class UserViewModel
    {
        [Display(Name = "Name : ")]
        public string Name { get; set; }

        [Display(Name = "Password : ")]
        public string Password { get; set; }

        public int UState { get; set; }
        [Display(Name = "Week : ")]
        public string CurrentWeek { get; set; }
        public string CurrentDate { get; set; }
        public DailyStatus Status { get; set; }

        public List<EmployeeAttendance> Attendance { get; set;}
        public List<int> Weeks { get; set; }

        public Dictionary<int, string> WeekOfYear { get; set; }

    }
}
