using ChallengeOrenes.Entities;

namespace ChallengeOrenes.Repositories
{
    public interface IVehicleRepository
    {
        public List<Vehicle> getAll();

        public Vehicle GetById(int id);

        public void insert(Vehicle entity);
    }
}
