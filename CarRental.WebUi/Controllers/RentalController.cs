using CarRental.Entity;
using CarRental.WebUi.Models.Rental;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.WebUi.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult Index()
        {
            if (Session["token"] == null || string.IsNullOrWhiteSpace(Session["token"].ToString()))
            {
                ViewBag.Message = "Please Login";
                return View();
            }

            var client = new RestClient("http://localhost:19625/api/rental/GetEmployeeRentals");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "bearer " + Session["token"].ToString());
            IRestResponse response = client.Execute(request);

            var rentals = JsonConvert.DeserializeObject<List<Rental>>(response.Content);

            var rentalIndexViewModel = new RentalIndexViewModel
            {
                Rentals = rentals
            };

            return View(rentalIndexViewModel);
        }
    }
}