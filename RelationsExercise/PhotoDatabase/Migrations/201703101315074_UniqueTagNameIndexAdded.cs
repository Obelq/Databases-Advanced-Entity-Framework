namespace PhotoDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueTagNameIndexAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 500));
            CreateIndex("dbo.Tags", "Name", unique: true, name: "Name");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tags", "Name");
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false));
        }
    }
}
