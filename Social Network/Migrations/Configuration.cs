namespace Social_Network.Migrations
{
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
            if (context.Clients.Count() > 0)
            {
                return;
            }
            context.Objavas.AddRange(BuildObjave());
            context.SaveChanges();
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
