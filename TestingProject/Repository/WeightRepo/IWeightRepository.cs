using TestingProject.Models;

namespace TestingProject.Repository.WeightRepo
{
    public interface IWeightRepository
    {
        Weight GetWeight();

        void EditWeight(Weight weight);

        void Save();
    }
}
