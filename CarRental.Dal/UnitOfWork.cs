using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Dal.Repositories.Abstract;
using CarRental.Dal.Repositories.Concrete;

namespace CarRental.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private CarRentalContext _carRentalContext;
        public UnitOfWork(CarRentalContext context)
        {
            _carRentalContext = context;
            CompanyRepository = new CompanyRepository(_carRentalContext);
            CustomerRepository = new CustomerRepository(_carRentalContext);
            EmployeeRepository = new EmployeeRepository(_carRentalContext);
            RentalRepository = new RentalRepository(_carRentalContext);
            VehicleRepository = new VehicleRepository(_carRentalContext);
        }
        public ICompanyRepository CompanyRepository { get; private set; }

        public ICustomerRepository CustomerRepository { get; private set; }

        public IEmployeeRepository EmployeeRepository { get; private set; }

        public IRentalRepository RentalRepository { get; private set; }

        public IVehicleRepository VehicleRepository { get; private set; }

        public int Complete()
        {
            return _carRentalContext.SaveChanges();
        }

        public void Dispose()
        {
            _carRentalContext.Dispose();
        }
    }
}
