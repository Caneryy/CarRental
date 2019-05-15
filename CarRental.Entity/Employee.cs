using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public string UserId { get; set; }

        public int Role { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}
