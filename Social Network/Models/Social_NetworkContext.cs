﻿using Social_Network.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Social_Network.Infrastructure;

namespace Social_Network.Models
{
    public class Social_NetworkContext: IdentityDbContext<ApplicationUser>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public Social_NetworkContext()
            : base("Social_NetworkContext")
        {

        }

        public static Social_NetworkContext Create()
        {
            return new Social_NetworkContext();
        }


        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public System.Data.Entity.DbSet<Social_Network.Models.Album> Albums { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Komentar> Komentars { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Notifikacija> Notifikacijas { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Objava> Objavas { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Poruka> Porukas { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Prijatelj> Prijateljs { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Razgovor> Razgovors { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Slika> Slikas { get; set; }
    }
}
