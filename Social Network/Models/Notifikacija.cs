using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Notifikacija
    {
        public int Id { get; set; }
        int ProfilId;
        string poruka;
        DateTime vrijeme;
        string urlObjave;
    }
}