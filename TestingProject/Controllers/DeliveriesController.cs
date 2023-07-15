using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestingProject.DTO.Delivery;
using TestingProject.Models;
using TestingProject.Repository.DeliveryRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class DeliveriesController : ControllerBase
    {
        IDeliveryRepository deliveryrepo;
        public DeliveriesController(IDeliveryRepository _delivery)
        {
            this.deliveryrepo = _delivery;
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAll()
        {
            List<Delivery> deliveries = deliveryrepo.GetAllDeleveries();
            List<DeliveryDTO> deliveryDTOs = new List<DeliveryDTO>();
            foreach (Delivery delivery in deliveries)
            {
                DeliveryDTO deliveryDTO = new DeliveryDTO()
                {
                    id = delivery.Id,
                    name = delivery.Name,
                    address = delivery.Address,
                    email = delivery.Email,
                    password = delivery.Password,
                    phone = delivery.Phone,
                    branch_Id = delivery.Branch_Id,
                    branch_name = delivery.Branch.Name,
                    available = delivery.Available,
                    companyPercentage = delivery.Company_Perc,
                    role_Name=delivery.Role.Name
                };
                deliveryDTOs.Add(deliveryDTO);
            }
            return Ok(deliveryDTOs);
        }

        [Route("Id/{id}")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult GetById(int id)
        {
            var delivery = deliveryrepo.GetById(id);
            if (delivery == null)
            {
                return NotFound();
            }
            DeliveryDTO deliveryDTOs = new DeliveryDTO()
            {
                id = delivery.Id,
                name = delivery.Name,
                address = delivery.Address,
                email = delivery.Email,
                phone = delivery.Phone,
                password = delivery.Password,
                branch_Id = delivery.Branch_Id,
                branch_name = delivery.Branch.Name,
                available = delivery.Available,
                companyPercentage = delivery.Company_Perc,
                role_Name = delivery.Role.Name
            };
            return Ok(deliveryDTOs);
        }

        [Route("Name/{Name}")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult GetByName(string Name)
        {
            List<Delivery> deliveries = deliveryrepo.GetByName(Name);
            if (deliveries == null)
            {
                return NotFound();
            }
            List<DeliveryDTO> deliveryDTOs = new List<DeliveryDTO>();
            foreach (var item in deliveries)
            {

                DeliveryDTO deliveryDTO = new DeliveryDTO()
                {
                    id = item.Id,
                    name = item.Name,
                    address = item.Address,
                    email = item.Email,
                    phone = item.Phone,
                    available = item.Available,
                    branch_Id = item.Branch_Id,
                    password = item.Password,
                    branch_name = item.Branch.Name,
                    companyPercentage = item.Company_Perc,
                    role_Name = item.Role.Name
                };
                deliveryDTOs.Add(deliveryDTO);
            }
            return Ok(deliveryDTOs);
        }

        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(ADD_DeliveryDTO deliveryDTO)
        {
            if (deliveryDTO == null)
            {
                return BadRequest();
            }

            var delivery = new Delivery
            {
                Name = deliveryDTO.name,
                Email = deliveryDTO.email,
                Password = deliveryDTO.password,
                Phone = deliveryDTO.phone,
                Address = deliveryDTO.address,
                Company_Perc = deliveryDTO.company_Perc,
                Available = deliveryDTO.available,
                Branch_Id = deliveryDTO.branch_Id,
                Role_Id = deliveryDTO.role_Id,
            };

            deliveryrepo.Add(delivery);
            deliveryrepo.save();
            return Ok(delivery);
        }

        [HttpPut]
        [Route("edit/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, ADD_DeliveryDTO deliveryDTO)
        {
            if (deliveryDTO == null)
            {
                return BadRequest();
            }

            var delivery = deliveryrepo.GetById(id);
            if (delivery == null)
            {
                return NotFound();
            }

            delivery.Name = deliveryDTO.name;
            delivery.Address = deliveryDTO.address;
            delivery.Email = deliveryDTO.email;
            delivery.Phone = deliveryDTO.phone;
            delivery.Branch_Id = deliveryDTO.branch_Id;
            delivery.Available = deliveryDTO.available;
            delivery.Company_Perc = deliveryDTO.company_Perc;
            deliveryrepo.Edit(delivery);
            deliveryrepo.save();
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var delivery = deliveryrepo.GetById(id);
            if (delivery == null)
            {
                return NotFound();
            }

            deliveryrepo.Delete(delivery);
            deliveryrepo.save();
            return Ok();
        }


        [HttpGet]
        [Route("Available")]
        public IActionResult GetDeleveriesAvailable()
        {
            List<Delivery> availableDeliveries = deliveryrepo.GetDeleveriesAvailable();
            List<DeliveryDTO> deliveryDTOs = new List<DeliveryDTO>();

            foreach (var delivery in availableDeliveries)
            {
                DeliveryDTO deliveryDTO = new DeliveryDTO()
                {
                    id = delivery.Id,
                    name = delivery.Name,
                    address = delivery.Address,
                    email = delivery.Email,
                    phone = delivery.Phone,
                    available = delivery.Available,
                    branch_name = delivery.Branch.Name,
                    companyPercentage = delivery.Company_Perc,
                    role_Name = delivery.Role.Name
                };
                deliveryDTOs.Add(deliveryDTO);
            }

            return Ok(deliveryDTOs);
        }

        [HttpGet]
        [Route("AvailableBranch/{branch_id}")]
        public IActionResult GetDeliveriesAvailableByBranch(int branch_id)
        {
            List<Delivery> availableDeliveries = deliveryrepo.GetDeliveriesAvailableByBranch(branch_id);
            List<DeliveryDTO> deliveryDTOs = new List<DeliveryDTO>();

            foreach (var delivery in availableDeliveries)
            {
                DeliveryDTO deliveryDTO = new DeliveryDTO()
                {
                    id = delivery.Id,
                    name = delivery.Name,
                    address = delivery.Address,
                    email = delivery.Email,
                    phone = delivery.Phone,
                    available = delivery.Available,
                    branch_name = delivery.Branch.Name,
                    companyPercentage = delivery.Company_Perc,
                    role_Name = delivery.Role.Name
                };
                deliveryDTOs.Add(deliveryDTO);
            }

            return Ok(deliveryDTOs);
        }


        [Route("softdelete/{id}")]
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public ActionResult SoftDelete(ADD_DeliveryDTO deliveryDTO, int id)
        {
            Delivery delivery = deliveryrepo.GetById(id);
            if (delivery == null)
            {
                return NotFound();
            }
            deliveryrepo.SoftDelete(delivery);
            deliveryrepo.save();
            return Ok();
        }
    }
}
