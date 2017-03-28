namespace PhotoDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagAlbums",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Album_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Album_Id);
            
            CreateTable(
                "dbo.TagPhotographers",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Photographer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Photographer_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Photographers", t => t.Photographer_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Photographer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPhotographers", "Photographer_Id", "dbo.Photographers");
            DropForeignKey("dbo.TagPhotographers", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagAlbums", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.TagAlbums", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagPhotographers", new[] { "Photographer_Id" });
            DropIndex("dbo.TagPhotographers", new[] { "Tag_Id" });
            DropIndex("dbo.TagAlbums", new[] { "Album_Id" });
            DropIndex("dbo.TagAlbums", new[] { "Tag_Id" });
            DropTable("dbo.TagPhotographers");
            DropTable("dbo.TagAlbums");
            DropTable("dbo.Tags");
        }
    }
}
