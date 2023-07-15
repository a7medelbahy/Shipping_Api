using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestingProject.DTO.Order;
using TestingProject.Models;
using TestingProject.Repository.OrderDeliveryRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Delivery")]
    public class OrderDeliveryController : ControllerBase
    {
        IOrderDeliveryRepository orderDeliveryRepo;
        public OrderDeliveryController(IOrderDeliveryRepository _orderDelvRepo) { 
            this.orderDeliveryRepo = _orderDelvRepo;
        }

        [HttpGet]
        [Route("delivery/{delivery_Id}")]
        public ActionResult GetOrdersByDelivery(int delivery_Id)
        {
            List<Order> orders = orderDeliveryRepo.GetOrdersByDelivery(delivery_Id);
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            foreach (var order in orders)
            {
                OrderDTO orderDTO = new OrderDTO()
                {
                    id = order.Id,
                    customer_Name = order.Customer.Name,
                    customer_Phone = order.Customer.Phone,
                    client_Name = order.Client_Name,
                    client_Email = order.Client_Email,
                    client_Phone = order.Client_Phone,
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
        [Route("deliveryStatus/{delivery_Id}/{status}")]
        public ActionResult GetOrdersByDeliveryStatus(int delivery_Id, string status)
        {
            List<Order> orders = orderDeliveryRepo.GetOrdersByDeliveryStatus(delivery_Id, status);
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            foreach (var order in orders)
            {
                OrderDTO orderDTO = new OrderDTO()
                {
                    id = order.Id,
                    customer_Name = order.Customer.Name,
                    customer_Phone = order.Customer.Phone,
                    client_Name = order.Client_Name,
                    client_Email = order.Client_Email,
                    client_Phone = order.Client_Phone,
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
        [Route("search/{id}/{delivery_Id}")]
        public ActionResult GetSearch(int id,int delivery_Id)
        {
            List<Order> orders = orderDeliveryRepo.GetSearch(id, delivery_Id);
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            foreach (var order in orders)
            {
                OrderDTO orderDTO = new OrderDTO()
                {
                    id = order.Id,
                    customer_Name = order.Customer.Name,
                    customer_Phone = order.Customer.Phone,
                    client_Name = order.Client_Name,
                    client_Email = order.Client_Email,
                    client_Phone = order.Client_Phone,
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
            Order order = orderDeliveryRepo.GetOrderById(id);
            if (order == null) return NotFound();
            OrderDTO orderDTO = new OrderDTO()
            {
                id = order.Id,
                customer_Name = order.Customer.Name,
                customer_Phone = order.Customer.Phone,
                client_Name = order.Client_Name,
                client_Email = order.Client_Email,
                client_Phone = order.Client_Phone,
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

        [HttpPut]
        [Route("status/{id}/{status}")]
        public ActionResult UpdateOrderStatus(OrderAddDtocs orderAddDtocs, int id, string status)
        {
            Order order = orderDeliveryRepo.GetOrderById(id);
            if (order == null) return BadRequest();
            orderDeliveryRepo.UpdateOrderStatus(order, status);
            orderDeliveryRepo.Save();
            return Ok();
        }
    }
}
