using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using System.Data;
using TestingProject.DTO.Governroate;
using TestingProject.Models;
using TestingProject.Repository.BranchRepo;
using TestingProject.Repository.CityRepo;
using TestingProject.Repository.GovernroateRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernroatesController : ControllerBase
    {

        IGovernroateRepository governRepo;
        IBranchRepository branchRepo;
        ICityRepository cityRepo;
        public GovernroatesController(IGovernroateRepository _governRepo, IBranchRepository _branchRepo, ICityRepository _cityRepo) { 
            this.governRepo = _governRepo;
            this.branchRepo = _branchRepo;
            this.cityRepo = _cityRepo;
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetGovernroates()
        {
            List<Governorate> governorates = governRepo.GetGovernorates();
            if (governorates == null) return NotFound();
            List<GovernroateDTO> governroateDTOs = new List<GovernroateDTO>();
            foreach (var governorate in governorates)
            {
                GovernroateDTO governroateDTO = new GovernroateDTO()
                {
                    id=governorate.Id,
                    name=governorate.Name,
                    branch_Name = governorate.Branch.Name,
                    available= governorate.Branch.Available==false?false: governorate.Available,
                    branch_Id= governorate.Branch_Id
                };
                governroateDTOs.Add(governroateDTO);
            }

            return Ok(governroateDTOs);
        }

        [HttpGet]
        [Route("Available")]
        public ActionResult GetGovernroatesAvailable()
        {
            List<Governorate> governorates = governRepo.GetGovernoratesAvailable();
            if (governorates == null) return NotFound();
            List<GovernroateDTO> governroateDTOs = new List<GovernroateDTO>();
            foreach (var governorate in governorates)
            {
                GovernroateDTO governroateDTO = new GovernroateDTO()
                {
                    id = governorate.Id,
                    name = governorate.Name,
                    branch_Name = governorate.Branch.Name,
                    available = governorate.Branch.Available == false ? false : governorate.Available,
                    branch_Id = governorate.Branch_Id

                };
                governroateDTOs.Add(governroateDTO);
            }

            return Ok(governroateDTOs);
        }

        [HttpGet]
        [Route("Id/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetGovernroateById(int id)
        {
            Governorate governorate = governRepo.GetGovernorateById(id);
            if (governorate == null) return NotFound();
            GovernroateDTO governroateDTO = new GovernroateDTO()
            {
                id=governorate.Id,
                name=governorate.Name,
                branch_Name=governorate.Branch.Name,
                available = governorate.Branch.Available == false ? false : governorate.Available,
                branch_Id = governorate.Branch_Id


            };
            return Ok(governroateDTO);
        }

        [HttpGet]
        [Route("Name/{name}")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetGovernroateByName(string name)
        {
            List<Governorate> governorates = governRepo.GetGovernoratesByName(name);
            if (governorates == null) return NotFound();
            List<GovernroateDTO> governroateDTOs = new List<GovernroateDTO>();
            foreach (var governorate in governorates)
            {
                GovernroateDTO governroateDTO = new GovernroateDTO()
                {
                    id = governorate.Id,
                    name = governorate.Name,
                    branch_Name = governorate.Branch.Name,
                    available = governorate.Branch.Available == false ? false : governorate.Available,
                    branch_Id = governorate.Branch_Id


                };
                governroateDTOs.Add(governroateDTO);
            }

            return Ok(governroateDTOs);
        }

        [HttpGet]
        [Route("branch/{branch_Id}")]
        public ActionResult GetGovernroateByBranch(int branch_Id)
        {
            List<Governorate> governorates = governRepo.GetGovernoratesByBranch(branch_Id);
            if (governorates == null) return NotFound();
            List<GovernroateDTO> governroateDTOs = new List<GovernroateDTO>();
            foreach (var governorate in governorates)
            {
                GovernroateDTO governroateDTO = new GovernroateDTO()
                {
                    id = governorate.Id,
                    name = governorate.Name,
                    branch_Name = governorate.Branch.Name,
                    available = governorate.Branch.Available == false ? false : governorate.Available,
                    branch_Id = governorate.Branch_Id


                };
                governroateDTOs.Add(governroateDTO);
            }

            return Ok(governroateDTOs);
        }

        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddGovernroate(GovernroateAddDTO governroateAddDTO)
        {
            if (governroateAddDTO == null) return BadRequest();
            Governorate governorate = new Governorate()
            {
                Name = governroateAddDTO.name,
                Available = governroateAddDTO.available,
                Branch_Id = governroateAddDTO.branch_Id
            };
            governRepo.Add(governorate);
            governRepo.Save();
            return Ok(governorate);
        }

        [HttpPut]
        [Route("edit/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateGovernroate(GovernroateAddDTO governroateAddDTO, int id) {

            Governorate governorate = governRepo.GetGovernorateById(id);
            if (governorate == null) return NotFound();
            governorate.Name = governroateAddDTO.name;
            governorate.Branch_Id = governroateAddDTO.branch_Id;
            governRepo.Update(governorate);
            governRepo.Save();
            return Ok();
        }

        [HttpPut]
        [Route("softdelete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult SoftDelete(GovernroateAddDTO governroateAddDTO, int id)
        {
            Governorate governorate = governRepo.GetGovernorateById(id);
            if(governorate == null) return BadRequest();
            if (governorate.Branch.Available == true)
            {
            governRepo.SoftDelete(governorate);
            governRepo.Save();
            }
            List<City> cities = cityRepo.GetCitiesByGovernroate(id).ToList();
            foreach(var city in cities)
            {
                if (governorate.Available == false)
                {
                    city.Available = false;
                    cityRepo.Save();
                }
            }

            return Ok();
        }
        
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteGovernroate(int id)
        {
            Governorate governorate = governRepo.GetGovernorateById(id);
            if (governorate == null) { return NotFound(); }
            governRepo.Delete(governorate);
            governRepo.Save();
            return NoContent();
        }
    }
}
