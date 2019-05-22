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
                return RedirectToAction("Login", "Account");
            }

            var client = new RestClient("http://localhost:19625/api/vehicle/GetVehicles");
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "bearer " + Session["token"].ToString());
            IRestResponse response = client.Execute(request);

            var getVehiclesResponse = JsonConvert.DeserializeObject<List<GetVehiclesResponse>>(response.Content);

            client.BaseUrl = new Uri("http://localhost:19625/api/company/GetCompanyInfo");
            response = client.Execute(request);

            var getCompanyInfoResponse = JsonConvert.DeserializeObject<GetCompanyInfoResponse>(response.Content);

            var indexViewModel = new IndexViewModel
            {
                Vehicles = getVehiclesResponse,
                CompanyName = getCompanyInfoResponse.Name
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