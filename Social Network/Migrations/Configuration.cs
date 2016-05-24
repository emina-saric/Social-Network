namespace Social_Network.Migrations
{
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Social_Network.Models.Social_NetworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Social_Network.Models.Social_NetworkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new Social_NetworkContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new Social_NetworkContext()));

            var superAdmin = new ApplicationUser()
            {
                UserName = "SuperAdminUser",
                Email = "superadminuser@gmail.com",
                EmailConfirmed = true,
                FirstName = "SuperAdmin",
                LastName = "User"
            };
            var admin = new ApplicationUser()
            {
                UserName = "AdminUser",
                Email = "adminuser@gmail.com",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User"
            };

            manager.Create(superAdmin, "SuperAdminUser123");
            manager.Create(admin, "AdminUser123");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var superAdminUser = manager.FindByName("SuperAdminUser");
            var adminUser = manager.FindByName("AdminUser");

            manager.AddToRoles(superAdminUser.Id, new string[] { "SuperAdmin", "Admin","User"});
            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });



            if (context.Clients.Count() > 0)
            {
                return;
            }

            Objava obj1 = new Objava();
            obj1.Id = 1;
            obj1.tekst = "probna objava broj jedan u bazi za provjeru. ";
            obj1.urlSlike = "nemaSlike";
            obj1.datumObjave = DateTime.Parse("2011-09-01");
            obj1.pozGlasovi = 5;
            obj1.negGlasovi = 2;
            obj1.oznake = "nema oznaka";
            obj1.ProfilId = "bf298fdf-f141-48d5-a215-4071ce19f7af";
            obj1.komentari = new List<Komentar>();

            Objava obj2 = new Objava();
            obj2.Id = 1;
            obj2.tekst = "probna objava broj dva u bazi za provjeru.probna objava broj dva u bazi za provjeru.  ";
            obj2.urlSlike = "nemaSlike";
            obj2.datumObjave = DateTime.Parse("2011-09-01");
            obj2.pozGlasovi = 5;
            obj2.negGlasovi = 2;
            obj2.oznake = "nema oznaka";
            obj2.ProfilId = "bf298fdf-f141-48d5-a215-4071ce19f7af";
            obj2.komentari = new List<Komentar>();

            Komentar k1 = new Komentar();
            k1.Id = 1;
            k1.tekst = "neki tekst za objavu 1";
            k1.datum = DateTime.Now;
            k1.ObjavaId = 1;
            k1.Objava = obj1;
            k1.napisao = "SuperAdminUser";

            Komentar k2 = new Komentar();
            k2.Id = 2;
            k2.tekst = "neki tekst za objavu 2,neki tekst za objavu 1";
            k2.datum = DateTime.Now;
            k2.ObjavaId = 1;
            k2.Objava = obj1;
            k2.napisao = "SuperAdminUser";


            Komentar k3 = new Komentar();
            k3.Id = 3;
            k3.tekst = "neki tekst za objavu 2,neki tekst za objavu 1";
            k3.datum = DateTime.Now;
            k3.ObjavaId = 1;
            k3.Objava = obj1;
            k3.napisao = "SuperAdminUser";

            obj1.komentari.Add(k1);
            obj1.komentari.Add(k2);
            obj1.komentari.Add(k3);

            context.Objava.AddOrUpdate(obj1);


            context.SaveChanges();

            //context.Objava.AddRange(BuildObjave());
            context.Clients.AddRange(BuildClientsList());
            context.SaveChanges();
        }

        private static List<Client> BuildClientsList()
        {

            List<Client> ClientsList = new List<Client>
            {
                new Client
                { Id = "ngAuthApp",
                    Secret= Helper.GetHash("abc@123"),
                    Name="AngularJS front-end Application",
                    ApplicationType =  Models.ApplicationTypes.JavaScript,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "http://localhost:51622"
                },
                new Client
                {   Id = "consoleApp",
                    Secret=Helper.GetHash("123@abc"),
                    Name="Console Application",
                    ApplicationType =Models.ApplicationTypes.NativeConfidential,
                    Active = true,
                    RefreshTokenLifeTime = 14400,
                    AllowedOrigin = "*"
                }
            };

            return ClientsList;
        }
        private static List<Objava> BuildObjave()
        {

            List<Objava> ObjaveList = new List<Objava>
            {
                new Objava{
                    Id=1,
                    tekst = "Hard coded objava u bazi za provjeru. ",
                    urlSlike = "nemaSlike",
                    datumObjave = DateTime.Parse("2011-09-01"),
                    pozGlasovi = 5,
                    negGlasovi = 2,
                    oznake ="nema oznaka",
                    ProfilId = "b5648d7f-86f1-4e71-b164-a8c0ab22cae8"
                }
            };

            return ObjaveList;
        }
    }
}
