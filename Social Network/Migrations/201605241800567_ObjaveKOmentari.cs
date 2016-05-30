namespace Social_Network.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ObjaveKOmentari : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Komentar", "ObjavaId");
            AddForeignKey("dbo.Komentar", "ObjavaId", "dbo.Objava", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Komentar", "ObjavaId", "dbo.Objava");
            DropIndex("dbo.Komentar", new[] { "ObjavaId" });
        }
    }
}
