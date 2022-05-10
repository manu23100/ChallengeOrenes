using ChallengeOrenes.DTO;
using ChallengeOrenes.Services;
using AutoMapper;
using ChallengeOrenes.Repositories;
using ChallengeOrenes.Entities;

namespace ChallengeOrenes.Services.ServiceImpl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="user"></param>
        public void add(UserChildDTO user)
        {
            _userRepository.insert(_mapper.Map<User>(user));   
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>A list of users</returns>
        public List<UserDTO> getAll()
        {
            return _mapper.Map<List<UserDTO>>(_userRepository.getAll());
        }

        /// <summary>
        /// Get a user by an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User with the specified id</returns>
        public UserDTO getById(int id)
        {
            return _mapper.Map<UserDTO>(_userRepository.GetById(id));   
        }
    }
}