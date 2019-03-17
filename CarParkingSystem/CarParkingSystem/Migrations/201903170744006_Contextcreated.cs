namespace CarParkingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contextcreated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegisteredUsers", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Bills", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CheckIns", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CheckOuts", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Users", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Bills", "CheckInId", "dbo.CheckIns");
            DropForeignKey("dbo.Bills", "CheckOutId", "dbo.CheckOuts");
            DropForeignKey("dbo.CheckOuts", "CheckInId", "dbo.CheckIns");
            AddForeignKey("dbo.RegisteredUsers", "CarId", "dbo.Cars", "Id");
            AddForeignKey("dbo.Bills", "CarId", "dbo.Cars", "Id");
            AddForeignKey("dbo.CheckIns", "CarId", "dbo.Cars", "Id");
            AddForeignKey("dbo.CheckOuts", "CarId", "dbo.Cars", "Id");
            AddForeignKey("dbo.Users", "CarId", "dbo.Cars", "Id");
            AddForeignKey("dbo.Bills", "CheckInId", "dbo.CheckIns", "Id");
            AddForeignKey("dbo.Bills", "CheckOutId", "dbo.CheckOuts", "Id");
            AddForeignKey("dbo.CheckOuts", "CheckInId", "dbo.CheckIns", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckOuts", "CheckInId", "dbo.CheckIns");
            DropForeignKey("dbo.Bills", "CheckOutId", "dbo.CheckOuts");
            DropForeignKey("dbo.Bills", "CheckInId", "dbo.CheckIns");
            DropForeignKey("dbo.Users", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CheckOuts", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CheckIns", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Bills", "CarId", "dbo.Cars");
            DropForeignKey("dbo.RegisteredUsers", "CarId", "dbo.Cars");
            AddForeignKey("dbo.CheckOuts", "CheckInId", "dbo.CheckIns", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bills", "CheckOutId", "dbo.CheckOuts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bills", "CheckInId", "dbo.CheckIns", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CheckOuts", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CheckIns", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bills", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RegisteredUsers", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
        }
    }
}
