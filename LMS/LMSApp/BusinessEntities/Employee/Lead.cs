using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessEntities
{
    [NotMapped]
    public class Lead: Executive
    {
        List<int> Reports { get; set; }
    }
}