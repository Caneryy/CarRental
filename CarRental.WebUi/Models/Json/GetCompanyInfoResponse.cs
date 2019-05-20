using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.WebUi.Models.Json
{
    public class GetCompanyInfoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int VehicleCount { get; set; }
        public float Rating { get; set; }
    }
}