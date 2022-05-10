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

        /// <summary>
        /// Get all user from the db,including the orders of each user
        /// </summary>
        /// <returns>A list of users</returns>
        public List<User> getAll()
        {
            return _context.users.Include(u => u.orders).ToList();
        }

        /// <summary>
        /// Get an user with an id, including the orders of that user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The user with the specified id</returns>
        public User GetById(int id)
        {
            return _context.users.Include(u => u.orders).Where(u => u.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Insert a new user to the db
        /// </summary>
        /// <param name="user"></param>
        public void insert(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }
    }
}
