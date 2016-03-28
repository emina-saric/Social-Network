﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Objava
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        public string tekst { get; set; }
        public string urlSlike { get; set; }
        public DateTime datumObjave { get; set; }
        public int pozGlasovi { get; set; }
        public int negGlasovi { get; set; }
        public string oznake { get; set; }
        public int ProfilId { get; set; }
    }
}