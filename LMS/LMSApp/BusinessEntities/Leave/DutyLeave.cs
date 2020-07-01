﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessEntities
{
    public class DutyLeave : OnDutyLeave
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public LeaveType Type { get; set; }
        public string Reason { get; set; }
    }
}