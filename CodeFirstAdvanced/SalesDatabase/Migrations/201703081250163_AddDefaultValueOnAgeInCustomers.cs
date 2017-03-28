namespace SalesDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultValueOnAgeInCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("Customers", "Age", a => a.Int(defaultValue: 20, nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Customers", "Age");
        }
    }
}
