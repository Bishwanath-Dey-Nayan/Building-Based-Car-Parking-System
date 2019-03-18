namespace CarParkingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordFieldAddedToRegisteredUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisteredUsers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisteredUsers", "Password");
        }
    }
}
