namespace CarParkingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CostFieldAddedToAccountTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Cost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Cost");
        }
    }
}
