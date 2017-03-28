namespace PhotoDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotographersAndAlbums : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BackgroundColor = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        Photographer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photographers", t => t.Photographer_Id)
                .Index(t => t.Photographer_Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Caption = c.String(),
                        Path = c.String(),
                        Album_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Album_Id)
                .Index(t => t.Album_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Photographer_Id", "dbo.Photographers");
            DropIndex("dbo.Pictures", new[] { "Album_Id" });
            DropIndex("dbo.Albums", new[] { "Photographer_Id" });
            DropTable("dbo.Pictures");
            DropTable("dbo.Albums");
        }
    }
}
