namespace CarParkingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkinmodelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckIns", "status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckIns", "status");
        }
    }
}
