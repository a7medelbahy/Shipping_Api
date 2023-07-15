using TestingProject.Models;

namespace TestingProject.Repository.BranchRepo
{
    public interface IBranchRepository
    {
        List<Branch> GetBranches();

        List<Branch> GetBranchesAvailable();

        Branch GetBranchById(int id);

        List<Branch> GetBranchByName(string name);

        void Add(Branch branch);

        void Update(Branch branch);
        void Delete(Branch branch);

        void SoftDelete(Branch branch);

        void Save();

    }
}
