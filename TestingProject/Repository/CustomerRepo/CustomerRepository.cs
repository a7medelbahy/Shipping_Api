using Microsoft.EntityFrameworkCore;
using TestingProject.Models;

namespace TestingProject.Repository.CustomerRepo
{
    public class CustomerRepository:ICustomerRepository
    {
        ShippingContext db;
        public CustomerRepository(ShippingContext _db)
        {
            this.db = _db;
        }

        public void Add(Customer customer)
        {
            db.customers.Add(customer);
        }

        public void Delete(Customer customer)
        {

            db.customers.Remove(customer);
        }

        public void Edit(Customer customer)
        {
            db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Customer> GetAllCustomer()
        {
            return db.customers.Include(e => e.Branch).Include(e => e.Role).ToList();
        }


        public List<Customer> GetAllAvailableCustomer()
        {
            return db.customers.Include(e => e.Branch).Include(e => e.Role).Where(e => e.Available == true).ToList();
        }
        public Customer GetById(int id)
        {
            return db.customers.Include(e => e.Branch).Include(e => e.Role).SingleOrDefault(e => e.Id == id);
        }

        public List<Customer> GetByName(string name)
        {
            return db.customers.Include(e => e.Branch).Include(e => e.Role).Where(e => e.Name.Contains(name)).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void SoftDelete(Customer cust)
        {
            cust.Available = !cust.Available;
        }
    }
}
