using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Network.Models
{
    public class Komentar
    {
        public int Id { get; set; }
        public string napisao { get; set; }
        public string tekst { get; set; }
        public DateTime datum { get; set; }
        public int ObjavaId { get; set; }
        public virtual Objava Objava { get; set; }
    }
}