using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entity
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Serie { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Fuel { get; set; }
        public int Km { get; set; }
        public int MinimumDrivingLicenceAge { get; set; }
        public int DailyKmLimit { get; set; }
        public int AirBag { get; set; }
        public float DailyPrice { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}
