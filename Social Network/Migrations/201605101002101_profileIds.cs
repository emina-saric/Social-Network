namespace Social_Network.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profileIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Komentar", "napisao", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Komentar", "tekst", c => c.String());
            AlterColumn("dbo.Notifikacija", "ProfilId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Objava", "ProfilId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Poruka", "napisao", c => c.String(maxLength: 128));
            AlterColumn("dbo.Prijatelj", "Osoba1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Prijatelj", "Osoba2", c => c.String(maxLength: 128));
            AlterColumn("dbo.Razgovor", "ucesnik1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Razgovor", "ucesnik2", c => c.String(maxLength: 128));
            AlterColumn("dbo.Album", "ProfilId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Razgovor", "ucesnik2", c => c.Int(nullable: false));
            AlterColumn("dbo.Razgovor", "ucesnik1", c => c.Int(nullable: false));
            AlterColumn("dbo.Prijatelj", "Osoba2", c => c.Int(nullable: false));
            AlterColumn("dbo.Prijatelj", "Osoba1", c => c.Int(nullable: false));
            AlterColumn("dbo.Poruka", "napisao", c => c.Int(nullable: false));
            AlterColumn("dbo.Objava", "ProfilId", c => c.Int(nullable: false));
            AlterColumn("dbo.Notifikacija", "ProfilId", c => c.Int(nullable: false));
            AlterColumn("dbo.Komentar", "tekst", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Komentar", "napisao");
            AlterColumn("dbo.Album", "ProfilId", c => c.Int(nullable: false));
        }
    }
}
