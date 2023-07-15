using TestingProject.Models;

namespace TestingProject.Repository.WeightRepo
{
    public class WeightRepository:IWeightRepository
    {
        ShippingContext db;
        public WeightRepository(ShippingContext _db) { 
            this.db = _db;
        }

        public Weight GetWeight()
        {
            return db.weights.SingleOrDefault();
        }

        public void EditWeight(Weight weight)
        {
            db.Entry(weight).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
