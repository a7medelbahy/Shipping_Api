using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingProject.DTO.Order;
using TestingProject.Models;
using TestingProject.Repository.OrderAdminRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OrderAdminController : ControllerBase
    {
        IOrderAdminRepositorycs orderAdminRepo;
        public OrderAdminController(IOrderAdminRepositorycs _orderAdminRepo)
        {
            this.orderAdminRepo = _orderAdminRepo;
        }

        [HttpGet]
        [Route("All")]

        public ActionResult GetOrders()
        {
            List<Order> orders = orderAdminRepo.GetOrders();
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            foreach (var order in orders)
            {
                OrderDTO orderDTO = new OrderDTO()
            {
                id = order.Id,
                customer_Name = order.Customer.Name,
                customer_Phone = order.Customer.Phone,
                client_Name = order.Client_Name,
                client_Phone = order.Client_Phone,
                client_Email=order.Client_Email,
                delivery_Name = order.Delivery?.Name,
                delivery_Phone = order.Delivery?.Phone,
                order_Date = order.Order_Date,
                order_Type = order.Order_Type,
                charge_Type = order.Charge_Type,
                payment_Type = order.Payment_Type,
                total_Price = order.Total_Price,
                total_Weight = order.Total_Weight,
                status = order.Status,
                branch_Name = order.Branch.Name,
                governorate_Name = order.Governorate.Name,
                city_Name = order.City.Name,
                client_Village = order.Client_Village,
                branch_Id = order.Branch.Id,
                governorate_Id = order.Governorate.Id,
                city_Id = order.City.Id,
                products = order.Products
                };
            orderDTOs.Add(orderDTO);
        }

            return Ok(orderDTOs);
    }

        [HttpGet]
        [Route("Status/{status}")]
        public ActionResult GetOrdersByStatus(string status)
        {
            List<Order> orders = orderAdminRepo.GetOrdersByStatus(status);
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            foreach (var order in orders)
            {
                OrderDTO orderDTO = new OrderDTO()
                {
                    id = order.Id,
                    customer_Name = order.Customer.Name,
                    customer_Phone = order.Customer.Phone,
                    client_Name = order.Client_Name,
                    client_Phone = order.Client_Phone,
                    client_Email=order.Client_Email,
                    delivery_Name = order.Delivery?.Name,
                    delivery_Phone = order.Delivery?.Phone,
                    order_Date = order.Order_Date,
                    order_Type = order.Order_Type,
                    charge_Type = order.Charge_Type,
                    payment_Type = order.Payment_Type,
                    total_Price = order.Total_Price,
                    total_Weight = order.Total_Weight,
                    status = order.Status,
                    branch_Name = order.Branch.Name,
                    governorate_Name = order.Governorate.Name,
                    city_Name = order.City.Name,
                    client_Village = order.Client_Village,
                    branch_Id = order.Branch.Id,
                    governorate_Id = order.Governorate.Id,
                    city_Id = order.City.Id,
                    products = order.Products
                };
                orderDTOs.Add(orderDTO);
            }

            return Ok(orderDTOs);
        }

        [HttpGet]
        [Route("Report/{status}/{startDate}/{endDate}")]
        public ActionResult GetOrdersReport(string status,DateTime startDate,DateTime endDate)
        {
            List<Order> orders = orderAdminRepo.GetOrdersReport(status,startDate,endDate);
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            foreach (var order in orders)
            {
                OrderDTO orderDTO = new OrderDTO()
                {
                    id = order.Id,
                    customer_Name = order.Customer.Name,
                    customer_Phone = order.Customer.Phone,
                    client_Name = order.Client_Name,
                    client_Phone = order.Client_Phone,
                    client_Email=order.Client_Email,
                    delivery_Name = order.Delivery?.Name,
                    delivery_Phone = order.Delivery?.Phone,
                    order_Date = order.Order_Date,
                    order_Type = order.Order_Type,
                    charge_Type = order.Charge_Type,
                    payment_Type = order.Payment_Type,
                    total_Price = order.Total_Price,
                    total_Weight = order.Total_Weight,
                    status = order.Status,
                    branch_Name = order.Branch.Name,
                    governorate_Name = order.Governorate.Name,
                    city_Name = order.City.Name,
                    client_Village = order.Client_Village,
                    branch_Id = order.Branch.Id,
                    governorate_Id = order.Governorate.Id,
                    city_Id = order.City.Id,
                    products = order.Products
                };
                orderDTOs.Add(orderDTO);
            }

            return Ok(orderDTOs);
        }

        [HttpGet]
        [Route("Id/{id}")]
        public ActionResult GetOrderById(int id)
        {
            Order order = orderAdminRepo.GetOrderById(id);
            if (order == null) return NotFound();
            OrderDTO orderDTO = new OrderDTO()
            {
                id = order.Id,
                customer_Name = order.Customer.Name,
                customer_Phone = order.Customer.Phone,
                client_Name = order.Client_Name,
                client_Phone = order.Client_Phone,
                client_Email=order.Client_Email,
                delivery_Name = order.Delivery?.Name,
                delivery_Phone = order.Delivery?.Phone,
                order_Date = order.Order_Date,
                order_Type = order.Order_Type,
                charge_Type = order.Charge_Type,
                payment_Type = order.Payment_Type,
                total_Price = order.Total_Price,
                total_Weight = order.Total_Weight,
                status = order.Status,
                branch_Name = order.Branch.Name,
                governorate_Name = order.Governorate.Name,
                city_Name = order.City.Name,
                client_Village = order.Client_Village,
                branch_Id = order.Branch.Id,
                governorate_Id = order.Governorate.Id,
                city_Id = order.City.Id,
                products = order.Products
            };
            return Ok(orderDTO);
        }
    }
}
