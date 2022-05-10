using ChallengeOrenes.Entities;
using ChallengeOrenes.Data;

namespace ChallengeOrenes.Repositories.RepositoryImpl
{
    public class LocationRepository : ILocationRepositoy
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Location> getAll()
        {
            return _context.locations.ToList();
        }

        public Location getById(int id)
        {
            return _context.locations.Find(id);
        }

        public void insert(Location location)
        {
            _context.locations.Add(location);
            _context.SaveChanges();
        }
    }
}
