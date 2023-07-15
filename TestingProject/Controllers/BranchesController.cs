using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestingProject.DTO.Branch;
using TestingProject.DTO.Governroate;
using TestingProject.Models;
using TestingProject.Repository.BranchRepo;
using TestingProject.Repository.GovernroateRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BranchesController : ControllerBase
    {
        IBranchRepository branchRepo;
        IGovernroateRepository governRepo;
        public BranchesController(IBranchRepository _branchRepo, IGovernroateRepository _governRepo)
        {
            this.branchRepo = _branchRepo;
            this.governRepo = _governRepo;
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetBranches()
        {
            List<Branch> branches = branchRepo.GetBranches();
            if (branches == null) return NotFound();
            List<BranchDTO> branchDTOs = new List<BranchDTO>();
            foreach (var branch in branches)
            {
                BranchDTO branchDTO = new BranchDTO()
                {
                    id = branch.Id,
                    name = branch.Name,
                    available = branch.Available,
                };
                branchDTOs.Add(branchDTO);
            }

            return Ok(branchDTOs);
        }

        [HttpGet]
        [Route("Available")]
        
        public ActionResult GetBranchesAvailable()
        {
            List<Branch> branches = branchRepo.GetBranchesAvailable();
            if (branches == null) return NotFound();
            List<BranchDTO> branchDTOs = new List<BranchDTO>();
            foreach (var branch in branches)
            {
                BranchDTO branchDTO = new BranchDTO()
                {
                    id = branch.Id,
                    name = branch.Name,
                    available= branch.Available
                };
                branchDTOs.Add(branchDTO);
            }

            return Ok(branchDTOs);
        }

        [HttpGet]
        [Route("Id/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetBranchById(int id)
        {
            Branch branch = branchRepo.GetBranchById(id);
            if (branch == null) return NotFound();
            BranchDTO branchDTO = new BranchDTO()
            {
                id = branch.Id,
                name = branch.Name,
                available= branch.Available
            };
            return Ok(branchDTO);
        }

        [HttpGet]
        [Route("Name/{name}")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetBranchByName(string name)
        {
            List<Branch> branches = branchRepo.GetBranchByName(name);
            if (branches == null) return NotFound();
            List<BranchDTO> branchDTOs = new List<BranchDTO>();
            foreach (var branch in branches)
            {
                BranchDTO branchDTO = new BranchDTO()
                {
                    id = branch.Id,
                    name = branch.Name,
                    available = branch.Available
                };
                branchDTOs.Add(branchDTO);
            }

            return Ok(branchDTOs);
        }


        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Branch> AddBranch(BranchAddDTO branchAddDTO)
        {
            if (branchAddDTO == null) return BadRequest();
            Branch branch = new Branch()
            {
                Id = branchAddDTO.id,
                Name = branchAddDTO.name,
                Available = branchAddDTO.available,
            };
            branchRepo.Add(branch);
            branchRepo.Save();
            return branch;
        }

        [HttpPut]
        [Route("edit/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateBranch(BranchAddDTO branchAddDTO, int id)
        {

            Branch branch = branchRepo.GetBranchById(id);
            if (branch == null) return NotFound();
            branch.Name = branchAddDTO.name;
            branchRepo.Update(branch);
            branchRepo.Save();
            return Ok();
        }

        [HttpPut]
        [Route("softdelete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult SoftDelete(BranchAddDTO branchAddDTO, int id)
        {
            Branch branch = branchRepo.GetBranchById(id);
            if (branch == null) return NotFound();
            branchRepo.SoftDelete(branch);
            branchRepo.Save();
            List<Governorate> governorates = governRepo.GetGovernoratesByBranch(id).ToList();
            foreach (var govern in governorates)
            {
                if(branch.Available == false)
                {
                    govern.Available = false;
                    governRepo.Save();
                }
            }
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteBranch(int id)
        {
            Branch branch = branchRepo.GetBranchById(id);
            if (branch == null) return NotFound();
            branchRepo.Delete(branch);
            branchRepo.Save();
            return NoContent();
        }
    }
}
