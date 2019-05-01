using CarRental.Dal.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dal
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IRentalRepository RentalRepository { get; }
        IVehicleRepository VehicleRepository { get; }

        int Complete();
    }
}
