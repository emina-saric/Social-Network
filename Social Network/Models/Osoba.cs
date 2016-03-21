using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Osoba
    {
        public int Id { get; set; }
        string ime;
        string prezime;
        DateTime datumRodjenja;
        string drzava;
        string grad;
        string spol;
        string telefon;
    }
}