using Microsoft.EntityFrameworkCore;
using TestingProject.Models;

namespace TestingProject.Repository.BranchRepo
{
    public class BranchRepository : IBranchRepository
    {
        ShippingContext db;
        public BranchRepository(ShippingContext _db)
        {
            db = _db;
        }

        public List<Branch> GetBranches()
        {
            return db.branches.Include(b => b.Governorates).ToList();
        }

        public List<Branch> GetBranchesAvailable()
        {
            return db.branches.Include(b => b.Governorates).Where(x => x.Available == true).ToList();
        }

        public Branch GetBranchById(int id)
        {
            return db.branches.Include(b => b.Governorates).SingleOrDefault(b => b.Id == id);
        }

        public List<Branch> GetBranchByName(string name)
        {
            return db.branches.Include(b => b.Governorates).Where(b => b.Name.Contains(name)).ToList();

        }
        public void Add(Branch branch)
        {
            db.branches.Add(branch);
        }

        public void Update(Branch branch)
        {
            db.Entry(branch).State = EntityState.Modified;
        }
        public void Delete(Branch branch)
       
        {
            db.branches.Remove(branch);
        }

        public void SoftDelete(Branch branch)
        {
            branch.Available = !branch.Available;
        }

        public void Save()
        {
            db.SaveChanges();
        }
        
    }
}
