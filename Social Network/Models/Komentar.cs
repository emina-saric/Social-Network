using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Komentar
    {
        public int Id { get; set; }
        int ObjavaId;
        string tekst;
        DateTime datum;
    }
}