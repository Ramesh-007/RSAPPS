using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessEntities
{
    public interface Leave
    {
        string StartDate { get; set; }
        string EndDate { get; set; }
        LeaveType Type { get; set; }
        string Reason { get; set; }
    }
}