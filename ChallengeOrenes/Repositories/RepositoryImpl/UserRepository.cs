using ChallengeOrenes.Entities;
using ChallengeOrenes.Services;
using ChallengeOrenes.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOrenes.Repositories.RepositoryImpl
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<User> getAll()
        {
            return _context.users.Include(u => u.orders).ToList();
        }

        public User GetById(int id)
        {
            return _context.users.Include(u => u.orders).Where(u => u.Id == id).FirstOrDefault();
        }

        public void insert(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }
    }
}
