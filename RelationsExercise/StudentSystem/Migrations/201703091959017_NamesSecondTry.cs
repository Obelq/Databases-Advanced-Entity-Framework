namespace StudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamesSecondTry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
            AddColumn("dbo.Students", "StudentName", c => c.String(nullable: false));
            AddColumn("dbo.Resources", "ResourceName", c => c.String(nullable: false));
            DropColumn("dbo.Courses", "Name");
            DropColumn("dbo.Students", "Name");
            DropColumn("dbo.Resources", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resources", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Resources", "ResourceName");
            DropColumn("dbo.Students", "StudentName");
            DropColumn("dbo.Courses", "CourseName");
        }
    }
}
