using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace U7MVC.Models
{
    public class OldRegionsDistrinct
    {
        [Key]
        [Column(Order = 1)]
        public int RegionId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
}