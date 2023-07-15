using TestingProject.Models;

namespace TestingProject.Repository.GovernroateRepo
{
    public interface IGovernroateRepository
    {
        List<Governorate> GetGovernorates();

        List<Governorate> GetGovernoratesAvailable();
       
        Governorate GetGovernorateById(int id);

        List<Governorate> GetGovernoratesByName(string name);

        List<Governorate> GetGovernoratesByBranch(int branch_Id);

        void Add(Governorate governorate);

        void Update(Governorate governorate);

        void SoftDelete(Governorate governorate);
        void Delete(Governorate governorate);
        void Save();
    }
}
