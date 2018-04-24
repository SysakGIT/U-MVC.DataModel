using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U7MVC.Models
{
    public class OldUsers
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserTypeId { get; set; }
        public bool isActive { get; set; }
    }
}