using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U7MVC.Models
{
    public class OldMember
    {
        public int MemberId { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public string MemberNumber { get; set; }
        public int RegionId { get; set; }
        public int DistrictId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string PostBox { get; set; }
        

    }
}