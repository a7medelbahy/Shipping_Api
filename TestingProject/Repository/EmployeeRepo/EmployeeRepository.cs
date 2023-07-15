using TestingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace TestingProject.Repository.EmployeeRepo
{
    public class EmployeeRepository:IEmployeeRepository
    {
        ShippingContext db;
        public EmployeeRepository(ShippingContext _db)
        {
            this.db = _db;
        }
        public void Add(Employee emp)
        {
            db.employees.Add(emp);
        }


        public void Edit(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Employee emp = db.employees.Find(id);
            db.employees.Remove(emp);
        }

        public List<Employee> getAll()
        {
            return db.employees.Include(b => b.Branch).Include(b => b.Role).ToList();
        }

        public List<Employee> getAvailableEmployees()
        {
            return db.employees.Include(b => b.Branch).Include(b => b.Role).Where(b=>b.Available==true).ToList();

        }

        public Employee GetById(int id)
        {
            return db.employees.Include(b => b.Branch).Include(b => b.Role).FirstOrDefault(emp => emp.Id == id);
        }


        public List<Employee> GetByName(string name)
        {
            return db.employees.Include(b => b.Branch).Include(b => b.Role).Where(emp => emp.Name.Contains(name)).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void SoftDelete(Employee Emp)
        {
            Emp.Available = !Emp.Available;

        }

    }
}
