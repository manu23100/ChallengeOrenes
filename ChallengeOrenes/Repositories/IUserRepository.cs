using ChallengeOrenes.Entities;

namespace ChallengeOrenes.Repositories
{
    public interface IUserRepository
    {
        public List<User> getAll();

        public User GetById(int id);

        public void insert(User user);
    }
}
