namespace CarRental.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        VehicleCount = c.Int(nullable: false),
                        Rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        CompanyId = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        GivenKm = c.Int(nullable: false),
                        ReceiveKm = c.Int(nullable: false),
                        PaymentTaken = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.VehicleId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        Sex = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Serie = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        Fuel = c.String(),
                        Km = c.Int(nullable: false),
                        MinimumDrivingLicenceAge = c.Int(nullable: false),
                        DailyKmLimit = c.Int(nullable: false),
                        AirBag = c.Int(nullable: false),
                        DailyPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Rentals", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropIndex("dbo.Rentals", new[] { "VehicleId" });
            DropIndex("dbo.Rentals", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Customers");
            DropTable("dbo.Rentals");
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
        }
    }
}
