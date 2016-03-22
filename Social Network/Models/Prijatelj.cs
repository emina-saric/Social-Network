using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Prijatelj
    {
        public int Id { get; set; }
        public int ProfilId { get; set; }
        public DateTime prijateljiOd { get; set; }
    }
}