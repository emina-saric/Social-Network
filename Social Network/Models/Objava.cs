using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Objava
    {
        public int Id { get; set; }
        public string tekst { get; set; }
        public string urlSlike { get; set; }
        public DateTime datumObjave { get; set; }
        public int pozGlasovi { get; set; }
        public int negGlasovi { get; set; }
        public string oznake { get; set; }
        public int ProfilId { get; set; }
    }
}