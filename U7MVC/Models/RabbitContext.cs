using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace U7MVC.Models
{
    public class RabbitContext : DbContext
    {
        public DbSet<Rabbit> Rabbits { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Users> LoginUsers { get; set; }

        public DbSet<Region> RegionList { get; set; }

        public DbSet<District> DistrictList { get; set; }

        public DbSet<RegionsDistrinct> RegionsDistrinctList { get; set; }
    }
  /*  public class RabbitDBInitializer : DropCreateDatabaseAlways<RabbitContext>
    {
        protected override void Seed(RabbitContext db)
        {
            db.Members.Add(new Member { MemberId = 1, MemberName = "Поляк Юрій", MemberNumber = "01" });

            base.Seed(db);
        }

        //initialize DB. insert records whicm must be always
    }*/
}
