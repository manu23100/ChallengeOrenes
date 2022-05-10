using ChallengeOrenes.DTO;
using AutoMapper;
using ChallengeOrenes.Repositories;
using ChallengeOrenes.Entities;

namespace ChallengeOrenes.Services.ServiceImpl
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepositoy _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepositoy locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new location
        /// </summary>
        /// <param name="location"></param>
        public void add(LocationDTO location)
        {
            _locationRepository.insert(_mapper.Map<Location>(location));
        }

        /// <summary>
        /// Get all locations
        /// </summary>
        /// <returns>A list of locations</returns>
        public List<LocationDTO> getAll()
        {
            return _mapper.Map<List<LocationDTO>>(_locationRepository.getAll());
        }

        /// <summary>
        /// Geta a location by an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The location with the specified id</returns>
        public LocationDTO getById(int id)
        {
            return _mapper.Map<LocationDTO>(_locationRepository.getById(id));
        }
    }
}
