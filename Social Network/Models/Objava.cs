using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Objava
    {
        public int Id { get; set; }
        string tekst;
        string urlSlike;
        DateTime datumObjave;
        int pozGlasovi;
        int negGlasovi;
        string oznake;
        int ProfilId;
    }
}