using TestingProject.Models;

namespace TestingProject.Repository.DeliveryRepo
{
    public interface IDeliveryRepository
    {
        List<Delivery> GetAllDeleveries();

        List<Delivery> GetDeleveriesAvailable();

        List<Delivery> GetDeliveriesAvailableByBranch(int branch_id);
        Delivery GetById(int id);
        List<Delivery> GetByName(string Name);
        void Add(Delivery delivery);
        void Edit(Delivery delivery);

        void Delete(Delivery delivery);
        void SoftDelete(Delivery delivery);

        void save();
    }
}
