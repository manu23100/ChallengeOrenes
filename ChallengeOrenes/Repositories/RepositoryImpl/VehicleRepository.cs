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

        public List<Vehicle> getAll()
        {
            return _context.vehicles.Include(v => v.orders).Include(v => v.locations).ToList();
        }

        public Vehicle GetById(int id)
        {
            return _context.vehicles.Include(v => v.orders).Include(v => v.locations).Where(v => v.Id == id).FirstOrDefault();
        }

        public void insert(Vehicle entity)
        {
            _context.vehicles.Add(entity);
            _context.SaveChanges();
        }
    }
}
