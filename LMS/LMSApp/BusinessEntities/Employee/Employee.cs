using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessEntities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public int Status { get; set; }
    }
}