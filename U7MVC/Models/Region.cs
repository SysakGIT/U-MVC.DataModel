using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace U7MVC.Models
{
    [Table("Region")]
    public class OldRegion
    {
        public int ID { get; set; }
        public string RegionName { get; set; }
    }
}