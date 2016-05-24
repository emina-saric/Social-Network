namespace Social_Network.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class komentar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Komentar", "napisao", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Komentar", "napisao", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
