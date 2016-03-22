using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Poruka
    {
        public int Id { get; set; }
        public int RazgovorId { get; set; }
        public string tekst { get; set; }
        public DateTime vrijeme { get; set; }
        public int napisao { get; set; }
    }
}