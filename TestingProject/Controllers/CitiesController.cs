using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingProject.DTO.City;
using TestingProject.DTO.Governroate;
using TestingProject.Models;
using TestingProject.Repository.CityRepo;
using TestingProject.Repository.GovernroateRepo;

namespace TestingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CitiesController : ControllerBase
    {
        ICityRepository cityRepo;
        IGovernroateRepository goverRepo;
        public CitiesController(ICityRepository _cityRepo, IGovernroateRepository _goverRepo) {
            this.cityRepo = _cityRepo;
            this.goverRepo = _goverRepo;
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetCities()
        {
            List<City> cities = cityRepo.GetCities();
            if (cities == null) return NotFound();
            List<CityDTO> cityDTOs = new List<CityDTO>();
            foreach (var city in cities)
            {
                CityDTO cityDTO = new CityDTO()
                {
                    id = city.Id,
                    name = city.Name,
                    charge_Regular=city.Charge_Regular,
                    charge_24Hour=city.Charge_24Hour,
                    charge_15Days=city.Charge_15Days,
                    charge_89Days=city.Charge_89Days,
                    governorate_Name=city.Governorate.Name,
                    governorate_Id=city.Governorate.Id,
                    branch_Name = city.Governorate.Branch.Name,
                    available = city.Governorate.Available==false?false:city.Available
                };
                cityDTOs.Add(cityDTO);
            }

            return Ok(cityDTOs);
        }

        [HttpGet]
        [Route("Available")]
        public ActionResult GetCitiesAvailable()
        {
            List<City> cities = cityRepo.GetCitiesAvailable();
            if (cities == null) return NotFound();
            List<CityDTO> cityDTOs = new List<CityDTO>();
            foreach (var city in cities)
            {
                CityDTO cityDTO = new CityDTO()
                {
                    id = city.Id,
                    name = city.Name,
                    charge_Regular = city.Charge_Regular,
                    charge_24Hour = city.Charge_24Hour,
                    charge_15Days = city.Charge_15Days,
                    charge_89Days = city.Charge_89Days,
                    governorate_Name = city.Governorate.Name,
                    governorate_Id = city.Governorate.Id,
                    branch_Name = city.Governorate.Branch.Name,
                    available = city.Governorate.Available == false ? false : city.Available
                };
                cityDTOs.Add(cityDTO);
            }

            return Ok(cityDTOs);
        }

        [HttpGet]
        [Route("Id/{id}")]
        public ActionResult GetCityById(int id)
        {
            City city = cityRepo.GetCityById(id);
            if (city == null) return NotFound();
            CityDTO cityDTO = new CityDTO()
            {
                id = city.Id,
                name = city.Name,
                charge_Regular = city.Charge_Regular,
                charge_24Hour = city.Charge_24Hour,
                charge_15Days = city.Charge_15Days,
                charge_89Days = city.Charge_89Days,
                governorate_Name = city.Governorate.Name,
                governorate_Id = city.Governorate.Id,

                branch_Name = city.Governorate.Branch.Name,
                available = city.Governorate.Available == false ? false : city.Available

            };
            return Ok(cityDTO);
        }

        [HttpGet]
        [Route("Name/{name}")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetCityByName(string name)
        {
            List<City> cities = cityRepo.GetCitiesByName(name);
            if (cities == null) return NotFound();
            List<CityDTO> cityDTOs = new List<CityDTO>();
            foreach (var city in cities)
            {
                CityDTO cityDTO = new CityDTO()
                {
                    id = city.Id,
                    name = city.Name,
                    charge_Regular = city.Charge_Regular,
                    charge_24Hour = city.Charge_24Hour,
                    charge_15Days = city.Charge_15Days,
                    charge_89Days = city.Charge_89Days,
                    governorate_Name = city.Governorate.Name,
                    governorate_Id = city.Governorate.Id,

                    branch_Name = city.Governorate.Branch.Name,
                    available = city.Governorate.Available == false ? false : city.Available

                };
                cityDTOs.Add(cityDTO);
            }

            return Ok(cityDTOs);
        }

        [HttpGet]
        [Route("Governroate/{governorate_Id}")]
        public ActionResult GetCityByGovernroate(int governorate_Id)
        {
            List<City> cities = cityRepo.GetCitiesByGovernroate(governorate_Id);
            if (cities == null) return NotFound();
            List<CityDTO> cityDTOs = new List<CityDTO>();
            foreach (var city in cities)
            {
                CityDTO cityDTO = new CityDTO()
                {
                    id = city.Id,
                    name = city.Name,
                    charge_Regular = city.Charge_Regular,
                    charge_24Hour = city.Charge_24Hour,
                    charge_15Days = city.Charge_15Days,
                    charge_89Days = city.Charge_89Days,
                    governorate_Name = city.Governorate.Name,
                    governorate_Id = city.Governorate.Id,

                    available = city.Governorate.Available == false ? false : city.Available

                };
                cityDTOs.Add(cityDTO);
            }

            return Ok(cityDTOs);
        }

        [HttpGet]
        [Route("chargePrice/{id}/{charge_Type}")]
        public ActionResult GetCityChargePrice(int id,string charge_Type)
        {
            return Ok(cityRepo.GetChargePrice(id, charge_Type));
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult AddCity(CityAddDTO cityAddDTO)
        {
            if (cityAddDTO == null) return BadRequest();
            City city = new City()
            {
                Name = cityAddDTO.name,
                Charge_Regular=cityAddDTO.charge_Regular,
                Charge_24Hour=cityAddDTO.charge_24Hour,
                Charge_15Days=cityAddDTO.charge_15Days,
                Charge_89Days=cityAddDTO.charge_89Days,
                Governorate_Id = cityAddDTO.governorate_Id,
                Available = cityAddDTO.available,
            };
            cityRepo.Add(city);
            cityRepo.Save();
            return Ok(city);
        }

        [HttpPut]
        [Route("edit/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateCity(CityAddDTO cityAddDTO, int id)
        {

            City city = cityRepo.GetCityById(id);
            if (city == null) return NotFound();
            city.Name = cityAddDTO.name;
            city.Charge_Regular = cityAddDTO.charge_Regular;
            city.Charge_24Hour = cityAddDTO.charge_24Hour;
            city.Charge_15Days = cityAddDTO.charge_15Days;
            city.Charge_89Days = cityAddDTO.charge_89Days;
            city.Governorate_Id = cityAddDTO.governorate_Id;
            city.Available = cityAddDTO.available;
            cityRepo.Update(city);
            cityRepo.Save();
            return Ok();
        }

        [HttpPut]
        [Route("softdelete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult SoftDelete(CityAddDTO cityAddDTO, int id)
        {
            City city = cityRepo.GetCityById(id);
            if (city == null) return BadRequest();

            if (city.Governorate.Available == true)
            {
                cityRepo.SoftDelete(city);
                cityRepo.Save();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCity(int id)
        {
            City city = cityRepo.GetCityById(id);
            if (city == null) { return NotFound(); }
            cityRepo.Delete(city);
            cityRepo.Save();
            return NoContent();
        }
    }
}
