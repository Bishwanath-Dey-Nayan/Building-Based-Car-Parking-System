namespace CarParkingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RUId = c.Int(nullable: false),
                        DepositeTime = c.DateTime(nullable: false),
                        DepositedAmount = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        RegisteredUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegisteredUsers", t => t.RegisteredUser_Id)
                .Index(t => t.RegisteredUser_Id);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCode = c.String(),
                        Name = c.String(),
                        Contact = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        CarId = c.Int(nullable: false),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: false)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarNo = c.String(),
                        CarName = c.String(),
                        LicenseNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckInId = c.Int(nullable: false),
                        CheckOutId = c.Int(nullable: false),
                        UserCode = c.String(),
                        CarId = c.Int(nullable: false),
                        SpaceId = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        TotalHour = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        ParkingSpace_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: false)
                .ForeignKey("dbo.CheckIns", t => t.CheckInId, cascadeDelete: false)
                .ForeignKey("dbo.CheckOuts", t => t.CheckOutId, cascadeDelete: false)
                .ForeignKey("dbo.ParkingSpaces", t => t.ParkingSpace_Id)
                .Index(t => t.CheckInId)
                .Index(t => t.CheckOutId)
                .Index(t => t.CarId)
                .Index(t => t.ParkingSpace_Id);
            
            CreateTable(
                "dbo.CheckIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckInTime = c.DateTime(nullable: false),
                        PSpaceId = c.Int(nullable: false),
                        TokenNo = c.String(),
                        UserCode = c.String(),
                        CarId = c.Int(nullable: false),
                        ParkingSpace_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete:false)
                .ForeignKey("dbo.ParkingSpaces", t => t.ParkingSpace_Id)
                .Index(t => t.CarId)
                .Index(t => t.ParkingSpace_Id);
            
            CreateTable(
                "dbo.CheckOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckInId = c.Int(nullable: false),
                        CheckOutTime = c.DateTime(nullable: false),
                        UserCode = c.String(),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.CheckIns", t => t.CheckInId, cascadeDelete: false)
                .Index(t => t.CheckInId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.ParkingSpaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PSName = c.String(),
                        Floor = c.String(),
                        Cost = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UCode = c.String(),
                        Name = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: false)
                .Index(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CarId", "dbo.Cars");
            DropForeignKey("dbo.RegisteredUsers", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CheckIns", "ParkingSpace_Id", "dbo.ParkingSpaces");
            DropForeignKey("dbo.Bills", "ParkingSpace_Id", "dbo.ParkingSpaces");
            DropForeignKey("dbo.CheckOuts", "CheckInId", "dbo.CheckIns");
            DropForeignKey("dbo.CheckOuts", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Bills", "CheckOutId", "dbo.CheckOuts");
            DropForeignKey("dbo.CheckIns", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Bills", "CheckInId", "dbo.CheckIns");
            DropForeignKey("dbo.Bills", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Accounts", "RegisteredUser_Id", "dbo.RegisteredUsers");
            DropIndex("dbo.Users", new[] { "CarId" });
            DropIndex("dbo.CheckOuts", new[] { "CarId" });
            DropIndex("dbo.CheckOuts", new[] { "CheckInId" });
            DropIndex("dbo.CheckIns", new[] { "ParkingSpace_Id" });
            DropIndex("dbo.CheckIns", new[] { "CarId" });
            DropIndex("dbo.Bills", new[] { "ParkingSpace_Id" });
            DropIndex("dbo.Bills", new[] { "CarId" });
            DropIndex("dbo.Bills", new[] { "CheckOutId" });
            DropIndex("dbo.Bills", new[] { "CheckInId" });
            DropIndex("dbo.RegisteredUsers", new[] { "CarId" });
            DropIndex("dbo.Accounts", new[] { "RegisteredUser_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.ParkingSpaces");
            DropTable("dbo.CheckOuts");
            DropTable("dbo.CheckIns");
            DropTable("dbo.Bills");
            DropTable("dbo.Cars");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.Accounts");
        }
    }
}
