using CarRental.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.WebUi.Models.Vehicle
{
    public class VehicleIndexViewModel
    {
        public CarRental.Entity.Vehicle Vehicle { get; set; }
        public List<Customer> Customers { get; set; }
    }
}