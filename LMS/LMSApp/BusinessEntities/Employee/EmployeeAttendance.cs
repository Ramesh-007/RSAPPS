using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class EmployeeAttendance
    {
        [Key]
        public int Index { get; set; }
        public string Date { get; set; }
        public int Status { get; set; }
        public int EmployeeId { get; set; }
        public int Week { get; set; }

    }
}
