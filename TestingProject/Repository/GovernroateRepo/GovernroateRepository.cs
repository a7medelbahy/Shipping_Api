using Microsoft.EntityFrameworkCore;
using TestingProject.Models;

namespace TestingProject.Repository.GovernroateRepo
{
    public class GovernroateRepository : IGovernroateRepository
    {
        ShippingContext db;
        public GovernroateRepository(ShippingContext _db) {
            this.db = _db;
        }

        public List<Governorate> GetGovernorates()
        {
            List<Governorate> governorates = db.governorates.Include(g=>g.Branch).ToList();
            return governorates;
        }
        
        public List<Governorate> GetGovernoratesAvailable()
        {
            List<Governorate> governorates = db.governorates.Include(g => g.Branch).Where(g=>g.Available == true).ToList();
            return governorates;
        }
       
        public Governorate GetGovernorateById(int id)
        {
            Governorate governorate = db.governorates.Include(g=>g.Branch).SingleOrDefault(g => g.Id == id);
            return governorate;
        }
        
        public List<Governorate> GetGovernoratesByName(string name)
        {
            List<Governorate> governorates = db.governorates.Include(g => g.Branch).Where(g => g.Name.Contains(name)).ToList();
            return governorates;
        }
       
        public List<Governorate> GetGovernoratesByBranch(int branch_Id)
        {
            List<Governorate> governorates = db.governorates.Include(g => g.Branch).Where(g => g.Branch_Id == branch_Id && g.Available==true).ToList();
            return governorates;
        }
        
        public void Add(Governorate governorate)
        {
            db.Add(governorate);
        }

        public void Update(Governorate governorate)
        {
            db.Entry(governorate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
       
        public void SoftDelete(Governorate governorate)
        {
            governorate.Available = !governorate.Available;
        }
       
        public void Delete(Governorate governorate)
        {
            db.governorates.Remove(governorate);
        }

        public void Save()
        {
            db.SaveChanges();
        }


    }
}
