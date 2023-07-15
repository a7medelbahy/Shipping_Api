using TestingProject.Models;

namespace TestingProject.Repository.CustomerRepo
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer();

        List<Customer> GetAllAvailableCustomer();
        Customer GetById(int id);

        List<Customer> GetByName(string name);

        void Add(Customer customer);

        void Edit(Customer customer);

        void Delete(Customer customer);

        void SoftDelete(Customer cust);

        void Save();
    }
}
