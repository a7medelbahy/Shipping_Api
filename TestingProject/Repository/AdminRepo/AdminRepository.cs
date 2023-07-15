using Microsoft.EntityFrameworkCore;
using TestingProject.Models;

namespace TestingProject.Repository.AdminRepo
{
    public class AdminRepository : IAdminRepositrory
    {
        ShippingContext db;

        public AdminRepository(ShippingContext _db)
        {
            this.db = _db;
        }
        public List<Admin> GetAdmin()
        {
            return db.admins.Include(a=>a.Role).ToList();
        }
    }
}
