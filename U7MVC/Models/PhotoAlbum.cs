using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U7MVC.Models
{
    public class PhotoAlbum
    {
        public int AlbumId { get; set; }
        public int PhootoId { get; set; }
        public int MemberId { get; set; }
        public string Path { get; set; }

    }
}