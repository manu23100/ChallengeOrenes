using ChallengeOrenes.Entities;
using ChallengeOrenes.Repositories;
using ChallengeOrenes.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOrenes.Repositories.RepositoryImpl
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all the vehicles from the db. Including the orders and locations of each vehicle.
        /// </summary>
        /// <returns>A list of vehicles</returns>
        public List<Vehicle> getAll()
        {
            return _context.vehicles.Include(v => v.orders).Include(v => v.locations).ToList();
        }

        /// <summary>
        /// Get a vehicle with an id. Including the orders and locations of that vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The vehicle with that id</returns>
        public Vehicle GetById(int id)
        {
            return _context.vehicles.Include(v => v.orders).Include(v => v.locations).Where(v => v.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Insert a new vehicle to the db
        /// </summary>
        /// <param name="entity"></param>
        public void insert(Vehicle entity)
        {
            _context.vehicles.Add(entity);
            _context.SaveChanges();
        }
    }
}
