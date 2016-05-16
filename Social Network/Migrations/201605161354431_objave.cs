namespace Social_Network.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class objave : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Objava", "tekst", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Objava", "tekst", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
