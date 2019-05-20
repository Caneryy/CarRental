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
    public class CompanyController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork(new CarRentalContext());

        [HttpPost]
        [Route("api/company/GetCompanyInfo")]
        [ActionName("GetCompanyInfo")]
        public IHttpActionResult GetCompanyInfo()
        {
            var userId = User.Identity.GetUserId();
            var user = unitOfWork.EmployeeRepository.GetByUserId(userId);
            var companyInfo = unitOfWork.CompanyRepository.GetById(user.CompanyId);

            return Ok(companyInfo);
        }
    }
}
