namespace Social_Network.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Datum = c.DateTime(nullable: false),
                        Privatni = c.Boolean(nullable: false),
                        AlbumCol = c.String(),
                        ProfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Komentars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ObjavaId = c.Int(nullable: false),
                        tekst = c.String(),
                        datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifikacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfilId = c.Int(nullable: false),
                        poruka = c.String(),
                        vrijeme = c.DateTime(nullable: false),
                        urlObjave = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Objavas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tekst = c.String(),
                        urlSlike = c.String(),
                        datumObjave = c.DateTime(nullable: false),
                        pozGlasovi = c.Int(nullable: false),
                        negGlasovi = c.Int(nullable: false),
                        oznake = c.String(),
                        ProfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Osobas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ime = c.String(),
                        prezime = c.String(),
                        datumRodjenja = c.DateTime(nullable: false),
                        drzava = c.String(),
                        grad = c.String(),
                        spol = c.String(),
                        telefon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Porukas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RazgovorId = c.Int(nullable: false),
                        tekst = c.String(),
                        vrijeme = c.DateTime(nullable: false),
                        napisao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prijateljs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfilId = c.Int(nullable: false),
                        prijateljiOd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OsobaId = c.Int(nullable: false),
                        username = c.String(),
                        password = c.String(),
                        email = c.String(),
                        slika = c.String(),
                        aktivan = c.Boolean(nullable: false),
                        registrovan = c.DateTime(nullable: false),
                        administrator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Razgovors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ucesnik1 = c.Int(nullable: false),
                        ucesnik2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slikas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        url = c.String(),
                        opis = c.String(),
                        datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Slikas");
            DropTable("dbo.Razgovors");
            DropTable("dbo.Profils");
            DropTable("dbo.Prijateljs");
            DropTable("dbo.Porukas");
            DropTable("dbo.Osobas");
            DropTable("dbo.Objavas");
            DropTable("dbo.Notifikacijas");
            DropTable("dbo.Komentars");
            DropTable("dbo.Albums");
        }
    }
}
