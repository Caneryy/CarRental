using CarRental.Entity;
using CarRental.WebUi.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.WebUi.Models.Home
{
    public class IndexViewModel
    {
        public string CompanyName { get; set; }

        public List<GetVehiclesResponse> Vehicles { get; set; }
    }
}