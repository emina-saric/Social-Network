using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Models
{
    public class Profil
    {
        int id;
        int OsobaId;
        string username;
        string password;
        string email;
        string slika;
        bool aktivan;
        DateTime registrovan;
        bool administrator;
    }
}