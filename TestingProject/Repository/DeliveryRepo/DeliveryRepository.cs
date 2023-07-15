using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using TestingProject.Models;

namespace TestingProject.Repository.DeliveryRepo
{
    public class DeliveryRepository:IDeliveryRepository
    {
        ShippingContext db;
        public DeliveryRepository(ShippingContext _db)
        {
            this.db = _db;
        }
        public void Add(Delivery delivery)
        {
            db.deliveries.Add(delivery);

        }

        public void Delete(Delivery delivery)
        {
            db.deliveries.Remove(delivery);
        }

        public void Edit(Delivery delivery)
        {
            db.Entry(delivery).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }

        public List<Delivery> GetAllDeleveries()
        {
            return db.deliveries.Include(d => d.Branch).Include(d=>d.Role).ToList();
        }

        public Delivery GetById(int id)
        {
            return db.deliveries.Include(d => d.Branch).Include(d => d.Role).SingleOrDefault(d => d.Id == id);
        }

        public List<Delivery> GetByName(string Name)
        {
            return db.deliveries.Include(d => d.Branch).Include(d => d.Role).Where(d => d.Name.Contains(Name)).ToList();

        }

        public List<Delivery> GetDeleveriesAvailable()
        {
            return db.deliveries.Include(d => d.Branch).Include(d => d.Role).Where(d => d.Available ==true).ToList();

        }
        public List<Delivery> GetDeliveriesAvailableByBranch(int branch_id)
        {
            return db.deliveries.Include(d => d.Branch).Include(d => d.Role).Where(d => d.Available == true && d.Branch_Id == branch_id).ToList();
        }

        public void save()
        {
            db.SaveChanges();
        }

        public void SoftDelete(Delivery delivery)
        {
            delivery.Available = !delivery.Available;
        }
    }
}
