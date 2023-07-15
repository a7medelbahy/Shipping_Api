using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestingProject.DTO.Customer;
using TestingProject.Models;
using TestingProject.Repository.CustomerRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class CustomersController : ControllerBase
    {
        ICustomerRepository CustRepo;

        public CustomersController(ICustomerRepository _CustRepo)
        {
            this.CustRepo = _CustRepo;
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetCustomer()
        {
            List<Customer> customers = CustRepo.GetAllCustomer();
            if (customers == null)
            {
                return NotFound();
            }
            else
            {
                List<CustomerDTO> customerDTOs = new List<CustomerDTO>();

                foreach (Customer cust in customers)
                {
                    CustomerDTO customerDTO = new CustomerDTO()
                    {
                        id = cust.Id,
                        name = cust.Name,
                        email = cust.Email,
                        phone = cust.Phone,
                        address = cust.Address,
                        password = cust.Password,
                        store_Name = cust.Store_Name,
                        special_Discount_Perc = cust.Special_Discount_Perc,
                        refused_Order_Perc = cust.Refused_Order_Perc,
                        available = cust.Available,
                        branch = cust.Branch.Name,
                        branch_Id = cust.Branch_Id,
                        role_Name=cust.Role.Name

                    };
                    customerDTOs.Add(customerDTO);
                }

                return Ok(customerDTOs);
            }
        }


        [HttpGet]
        [Route("Available")]

        public ActionResult GetCustomersAvailable()
        {
            List<Customer> customers = CustRepo.GetAllAvailableCustomer();
            if (customers == null)
            {
                return NotFound();
            }
            else
            {
                List<CustomerDTO> customerDTOs = new List<CustomerDTO>();

                foreach (Customer cust in customers)
                {
                    CustomerDTO customerDTO = new CustomerDTO()
                    {
                        id = cust.Id,
                        name = cust.Name,
                        email = cust.Email,
                        phone = cust.Phone,
                        address = cust.Address,
                        password = cust.Password,
                        store_Name = cust.Store_Name,
                        available = cust.Available,
                        special_Discount_Perc = cust.Special_Discount_Perc,
                        refused_Order_Perc = cust.Refused_Order_Perc,
                        branch = cust.Branch.Name,
                        branch_Id = cust.Branch_Id,
                        role_Name = cust.Role.Name
                    };
                    customerDTOs.Add(customerDTO);
                }

                return Ok(customerDTOs);
            }
        }


        [HttpGet]
        [Route("Id/{id}")]
        public ActionResult GetCustomerById(int id)
        {
            var cust = CustRepo.GetById(id);
            if (cust == null)
            {
                return NotFound();
            }
            else
            {
                CustomerDTO customerDTO = new CustomerDTO()
                {
                    id = cust.Id,
                    name = cust.Name,
                    email = cust.Email,
                    phone = cust.Phone,
                    address = cust.Address,
                    password = cust.Password,
                    store_Name = cust.Store_Name,
                    special_Discount_Perc = cust.Special_Discount_Perc,
                    refused_Order_Perc = cust.Refused_Order_Perc,
                    available = cust.Available,
                    branch = cust.Branch.Name,
                    branch_Id = cust.Branch_Id,
                    role_Name = cust.Role.Name
                };
                return Ok(customerDTO);
            }
        }


        [HttpGet]
        [Route("Name/{name}")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetCustomerByName(string name)
        {
            List<Customer> customers = CustRepo.GetByName(name);
            if (customers == null)
            {
                return NotFound();
            }
            else
            {
                List<CustomerDTO> customerDTOs = new List<CustomerDTO>();

                foreach (Customer cust in customers)
                {
                    CustomerDTO customerDTO = new CustomerDTO()
                    {
                        id = cust.Id,
                        name = cust.Name,
                        email = cust.Email,
                        phone = cust.Phone,
                        address = cust.Address,
                        password = cust.Password,
                        store_Name = cust.Store_Name,
                        available = cust.Available,
                        special_Discount_Perc = cust.Special_Discount_Perc,
                        refused_Order_Perc = cust.Refused_Order_Perc,
                        branch = cust.Branch.Name,
                        branch_Id = cust.Branch_Id,
                        role_Name = cust.Role.Name

                    };
                    customerDTOs.Add(customerDTO);
                }

                return Ok(customerDTOs);
            }
        }


        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Customer> Add(AddCustomerDTO CustDTO)
        {
            if (CustDTO == null)
            {
                return BadRequest();
            }
            else
            {
                Customer customer = new Customer()
                {
                    Name = CustDTO.name,
                    Email = CustDTO.email,
                    Password = CustDTO.password,
                    Phone = CustDTO.phone,
                    Address = CustDTO.address,
                    Store_Name = CustDTO.store_Name,
                    Special_Discount_Perc = CustDTO.special_Discount_Perc,
                    Refused_Order_Perc = CustDTO.refused_Order_Perc,
                    Role_Id = CustDTO.role_Id,
                    Available = CustDTO.available,
                    Branch_Id = CustDTO.branch_Id

                };
                if (customer == null)
                {
                    return BadRequest();
                }
                else
                {
                    CustRepo.Add(customer);
                    CustRepo.Save();
                    return Ok(customer);
                }
            }
        }


        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult delete(int id)
        {
            Customer Cust = CustRepo.GetById(id);
            if (Cust == null)
            {
                return NotFound();
            }
            else
            {
                CustRepo.Delete(Cust);
                CustRepo.Save();
                return Ok();
            }
        }


        [HttpPut]
        [Route("edit/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult edit(AddCustomerDTO c, int id)
        {
            Customer cust = CustRepo.GetById(id);
            if (cust == null)
            {
                return NotFound();
            }
            else if (c == null)
            {
                return BadRequest();
            }
            else
            {

                cust.Name = c.name;
                cust.Email = c.email;
                cust.Password = c.password;
                cust.Address = c.address;
                cust.Available = c.available;
                cust.Phone = c.phone;
                cust.Store_Name = c.store_Name;
                cust.Special_Discount_Perc = c.special_Discount_Perc;
                cust.Refused_Order_Perc = c.refused_Order_Perc;
                cust.Role_Id = c.role_Id;
                cust.Branch_Id = c.branch_Id;

                CustRepo.Edit(cust);
                CustRepo.Save();
                return NoContent();
            }
        }


        [HttpPut]
        [Route("softdelete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult softdelete(int id, AddCustomerDTO custDTO)
        {
            Customer customer = CustRepo.GetById(id);
            if (customer == null) return NotFound();
            CustRepo.SoftDelete(customer);
            CustRepo.Save();
            return Ok();
        }
    }
}
