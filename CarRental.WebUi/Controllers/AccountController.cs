using CarRental.WebUi.Models;
using CarRental.WebUi.Models.Json;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarRental.WebUi.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Session["token"] != null && !string.IsNullOrWhiteSpace(Session["token"].ToString()))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client = new RestClient("http://localhost:19625/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=password&username=" + model.Email + "&password=" + model.Password, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var responseModel = JsonConvert.DeserializeObject<LoginResponse>(response.Content);

            if (string.IsNullOrEmpty(responseModel.access_token))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            Session["token"] = responseModel.access_token;


            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            if (Session["token"] == null || string.IsNullOrWhiteSpace(Session["token"].ToString()))
            {
                ViewBag.Message = "Please Login";
                return RedirectToAction("Login", "Account");
            }

            Session["token"] = null;

            return RedirectToAction("Login", "Account");
        }


    }
}