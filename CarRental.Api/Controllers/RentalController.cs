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
using CarRental.Api.Ex;

namespace CarRental.Api.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RentalController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork(new CarRentalContext());

        [HttpPost]
        [Route("api/Rental/GetEmployeeRentals")]
        [ActionName("GetEmployeeRentals")]
        public IHttpActionResult GetEmployeeRentals()
        {
            var userId = User.Identity.GetUserId();
            var employee = unitOfWork.EmployeeRepository.GetByUserId(userId);
            var rentals = unitOfWork.RentalRepository.GetByEmployeeId(employee.Id);

            return Ok(rentals);
        }

        [HttpPost]
        [Route("api/Rental/GetCompanyRentals")]
        [ActionName("GetCompanyRentals")]
        public IHttpActionResult GetCompanyRentals()
        {
            var userId = User.Identity.GetUserId();
            var employee = unitOfWork.EmployeeRepository.GetByUserId(userId);
            var rentals = unitOfWork.RentalRepository.GetByCompanyId(employee.CompanyId);

            return Ok(rentals);
        }

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

        [HttpPost]
        [Route("api/rental/GetByVehicleId")]
        [ActionName("GetByVehicleId")]
        public IHttpActionResult GetByVehicleId(GetByVehicleIdRequest model)
        {
            var rentalList = unitOfWork.RentalRepository.GetByVehicleId(model.VehicleId);

            var dates = rentalList.Select(r => new[] { r.StartDate, r.EndDate }).SelectMany(i => i).ToHashSet();
           
            return Ok(new { rentalList, dates });
        }

        public class GetByVehicleIdRequest
        {
            public int VehicleId { get; set; }
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
