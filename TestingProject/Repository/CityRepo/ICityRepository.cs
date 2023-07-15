using TestingProject.Models;

namespace TestingProject.Repository.CityRepo
{
    public interface ICityRepository
    {
        List<City> GetCities();

        List<City> GetCitiesAvailable();

        City GetCityById(int id);

        List<City> GetCitiesByName(string name);

        List<City> GetCitiesByGovernroate(int branch_Id);

        double GetChargePrice(int id, string charge_type);

        void Add(City City);

        void Update(City City);

        void SoftDelete(City city);
        void Delete(City City);
        void Save();
    }
}
