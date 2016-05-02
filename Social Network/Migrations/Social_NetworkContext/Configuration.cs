namespace Social_Network.Migrations.Social_NetworkContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Social_Network.Models.Social_NetworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Social_NetworkContext";
        }

        protected override void Seed(Social_Network.Models.Social_NetworkContext context)
        {
            context.Clients.AddOrUpdate(
                new Entities.Client
                {
                    Active = true,
                    AllowedOrigin = "http://localhost:51622",
                    ApplicationType = 0,
                    Id = "ngAuthApp",
                    Name = "AngularJS Front-End Application",
                    RefreshTokenLifeTime = 7200,
                    Secret = Helper.GetHash("secret")
                }
            );
        }
    }
}
