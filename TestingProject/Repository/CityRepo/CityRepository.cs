using Microsoft.EntityFrameworkCore;
using TestingProject.Models;

namespace TestingProject.Repository.CityRepo
{
    public class CityRepository : ICityRepository
    {
        ShippingContext db;
        public CityRepository(ShippingContext _db) { 
            this.db = _db;
        }

        public List<City> GetCities()
        {
            List<City> cities = db.cities.Include(c => c.Governorate).ThenInclude(c=>c.Branch).ToList();
            return cities;
        }

        public List<City> GetCitiesAvailable()
        {
            List<City> cities = db.cities.Include(c => c.Governorate).ThenInclude(c => c.Branch).Where(c => c.Available == true).ToList();
            return cities;
        }
        
        public City GetCityById(int id)
        {
            City city = db.cities.Include(c => c.Governorate).ThenInclude(c => c.Branch).SingleOrDefault(c => c.Id == id);
            return city;
        }

        public List<City> GetCitiesByName(string name)
        {
            List<City> cities = db.cities.Include(c => c.Governorate).ThenInclude(c => c.Branch).Where(c => c.Name.Contains(name)).ToList();
            return cities;
        }

        public List<City> GetCitiesByGovernroate(int governorate_Id)
        {
            List<City> cities = db.cities.Include(c => c.Governorate).Where(c => c.Governorate_Id == governorate_Id && c.Available == true).ToList();
            return cities;
        }

        public double GetChargePrice(int id, string charge_Type) {
            switch (charge_Type)
            {
                case "charge_Regular":
                    return db.cities.SingleOrDefault(c => c.Id == id).Charge_Regular;
                    break;

                case "Charge_24Hour":
                    return db.cities.SingleOrDefault(c => c.Id == id).Charge_24Hour;
                    break;

                case "charge_15Days":
                    return db.cities.SingleOrDefault(c => c.Id == id).Charge_15Days;
                    break;

                case "charge_89Days":
                    return db.cities.SingleOrDefault(c => c.Id == id).Charge_89Days;
                    break;

                default:return 0;

            }
        }
        
        public void Add(City City)
        {
            db.cities.Add(City);
        }

        public void Update(City City)
        {
            db.Entry(City).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(City City)
        {
            db.cities.Remove(City);
        }
        
        public void SoftDelete(City city)
        {
            city.Available = !city.Available;
        }

        public void Save()
        {
            db.SaveChanges();
        }


    }
}
