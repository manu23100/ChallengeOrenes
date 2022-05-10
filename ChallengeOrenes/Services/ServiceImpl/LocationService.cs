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

        public void add(LocationDTO location)
        {
            _locationRepository.insert(_mapper.Map<Location>(location));
        }

        public List<LocationDTO> getAll()
        {
            return _mapper.Map<List<LocationDTO>>(_locationRepository.getAll());
        }

        public LocationDTO getById(int id)
        {
            return _mapper.Map<LocationDTO>(_locationRepository.getById(id));
        }
    }
}
