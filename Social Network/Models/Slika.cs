using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Slika
    {
        public int Id { get; set; }
        int AlbumId;
        string url;
        string opis;
        DateTime datum;
    }
}