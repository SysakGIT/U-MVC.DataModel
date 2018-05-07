﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace U7MVC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RabbitClubEntitiesConnection : DbContext
    {
        public RabbitClubEntitiesConnection()
            : base("name=RabbitClubEntitiesConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AddressData> AddressData { get; set; }
        public virtual DbSet<Breeds> Breeds { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<MemberBreeds> MemberBreeds { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<MembersPhone> MembersPhone { get; set; }
        public virtual DbSet<PhoneTypes> PhoneTypes { get; set; }
        public virtual DbSet<RabbitBreed> RabbitBreed { get; set; }
        public virtual DbSet<RabbitColor> RabbitColor { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<RegionsDistrincts> RegionsDistrincts { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<RegionsDistrinctsCities> RegionsDistrinctsCities { get; set; }
        public virtual DbSet<v_RabbitBreedColorList> v_RabbitBreedColorList { get; set; }
        public virtual DbSet<v_Members> v_Members { get; set; }
        public virtual DbSet<News> News { get; set; }
    
        public virtual int UpdateRabbitColorrelation(Nullable<int> breedId, Nullable<int> colorId, Nullable<bool> value)
        {
            var breedIdParameter = breedId.HasValue ?
                new ObjectParameter("BreedId", breedId) :
                new ObjectParameter("BreedId", typeof(int));
    
            var colorIdParameter = colorId.HasValue ?
                new ObjectParameter("ColorId", colorId) :
                new ObjectParameter("ColorId", typeof(int));
    
            var valueParameter = value.HasValue ?
                new ObjectParameter("Value", value) :
                new ObjectParameter("Value", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateRabbitColorrelation", breedIdParameter, colorIdParameter, valueParameter);
        }
    }
}
