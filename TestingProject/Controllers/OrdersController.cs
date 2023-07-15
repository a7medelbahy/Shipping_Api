using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingProject.DTO.Order;
using TestingProject.Models;
using TestingProject.Repository.OrderRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderRepository orderRepo;

        public OrdersController(IOrderRepository _orderRepo)
        {
            this.orderRepo = _orderRepo;
        }

        //[HttpGet]
        //[Route("All")]
        //public IActionResult GetOrders()
        //{
        //    List<Order> orders = orderRepo.GetOrders();
        //    List<OrderDTO> orderDTOs = new List<OrderDTO>();
        //    foreach (var order in orders)
        //    {
        //        OrderDTO orderDTO = new OrderDTO()
        //        {
        //            id = order.Id,
        //            customer_Name = order.Customer.Name,
        //            customer_Phone = order.Customer.Phone,
        //            client_Name = order.Client_Name,
        //            client_Phone = order.Client_Phone,
        //            delivery_Name = order.Delivery?.Name,
        //            delivery_Phone = order.Delivery?.Phone,
        //            order_Date = order.Order_Date.ToShortDateString()+" - "+order.Order_Date.ToShortTimeString(),
        //            order_Type = order.Order_Type,
        //            charge_Type = order.Charge_Type,
        //            payment_Type = order.Payment_Type,
        //            total_Price = order.Total_Price,
        //            total_Weight = order.Total_Weight,
        //            status = order.Status,
        //            branch_Name = order.Branch.Name,
        //            governorate_Name = order.Governorate.Name,
        //            city_Name = order.City.Name,
        //            client_Village = order.Client_Village,
        //            products=order.Products
        //        };
        //        orderDTOs.Add(orderDTO);
        //    }

        //    return Ok(orderDTOs);
        //}

        //[HttpGet]
        //[Route("Branch/{branch_Id}")]
        //public IActionResult GetOrdersByBranch(int branch_Id)
        //{
        //    List<Order> orders = orderRepo.GetOrdersByBranchId(branch_Id);
        //    List<OrderDTO> orderDTOs = new List<OrderDTO>();
        //    foreach (var order in orders)
        //    {
        //        OrderDTO orderDTO = new OrderDTO()
        //        {
        //            id = order.Id,
        //            customer_Name = order.Customer.Name,
        //            customer_Phone = order.Customer.Phone,
        //            client_Name = order.Client_Name,
        //            client_Phone = order.Client_Phone,
        //            delivery_Name = order.Delivery.Name,
        //            delivery_Phone = order.Delivery.Phone,
        //            order_Date = order.Order_Date.ToShortDateString() + " - " + order.Order_Date.ToShortTimeString(),
        //            order_Type = order.Order_Type,
        //            charge_Type = order.Charge_Type,
        //            payment_Type = order.Payment_Type,
        //            total_Price = order.Total_Price,
        //            total_Weight = order.Total_Weight,
        //            status = order.Status,
        //            branch_Name = order.Branch.Name,
        //            governorate_Name = order.Governorate.Name,
        //            city_Name = order.City.Name,
        //            client_Village = order.Client_Village
        //        };
        //        orderDTOs.Add(orderDTO);
        //    }

        //    return Ok(orderDTOs);
        //}

        //[HttpGet]
        //[Route("Delivery/{delivery_Id}")]
        //public IActionResult GetOrdersByDelivery(int delivery_Id)
        //{
        //    List<Order> orders = orderRepo.GetOrdersByDeliveryId(delivery_Id);
        //    List<OrderDTO> orderDTOs = new List<OrderDTO>();
        //    foreach (var order in orders)
        //    {
        //        OrderDTO orderDTO = new OrderDTO()
        //        {
        //            id = order.Id,
        //            customer_Name = order.Customer.Name,
        //            customer_Phone = order.Customer.Phone,
        //            client_Name = order.Client_Name,
        //            client_Phone = order.Client_Phone,
        //            delivery_Name = order.Delivery.Name,
        //            delivery_Phone = order.Delivery.Phone,
        //            order_Date = order.Order_Date.ToShortDateString() + " - " + order.Order_Date.ToShortTimeString(),
        //            order_Type = order.Order_Type,
        //            charge_Type = order.Charge_Type,
        //            payment_Type = order.Payment_Type,
        //            total_Price = order.Total_Price,
        //            total_Weight = order.Total_Weight,
        //            status = order.Status,
        //            branch_Name = order.Branch.Name,
        //            governorate_Name = order.Governorate.Name,
        //            city_Name = order.City.Name,
        //            client_Village = order.Client_Village
        //        };
        //        orderDTOs.Add(orderDTO);
        //    }

        //    return Ok(orderDTOs);
        //}

        //[HttpGet]
        //[Route("Customer/{customer_Id}")]
        //public IActionResult GetOrdersByCustomer(int customer_Id)
        //{
        //    List<Order> orders = orderRepo.GetOrdersByCustomerId(customer_Id);
        //    List<OrderDTO> orderDTOs = new List<OrderDTO>();
        //    foreach (var order in orders)
        //    {
        //        OrderDTO orderDTO = new OrderDTO()
        //        {
        //            id = order.Id,
        //            customer_Name = order.Customer.Name,
        //            customer_Phone = order.Customer.Phone,
        //            client_Name = order.Client_Name,
        //            client_Phone = order.Client_Phone,
        //            delivery_Name = order.Delivery.Name,
        //            delivery_Phone = order.Delivery.Phone,
        //            order_Date = order.Order_Date.ToShortDateString() + " - " + order.Order_Date.ToShortTimeString(),
        //            order_Type = order.Order_Type,
        //            charge_Type = order.Charge_Type,
        //            payment_Type = order.Payment_Type,
        //            total_Price = order.Total_Price,
        //            total_Weight = order.Total_Weight,
        //            status = order.Status,
        //            branch_Name = order.Branch.Name,
        //            governorate_Name = order.Governorate.Name,
        //            city_Name = order.City.Name,
        //            client_Village = order.Client_Village
        //        };
        //        orderDTOs.Add(orderDTO);
        //    }

        //    return Ok(orderDTOs);
        //}

        //[HttpGet]
        //[Route("Customer/{customer_Id}/{status}")]
        //public IActionResult GetOrdersByCustomerStatus(int customer_Id,string status)
        //{
        //    List<Order> orders = orderRepo.GetOrdersByCustomerIdStatus(customer_Id,status);
        //    List<OrderDTO> orderDTOs = new List<OrderDTO>();
        //    foreach (var order in orders)
        //    {
        //        OrderDTO orderDTO = new OrderDTO()
        //        {
        //            id = order.Id,
        //            customer_Name = order.Customer.Name,
        //            customer_Phone = order.Customer.Phone,
        //            client_Name = order.Client_Name,
        //            client_Phone = order.Client_Phone,
        //            delivery_Name = order.Delivery.Name,
        //            delivery_Phone = order.Delivery.Phone,
        //            order_Date = order.Order_Date.ToShortDateString() + " - " + order.Order_Date.ToShortTimeString(),
        //            order_Type = order.Order_Type,
        //            charge_Type = order.Charge_Type,
        //            payment_Type = order.Payment_Type,
        //            total_Price = order.Total_Price,
        //            total_Weight = order.Total_Weight,
        //            status = order.Status,
        //            branch_Name = order.Branch.Name,
        //            governorate_Name = order.Governorate.Name,
        //            city_Name = order.City.Name,
        //            client_Village = order.Client_Village
        //        };
        //        orderDTOs.Add(orderDTO);
        //    }

        //    return Ok(orderDTOs);
        //}

        //[HttpPost]
        //[Route("Add")]
        //public ActionResult<Order> AddOrder(OrderAddDtocs orderDO)
        //{
        //    if (orderDO == null) return BadRequest();
        //    Order order = new Order()
        //    {
        //        Client_Name = orderDO.client_Name,
        //        Client_Email = orderDO.client_Email,
        //        Client_Phone = orderDO.client_Phone,
        //        Client_Village = orderDO.client_Village,
        //        Branch_Id = orderDO.branch_Id,
        //        Customer_Id = orderDO.customer_Id,
        //        Delivery_Id = orderDO.delivery_Id,
        //        Order_Date = orderDO.order_Date,
        //        Order_Type = orderDO.order_Type,
        //        Charge_Type = orderDO.charge_Type,
        //        Payment_Type = orderDO.payment_Type,
        //        Governorate_Id = orderDO.governorate_Id,
        //        City_Id = orderDO.city_Id,
        //        Status = orderDO.status,
        //        Total_Weight = orderDO.total_Weight,
        //        Total_Price = orderDO.total_Price,
        //        Products=orderDO.products
        //    };
        //    foreach (var item in order.Products)
        //    {
        //        item.order_Id = order.Id;
        //    }
        //    if (order == null) return BadRequest();
        //    orderRepo.AddOrder(order);
        //    orderRepo.Save();
        //    return Ok(order);
        //    ; }

        //[HttpPut]
        //[Route("EditStatus/{id}/{status}")]
        //public ActionResult UpdateStatus(OrderAddDtocs orderAddDtocs, int id, string status)
        //{
        //    Order order = orderRepo.GetOrderById(id);
        //    orderRepo.UpdateOrderStatus(order, status);
        //    orderRepo.Save();
        //    return Ok();
        //}

        //[HttpPut]
        //[Route("Edit/{id}")]
        //public ActionResult UpdareOrder(OrderAddDtocs orderAddDtocs, int id) {
        //    if (orderAddDtocs == null) return BadRequest();
        //    Order order = orderRepo.GetOrderById(id);
        //    if (order == null) return BadRequest();
        //    order.Client_Name = orderAddDtocs.client_Name;
        //    order.Client_Phone = orderAddDtocs.client_Phone;
        //    order.Client_Email=orderAddDtocs.client_Email;
        //    order.Client_Village = orderAddDtocs.client_Village;
        //    order.Order_Type= orderAddDtocs.order_Type;
        //    order.Charge_Type = orderAddDtocs.charge_Type;
        //    order.Payment_Type = orderAddDtocs.payment_Type;
        //    order.Total_Price= orderAddDtocs.total_Price;
        //    order.Total_Weight= orderAddDtocs.total_Weight;
        //    order.Branch_Id = orderAddDtocs.branch_Id;
        //    order.Governorate_Id = orderAddDtocs.governorate_Id;
        //    order.City_Id = orderAddDtocs.city_Id;

        //    orderRepo.UpdateOrder(order);
        //    return Ok();
        //}

        //[HttpGet]
        //[Route("Id/{id}")]
        //public ActionResult<OrderDTO> GetOrderById(int id)
        //{
        //    Order order = orderRepo.GetOrderById(id);
        //    if (order == null) return NotFound();
        //    OrderDTO orderDTO = new OrderDTO()
        //    {
        //        id = order.Id,
        //        customer_Name = order.Customer.Name,
        //        customer_Phone = order.Customer.Phone,
        //        client_Name = order.Client_Name,
        //        client_Phone = order.Client_Phone,
        //        delivery_Name = order.Delivery.Name,
        //        delivery_Phone = order.Delivery.Phone,
        //        order_Date = order.Order_Date.ToShortDateString() + " - " + order.Order_Date.ToShortTimeString(),
        //        order_Type = order.Order_Type,
        //        charge_Type = order.Charge_Type,
        //        payment_Type = order.Payment_Type,
        //        total_Price = order.Total_Price,
        //        total_Weight = order.Total_Weight,
        //        status = order.Status,
        //        branch_Name = order.Branch.Name,
        //        governorate_Name = order.Governorate.Name,
        //        city_Name = order.City.Name,
        //        client_Village = order.Client_Village
        //    };
        //    return orderDTO;
        //}

        //[HttpDelete]
        //[Route("Delete/{id}")]
        //public ActionResult DeleteOrder(int id)
        //{
        //    Order order = orderRepo.GetOrderById(id);
        //    if (order == null) return BadRequest();
        //    orderRepo.DeleteOrder(id);
        //    orderRepo.Save();
        //    return NoContent();
        //}

        //[HttpGet]
        //[Route("Status/{status}")]
        //public ActionResult GetOrderByStatus(string status)
        //{
        //    List<Order> orders = orderRepo.GetOrderByStatus(status);
        //    if (orders == null) return NotFound();
        //    List<OrderDTO> orderDTOs = new List<OrderDTO>();
        //    foreach (var order in orders)
        //    {
        //        OrderDTO orderDTO = new OrderDTO()
        //        {
        //            id = order.Id,
        //            customer_Name = order.Customer.Name,
        //            customer_Phone = order.Customer.Phone,
        //            client_Name = order.Client_Name,
        //            client_Phone = order.Client_Phone,
        //            delivery_Name = order.Delivery.Name,
        //            delivery_Phone = order.Delivery.Phone,
        //            order_Date = order.Order_Date.ToShortDateString() + " - " + order.Order_Date.ToShortTimeString(),
        //            order_Type = order.Order_Type,
        //            charge_Type = order.Charge_Type,
        //            payment_Type = order.Payment_Type,
        //            total_Price = order.Total_Price,
        //            total_Weight = order.Total_Weight,
        //            status = order.Status,
        //            branch_Name = order.Branch.Name,
        //            governorate_Name = order.Governorate.Name,
        //            city_Name = order.City.Name,
        //            client_Village = order.Client_Village
        //        };
        //        orderDTOs.Add(orderDTO);
        //    }
        //    return Ok(orderDTOs);
        //}
        
        //[HttpGet]
        //[Route("report/{status}/{startDate}/{endDate}")]
        //public ActionResult OrdersReport(string status, DateTime startDate, DateTime endDate)
        //{
        //    List<Order> orders = orderRepo.GetOrdersByStatusDate(status,startDate,endDate);
        //    if (orders == null) return NotFound();
        //    List<OrderDTO> orderDTOs = new List<OrderDTO>();
        //    foreach (var order in orders)
        //    {
        //        OrderDTO orderDTO = new OrderDTO()
        //        {
        //            id = order.Id,
        //            customer_Name = order.Customer.Name,
        //            customer_Phone = order.Customer.Phone,
        //            client_Name = order.Client_Name,
        //            client_Phone = order.Client_Phone,
        //            delivery_Name = order.Delivery.Name,
        //            delivery_Phone = order.Delivery.Phone,
        //            order_Date = order.Order_Date.ToShortDateString() + " - " + order.Order_Date.ToShortTimeString(),
        //            order_Type = order.Order_Type,
        //            charge_Type = order.Charge_Type,
        //            payment_Type = order.Payment_Type,
        //            total_Price = order.Total_Price,
        //            total_Weight = order.Total_Weight,
        //            status = order.Status,
        //            branch_Name = order.Branch.Name,
        //            governorate_Name = order.Governorate.Name,
        //            city_Name = order.City.Name,
        //            client_Village = order.Client_Village
        //        };
        //        orderDTOs.Add(orderDTO);
        //    }
        //    return Ok(orderDTOs);
        //}
    }
}
