using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Entity;

namespace CarRental.WebUi.Models.Rental
{
    public class RentalIndexViewModel
    {
        public List<Entity.Rental> Rentals { get; set; }
    }
}