//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Breeds
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Breeds()
        {
            this.MemberBreeds = new HashSet<MemberBreeds>();
        }
    
        public int ID { get; set; }
        public int RabbitBreedId { get; set; }
        public int RabbitColorId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberBreeds> MemberBreeds { get; set; }
        public virtual RabbitBreed RabbitBreed { get; set; }
        public virtual RabbitColor RabbitColor { get; set; }
    }
}