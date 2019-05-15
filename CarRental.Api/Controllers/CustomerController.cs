using CarRental.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRental.Api.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork(new CarRentalContext());

        [HttpPost]
        [Route("api/Customer/GetCustomers")]
        [ActionName("GetCustomers")]
        public IHttpActionResult GetCustomers()
        {
            var customers = unitOfWork.CustomerRepository.GetAll();

            return Ok(customers);
        }
    }
}
