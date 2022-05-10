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

        /// <summary>
        /// Get all locations from the db
        /// </summary>
        /// <returns>A list of locations</returns>
        public List<Location> getAll()
        {
            return _context.locations.ToList();
        }

        /// <summary>
        /// Get a location from the db with an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Location with the specified id</returns>
        public Location getById(int id)
        {
            return _context.locations.Find(id);
        }

        /// <summary>
        /// Insert a new location in the db
        /// </summary>
        /// <param name="location"></param>
        public void insert(Location location)
        {
            _context.locations.Add(location);
            _context.SaveChanges();
        }
    }
}
