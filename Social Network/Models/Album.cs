using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public bool Privatni { get; set; }
        public string AlbumCol { get; set; }
        public int ProfilId { get; set; }
    }
}