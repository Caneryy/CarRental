﻿using CarRental.Dal.Repositories.Abstract;
using CarRental.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dal.Repositories.Concrete
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(CarRentalContext context) : base(context)
        {
        }
        public CarRentalContext CarRentalContext { get { return _context as CarRentalContext; } }
    }
}
