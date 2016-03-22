using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Profil
    {
        public int Id { get; set; }
        public int OsobaId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string slika { get; set; }
        public bool aktivan { get; set; }
        public DateTime registrovan { get; set; }
        public bool administrator { get; set; }
    }
}