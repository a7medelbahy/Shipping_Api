using Microsoft.EntityFrameworkCore;
using TestingProject.Models;

namespace TestingProject.Repository.OrderDeliveryRepo
{
    public class OrderDeliveryRepository : IOrderDeliveryRepository
    {
        ShippingContext db;
        public OrderDeliveryRepository(ShippingContext _db) {
            this.db = _db;
        }

        public List<Order> GetOrdersByDelivery(int delivery_Id)
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Where(o => o.Delivery_Id == delivery_Id).ToList();
        }

        public List<Order> GetOrdersByDeliveryStatus(int delivery_Id, string status)
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o => o.Products).Where(o => o.Delivery_Id == delivery_Id && o.Status == status).ToList();
        }

        public List<Order> GetSearch(int id,int delivery_Id)
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o => o.Products).Where(o => o.Delivery_Id == delivery_Id && o.Id == id).ToList();

        }

        public Order GetOrderById(int id)
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o => o.Products).SingleOrDefault(o => o.Id == id);
        }

        public void UpdateOrderStatus(Order order, string status)
        {
            order.Status = status;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
