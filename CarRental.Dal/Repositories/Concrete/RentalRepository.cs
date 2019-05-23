using CarRental.Dal.Repositories.Abstract;
using CarRental.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dal.Repositories.Concrete
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(CarRentalContext context) : base(context)
        {
        }
        public CarRentalContext CarRentalContext { get { return _context as CarRentalContext; } }

        public List<Rental> GetByCompanyId(int companyId)
        {
            var employeeIds = CarRentalContext.Employees.Where(x => x.CompanyId == companyId).Select(s => s.Id).ToList();

            return CarRentalContext.Rentals.Where(w => employeeIds.Contains(w.EmployeeId)).ToList();
        }

        public List<Rental> GetByEmployeeId(int employeeId)
        {
            return CarRentalContext.Rentals.Where(r => r.EmployeeId == employeeId).Include(i => i.Customer).Include(i => i.Vehicle).ToList();
        }

        public List<Rental> GetByVehicleId(int vehicleId)
        {
            return CarRentalContext.Rentals.Where(v => v.VehicleId == vehicleId).ToList();
        }
    }
}
