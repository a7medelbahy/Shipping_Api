using TestingProject.Models;

namespace TestingProject.Repository.OrderRepo
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();

        Order GetOrderById(int id);

        List<Order> GetOrderByStatus(string status);

        List<Order> GetOrdersByStatusDate(string status,DateTime startDate, DateTime endDate);

        List<Order> GetOrdersByBranchId(int branch_Id);

        List<Order> GetOrdersByDeliveryId(int delivery_Id);

        List<Order> GetOrdersByCustomerId(int customer_Id);

        List<Order> GetOrdersByCustomerIdStatus(int customer_Id,string status);

        List<Order> GetOrderByCutomerBranch(int  branch_Id);
        void AddOrder(Order order);

        void UpdateOrder(Order order);

        void UpdateOrderStatus(Order order, string status);

        void DeleteOrder(int id);

        void Save();
    }
}
