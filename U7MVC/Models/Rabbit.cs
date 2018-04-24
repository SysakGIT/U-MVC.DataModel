using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U7MVC.Models
{
    public class OldRabbit
    {
        public int RabbitId { get; set; }
        public int RabbitBreedId { get; set; } // flandr, rex ect.
        public int MemberId { get; set; } //reference to mumber of a club
        public DateTime RabbitBirthDay { get; set; }
        public string RabbitGender { get; set; }
        public string RabbitColor { get; set; }  // we need change it to Enumerate
        public float Weight { get; set; }
        public float Ears { get; set; }
        public int PhotoAlbumId { get; set; }
        //ect
    }
}