using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestingProject.DTO.Weight;
using TestingProject.Models;
using TestingProject.Repository.WeightRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class WeightsController : ControllerBase
    {
        IWeightRepository weightRepo;
        public WeightsController(IWeightRepository _weightRepo)
        {
            this.weightRepo = _weightRepo;
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult GetWeight()
        {
            Weight weight = weightRepo.GetWeight();
            WeightDTO weightDTO = new WeightDTO()
            {
                standard_Weight = weight.Standard_Weight,
                extra_Weight_Price = weight.Extra_Weight_Price,
                village_price=weight.Village_price
            };

            return Ok(weightDTO);
        }

        [HttpPut]
        [Route("Edit")]
        [Authorize(Roles = "Admin")]
        public ActionResult EdutWeight(WeightDTO weightDto)
        {
            Weight weight = weightRepo.GetWeight();
            weight.Standard_Weight = weightDto.standard_Weight;
            weight.Extra_Weight_Price=weightDto.extra_Weight_Price;
            weight.Village_price = weightDto.village_price;
            weightRepo.EditWeight(weight);
            weightRepo.Save();
            return Ok(weight);
        }
    }
}
