using CarRental.Entity;
using CarRental.WebUi.Models.Vehicle;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.WebUi.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index(int id)
        {
            if (Session["token"] == null || string.IsNullOrWhiteSpace(Session["token"].ToString()))
            {
                ViewBag.Message = "Please Login";
                return View();
            }

            var client = new RestClient("http://localhost:19625/api/vehicle/GetVehicle");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "bearer " + Session["token"].ToString());
            request.AddParameter("application/json", "{\n\"VehicleId\":" + id + "\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var vehicleModel = JsonConvert.DeserializeObject<Vehicle>(response.Content);

            var client1 = new RestClient("http://localhost:19625/api/customer/getcustomers");
            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("cache-control", "no-cache");
            request1.AddHeader("content-type", "application/json");
            request1.AddHeader("authorization", "bearer " + Session["token"].ToString());
            IRestResponse response1 = client1.Execute(request1);

            var customerListModel = JsonConvert.DeserializeObject<List<Customer>>(response1.Content);

            VehicleIndexViewModel vehicleIndexViewModel = new VehicleIndexViewModel
            {
                Vehicle = vehicleModel,
                Customers = customerListModel
            };

            return View(vehicleIndexViewModel);
        }
    }
}