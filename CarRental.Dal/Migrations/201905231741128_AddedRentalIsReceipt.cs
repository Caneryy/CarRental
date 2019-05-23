namespace CarRental.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRentalIsReceipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "IsReceipt", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rentals", "PassedKm", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "PassedKm");
            DropColumn("dbo.Rentals", "IsReceipt");
        }
    }
}
