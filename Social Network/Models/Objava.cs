using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Objava
    {
        int id;
        string tekst;
        string urlSlike;
        DateTime datumObjave;
        int pozGlasovi;
        int negGlasovi;
        string oznake;
        int profilId;
    }
}