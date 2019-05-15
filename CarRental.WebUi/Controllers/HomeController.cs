using CarRental.WebUi.Models.Home;
using CarRental.WebUi.Models.Json;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["token"] == null || string.IsNullOrWhiteSpace(Session["token"].ToString()))
            {
                ViewBag.Message = "Please Login";
                return View();
            }

            var client = new RestClient("http://localhost:19625/api/vehicle/GetVehicles");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "56d8fd0c-76b1-7617-bf47-b3357423e424");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "bearer " + Session["token"].ToString());
            IRestResponse response = client.Execute(request);

            var responseModel = JsonConvert.DeserializeObject<List<GetVehiclesResponse>>(response.Content);

            var indexViewModel = new IndexViewModel
            {
                Vehicles = responseModel
            };

            return View(indexViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}