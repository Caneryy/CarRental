using CarRental.Dal;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRental.Api.Controllers
{
    [Authorize]
    public class VehicleController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork(new CarRentalContext());

        [HttpPost]
        [Route("api/Vehicle/GetVehicles")]
        [ActionName("GetVehicles")]
        public IHttpActionResult GetVehicles()
        {
            var userId = User.Identity.GetUserId();
            var user = unitOfWork.EmployeeRepository.GetByUserId(userId);
            var vehicles = unitOfWork.VehicleRepository.GetByCompanyId(user.CompanyId);

            return Ok(vehicles);
        }

        [HttpPost]
        [Route("api/Vehicle/GetVehicle")]
        [ActionName("GetVehicle")]
        public IHttpActionResult GetVehicle(GetVehicleRequest model)
        {
            var vehicle = unitOfWork.VehicleRepository.GetById(model.VehicleId);

            return Ok(vehicle);
        }

        public class GetVehicleRequest
        {
            public int VehicleId { get; set; }
        }

    }
}
