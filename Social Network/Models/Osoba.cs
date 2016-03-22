using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Osoba
    {
        public int Id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string drzava { get; set; }
        public string grad { get; set; }
        public string spol { get; set; }
        public string telefon { get; set; }
    }
}