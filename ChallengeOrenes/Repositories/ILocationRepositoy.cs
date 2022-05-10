using ChallengeOrenes.Entities;

namespace ChallengeOrenes.Repositories
{
    public interface ILocationRepositoy
    {
        public List<Location> getAll();

        public Location getById(int id);
        public void insert(Location location);
    }
}
