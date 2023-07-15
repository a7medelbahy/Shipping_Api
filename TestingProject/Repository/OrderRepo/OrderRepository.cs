using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using TestingProject.Models;

namespace TestingProject.Repository.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        ShippingContext db;

        public OrderRepository(ShippingContext _db)
        {
            this.db = _db;
        }
        public List<Order> GetOrders()
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o=>o.Products).ToList();
        }
        
        public List<Order> GetOrderByStatus(string status)
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o => o.Products).Where(o => o.Status == status).ToList();
        }
        
        public List<Order> GetOrdersByStatusDate(string status, DateTime startDate, DateTime endDate)
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o => o.Products).Where(o => o.Status == status && o.Order_Date.Date >= startDate.Date && o.Order_Date.Date <= endDate.Date).ToList();
        }
       
        public List<Order> GetOrdersByBranchId(int branch_Id) {

            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o => o.Products).Where(o => o.Branch_Id == branch_Id).ToList();

        }
        
        public Order GetOrderById(int id)
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).SingleOrDefault(o => o.Id == id);
        }

        public List<Order> GetOrdersByDeliveryId(int delivery_Id) {

            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o => o.Products).Where(o => o.Delivery_Id == delivery_Id).ToList();

        }
       
        public List<Order> GetOrdersByCustomerId(int customer_Id)
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o => o.Products).Where(o => o.Customer_Id == customer_Id).ToList();
        }
       
        public List<Order> GetOrdersByCustomerIdStatus(int customer_Id, string status)
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o => o.Products).Where(o => o.Customer_Id == customer_Id && o.Status==status).ToList();

        }
        public void AddOrder(Order order)
        {
            db.orders.Add(order);
        }
        public void DeleteOrder(int id)
        {
            Order order = db.orders.FirstOrDefault(o => o.Id == id);
            db.orders.Remove(order);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            db.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void UpdateOrderStatus(Order order, string status)
        {
            order.Status = status;
        }

        public List<Order> GetOrderByCutomerBranch(int branch_Id)
        {
            return db.orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Branch).Include(o => o.Governorate).Include(o => o.City).Include(o => o.Products).Where(o => o.Customer.Branch_Id == branch_Id).ToList();
        }
    }
}
