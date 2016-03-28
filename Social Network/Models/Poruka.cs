using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Poruka
    {
        public int Id { get; set; }
        public int RazgovorId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string tekst { get; set; }
        public DateTime vrijeme { get; set; }
        public int napisao { get; set; }
    }
}