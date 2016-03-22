using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Slika
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string url { get; set; }
        public string opis { get; set; }
        public DateTime datum { get; set; }
    }
}