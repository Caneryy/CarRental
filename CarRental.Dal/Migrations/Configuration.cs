namespace CarRental.Dal.Migrations
{
    using CarRental.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarRental.Dal.CarRentalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarRental.Dal.CarRentalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (context.Companies.Count() <1)
            {

                context.Companies.AddOrUpdate(new Company
                {
                    Name = "Avis",
                    City = "Ýzmir",
                    Address = "Ankara Cd. No:30 Konak",
                    Rating = 0,
                    VehicleCount = 0
                });

                context.Employees.AddOrUpdate(new Employee
                {
                    Name = "Caner",
                    Surname = "Çalýþan",
                    CompanyId = 1,
                    Role = 2
                });

                context.Vehicles.AddOrUpdate(new Vehicle
                {
                    CompanyId = 1,
                    AirBag = 2,
                    DailyKmLimit = 300,
                    DailyPrice = 110,
                    Fuel = "Benzin",
                    Km = 145560,
                    Make = "Volkswagen",
                    MinimumDrivingLicenceAge = 20,
                    Model = "1.4 TDi Comfortline ",
                    Serie = "Polo",
                    Year = 2004
                });
                context.SaveChanges();
            }

        }
    }
}
