using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Prijatelj
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(128)]
        public string Osoba1 { get; set; }
        [MaxLength(128)]
        public string Osoba2 { get; set; }
        public DateTime prijateljiOd { get; set; }
    }
}