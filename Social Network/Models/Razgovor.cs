using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Razgovor
    {
        public int Id { get; set; }
        public int ucesnik1 { get; set; }
        public int ucesnik2 { get; set; }
    }
}