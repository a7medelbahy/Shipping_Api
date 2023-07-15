using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingProject.DTO.Order;
using TestingProject.Models;
using TestingProject.Repository.OrderEmployeeRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class OrderEmployeeController : ControllerBase
    {
        IOrderEmployeeRepository orderEmpRepo;
        public OrderEmployeeController(IOrderEmployeeRepository _orderEmpRepo)
        {
            this.orderEmpRepo = _orderEmpRepo;
        }

        [HttpGet]
        [Route("Branch/{branch_Id}")]
        public ActionResult GetOrdersByCustomerBranch(int branch_Id)
        {
            List<Order> orders = orderEmpRepo.GetOrdersByCustomerBranch(branch_Id);
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
        [Route("BranchStatus/{branch_Id}/{status}")]
        public ActionResult GetOrdersByCustomerBranchStatus(int branch_Id,string status)
        {
            List<Order> orders = orderEmpRepo.GetOrdersByCustomerBranchStatus(branch_Id,status);
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
        [Route("search/{id}/{branch_Id}")]
        public ActionResult GetSearch(int id,int branch_Id)
        {
            List<Order> orders = orderEmpRepo.GetOrderSearch(id,branch_Id);
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
                    client_Email = order.Client_Email,
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
            Order order = orderEmpRepo.GetOrderById(id);
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

        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult EditOrder(OrderAddDtocs orderAddDtocs, int id)
        {
            if (orderAddDtocs == null) return BadRequest();
            Order order = orderEmpRepo.GetOrderById(id);
            if (order == null) return BadRequest();
            order.Client_Name = orderAddDtocs.client_Name;
            order.Client_Phone = orderAddDtocs.client_Phone;
            order.Client_Email = orderAddDtocs.client_Email;
            order.Client_Village = orderAddDtocs.client_Village;
            order.Order_Type = orderAddDtocs.order_Type;
            order.Charge_Type = orderAddDtocs.charge_Type;
            order.Payment_Type = orderAddDtocs.payment_Type;
            order.Total_Price = orderAddDtocs.total_Price;
            order.Total_Weight = orderAddDtocs.total_Weight;
            order.Branch_Id = orderAddDtocs.branch_Id;
            order.Governorate_Id = orderAddDtocs.governorate_Id;
            order.City_Id = orderAddDtocs.city_Id;
            foreach (var product in order.Products)
            {

                orderEmpRepo.updateProduct(product);
            }
            order.Products = orderAddDtocs.products;
            foreach (var item in order.Products)
            {
                item.order_Id = order.Id;
            }
            orderEmpRepo.EditOrder(order);
            orderEmpRepo.Save();
            return Ok();
        }

        [HttpPut]
        [Route("status/{id}/{status}")]
        public ActionResult UpdateOrderStatus(OrderAddDtocs orderAddDtocs,int id, string status)
        {
            Order order = orderEmpRepo.GetOrderById(id);
            if (order == null) return BadRequest();
            orderEmpRepo.UpdateOrderStatus(order, status);
            orderEmpRepo.Save();
            return Ok();
        }

        [HttpPut]
        [Route("delivery/{id}/{delivery_Id}")]
        public ActionResult UpdateOrderDeliveryId(OrderAddDtocs orderAddDtocs, int id, int delivery_Id)
        {
            Order order = orderEmpRepo.GetOrderById(id);
            if (order == null) return BadRequest();
            orderEmpRepo.UpdateOrderDeliveryId(order, delivery_Id);
            orderEmpRepo.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult DeleteOrder(int id)
        {
            Order order = orderEmpRepo.GetOrderById(id);
            if (order == null) return BadRequest();
            orderEmpRepo.DeleteOrder(id);
            orderEmpRepo.Save();
            return NoContent();
        }
    }
}
