using TestingProject.Models;

namespace TestingProject.Repository.EmployeeRepo
{
    public interface IEmployeeRepository
    {
        List<Employee> getAll();

        Employee GetById(int id);

        List<Employee> getAvailableEmployees();

        List<Employee> GetByName(string name);

        void Add(Employee emp);

        void Edit(Employee emp);

        void Delete(int id);

        void SoftDelete(Employee emp);

        void Save();
    }
}
