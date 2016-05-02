namespace Social_Network.AuthContextNamespace
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration_AuthContext : DbMigrationsConfiguration<Social_Network.AuthContext>
    {
        public Configuration_AuthContext()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Social_Network.AuthContext context)
        {
            context.Clients.AddOrUpdate(
                new Entities.Client {
                    Active = true,
                    AllowedOrigin = "http://localhost:51622",
                    ApplicationType = 0,
                    Id = "ngAuthApp",
                    Name = "AngularJS Front-End Application",
                    RefreshTokenLifeTime = 7200,
                    Secret = Helper.GetHash("secret")
                    }
                );
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
        }
    }
}
