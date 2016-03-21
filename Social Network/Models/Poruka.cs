using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Poruka
    {
        public int Id { get; set; }
        int RazgovorId;
        string tekst;
        DateTime vrijeme;
        int napisao;
    }
}