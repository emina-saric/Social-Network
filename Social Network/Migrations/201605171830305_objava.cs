namespace Social_Network.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class objava : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objava", "userName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Objava", "userName");
        }
    }
}
