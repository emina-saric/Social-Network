using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Notifikacija
    {
        public int Id { get; set; }
        public int ProfilId { get; set; }
        public string poruka { get; set; }
        public DateTime vrijeme { get; set; }
        public string urlObjave { get; set; }
    }
}