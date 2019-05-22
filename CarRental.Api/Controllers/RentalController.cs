using CarRental.Dal;
using CarRental.Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarRental.Api.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RentalController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork(new CarRentalContext());

        [HttpPost]
        [Route("api/Rental/AddRental")]
        [ActionName("AddRental")]
        public IHttpActionResult AddRental(AddRentalRequest model)
        {

            var userId = User.Identity.GetUserId();
            var user = unitOfWork.EmployeeRepository.GetByUserId(userId);


            Rental rental = new Rental
            {
                CustomerId = model.CustomerId,
                VehicleId = model.VehicleId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                EmployeeId = user.Id
            };

            unitOfWork.RentalRepository.Add(rental);
            unitOfWork.Complete();

            return Ok();
        }

        public class AddRentalRequest
        {
            public int VehicleId { get; set; }
            public int CustomerId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
    }
}
