using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U7MVC.Models
{
    public class CheckBoxListItem
    {
        public int ParentID { get; set; }
        public int ID { get; set; }
        public string Display { get; set; }
        public bool IsChecked { get; set; }
    }
}