using ChallengeOrenes.DTO;

namespace ChallengeOrenes.Services
{
    public interface IUserService
    {
        public List<UserDTO> getAll();
        public UserDTO getById(int id);
        public void add(UserChildDTO user);
    }
}
