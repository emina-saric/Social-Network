using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Profil
    {
        public int Id { get; set; }
        public int OsobaId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string username { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string slika { get; set; }
        public bool aktivan { get; set; }
        public DateTime registrovan { get; set; }
        public bool administrator { get; set; }
    }
}