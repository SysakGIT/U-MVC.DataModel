using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace U7MVC.Models
{
    [Table("District")]
    public class District
    {
        public int ID { get; set; }
        public string DistrictName { get; set; }
    }
}