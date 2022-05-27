using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Customer customer)
        {
            var objFromDb = _db.Customer.FirstOrDefault(u => u.CustomerId == customer.CustomerId);
            objFromDb.FullName = customer.FullName;
            objFromDb.PhoneNumber = customer.PhoneNumber;
            objFromDb.Email = customer.Email;
            objFromDb.Address = customer.Address;
            objFromDb.City = customer.City;
            objFromDb.State = customer.State;
            objFromDb.PostCode = customer.PostCode;
        }
    }
}
