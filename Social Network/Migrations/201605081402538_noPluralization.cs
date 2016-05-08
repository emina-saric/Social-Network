namespace Social_Network.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noPluralization : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Albums", newName: "Album");
            RenameTable(name: "dbo.Clients", newName: "Client");
            RenameTable(name: "dbo.Komentars", newName: "Komentar");
            RenameTable(name: "dbo.Notifikacijas", newName: "Notifikacija");
            RenameTable(name: "dbo.Objavas", newName: "Objava");
            RenameTable(name: "dbo.Porukas", newName: "Poruka");
            RenameTable(name: "dbo.Prijateljs", newName: "Prijatelj");
            RenameTable(name: "dbo.Razgovors", newName: "Razgovor");
            RenameTable(name: "dbo.RefreshTokens", newName: "RefreshToken");
            RenameTable(name: "dbo.Slikas", newName: "Slika");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Slika", newName: "Slikas");
            RenameTable(name: "dbo.RefreshToken", newName: "RefreshTokens");
            RenameTable(name: "dbo.Razgovor", newName: "Razgovors");
            RenameTable(name: "dbo.Prijatelj", newName: "Prijateljs");
            RenameTable(name: "dbo.Poruka", newName: "Porukas");
            RenameTable(name: "dbo.Objava", newName: "Objavas");
            RenameTable(name: "dbo.Notifikacija", newName: "Notifikacijas");
            RenameTable(name: "dbo.Komentar", newName: "Komentars");
            RenameTable(name: "dbo.Client", newName: "Clients");
            RenameTable(name: "dbo.Album", newName: "Albums");
        }
    }
}
