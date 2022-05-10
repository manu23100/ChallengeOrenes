using ChallengeOrenes.DTO;
using ChallengeOrenes.Services;
using ChallengeOrenes.Repositories;
using AutoMapper;
using ChallengeOrenes.Entities;

namespace ChallengeOrenes.Services.ServiceImpl
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository,IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public void add(VehicleChildDTO vehicle)
        {
            _vehicleRepository.insert(_mapper.Map<Vehicle>(vehicle));
        }

        public List<VehicleDTO> getAll()
        {
            return _mapper.Map<List<VehicleDTO>>(_vehicleRepository.getAll());
        }

        public VehicleDTO getById(int id)
        {
            return _mapper.Map<VehicleDTO>(_vehicleRepository.GetById(id));
        }

        public LocationDTO getCurrentLocation(int id)
        {
            Vehicle v = _vehicleRepository.GetById(id);

            if(v.locations.Count > 0)
                return _mapper.Map<LocationDTO>(v.locations.Last());

            return null;
        }

        public List<LocationDTO> getLocations(int id)
        {
            Vehicle v = _vehicleRepository.GetById(id);

            if (v == null)
                return null;

            return _mapper.Map<List<LocationDTO>>(v.locations.ToList());
        }
    }
}
