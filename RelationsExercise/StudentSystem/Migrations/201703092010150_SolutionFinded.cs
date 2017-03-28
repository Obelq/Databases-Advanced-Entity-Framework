namespace StudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolutionFinded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Homework", "HomeWorkContent", c => c.String(nullable: false));
            DropColumn("dbo.Homework", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Homework", "Content", c => c.String(nullable: false));
            DropColumn("dbo.Homework", "HomeWorkContent");
        }
    }
}
