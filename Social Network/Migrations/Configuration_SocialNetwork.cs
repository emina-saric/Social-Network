namespace Social_Network.Social_NetworkContextNamespace
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration_SocialNetwork : DbMigrationsConfiguration<Social_Network.Models.Social_NetworkContext>
    {
        public Configuration_SocialNetwork()
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
        }
    }
}
