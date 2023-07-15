using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingProject.DTO.Order;
using TestingProject.Models;
using TestingProject.Repository.OrderCustomerRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class OrderCustomerController : ControllerBase
    {
        IOrderCustomerRepository orderCustRepo;
        public OrderCustomerController(IOrderCustomerRepository _orderCustRepo)
        {
            this.orderCustRepo = _orderCustRepo;
        }

        [HttpGet]
        [Route("customer/{customer_Id}")]
        public ActionResult GetOrdersByCustomer(int customer_Id)
        {
            List<Order> orders = orderCustRepo.GetOrdersByCustomer(customer_Id);
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
        [Route("customerStatus/{customer_Id}/{status}")]
        public ActionResult GetOrdersByCustomerStatus(int customer_Id, string status)
        {
            List<Order> orders = orderCustRepo.GetOrdersByCustomerStatus(customer_Id, status);
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
            Order order = orderCustRepo.GetOrderById(id);
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

        [HttpPost]
        [Route("Add")]
        public ActionResult<Order> AddOrder(OrderAddDtocs orderDO)
        {
            if (orderDO == null) return BadRequest();
            Order order = new Order()
            {
                Client_Name = orderDO.client_Name,
                Client_Email = orderDO.client_Email,
                Client_Phone = orderDO.client_Phone,
                Client_Village = orderDO.client_Village,
                Branch_Id = orderDO.branch_Id,
                Customer_Id = orderDO.customer_Id,
                Delivery_Id = orderDO.delivery_Id,
                Order_Date = orderDO.order_Date,
                Order_Type = orderDO.order_Type,
                Charge_Type = orderDO.charge_Type,
                Payment_Type = orderDO.payment_Type,
                Governorate_Id = orderDO.governorate_Id,
                City_Id = orderDO.city_Id,
                Status = orderDO.status,
                Total_Weight = orderDO.total_Weight,
                Total_Price = orderDO.total_Price,
                Products = orderDO.products
            };
            foreach (var item in order.Products)
            {
                item.order_Id = order.Id;
            }
            if (order == null) return BadRequest();
            orderCustRepo.AddOrder(order);
            orderCustRepo.Save();
            return Ok(order);
            ;
        }
    }
}
