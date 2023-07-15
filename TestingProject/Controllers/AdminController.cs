using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingProject.DTO.Admin;
using TestingProject.DTO.City;
using TestingProject.Models;
using TestingProject.Repository.AdminRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminRepositrory adminRepo;
        public AdminController(IAdminRepositrory _adminRepo)
        {
            this.adminRepo = _adminRepo;
        }
        [HttpGet]
        [Route("all")]
        public ActionResult GetAdmin()
        {
            List<Admin> admins = adminRepo.GetAdmin();
            List<AdminDTO> adminDTOs = new List<AdminDTO>();
            foreach (var admin in admins)
            {
                AdminDTO adminDTO = new AdminDTO()
                {
                    id = admin.Id,
                    name = admin.Name,
                    role_Id = admin.Role_Id,
                    role_Name = admin.Role.Name,
                    email = admin.Email,
                    password = admin.Password,
                    phone=admin.Phone
                };
                adminDTOs.Add(adminDTO);
            }

            return Ok(adminDTOs);
        }
    }
}
