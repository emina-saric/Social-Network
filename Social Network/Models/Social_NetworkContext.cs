using Microsoft.AspNet.Identity.EntityFramework;
using Social_Network.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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
            : base("Social_NetworkContext", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;            
        }

        public static Social_NetworkContext Create()
        {
            return new Social_NetworkContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public System.Data.Entity.DbSet<Social_Network.Models.Album> Album { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Komentar> Komentar { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Notifikacija> Notifikacija { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Objava> Objava { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Poruka> Poruka { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Prijatelj> Prijatelj { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Razgovor> Razgovor { get; set; }
        public System.Data.Entity.DbSet<Social_Network.Models.Slika> Slika { get; set; }
    }
}
