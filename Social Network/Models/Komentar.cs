using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Komentar
    {
        public int Id { get; set; }
        public int ObjavaId { get; set; }
        public string tekst { get; set; }
        public DateTime datum { get; set; }
    }
}