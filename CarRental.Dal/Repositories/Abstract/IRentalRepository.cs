using CarRental.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dal.Repositories.Abstract
{
    public interface IRentalRepository : IRepository<Rental>
    {
        List<Rental> GetByVehicleId(int vehicleId);
        List<Rental> GetByEmployeeId(int employeeId);
        List<Rental> GetByCompanyId(int companyId);
        Rental GetByIdWithAll(int id);
    }
}
