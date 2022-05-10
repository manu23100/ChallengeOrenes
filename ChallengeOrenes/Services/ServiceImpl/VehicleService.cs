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

        /// <summary>
        /// Add a new vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        public void add(VehicleChildDTO vehicle)
        {
            _vehicleRepository.insert(_mapper.Map<Vehicle>(vehicle));
        }

        /// <summary>
        /// Returns all the vehicles
        /// </summary>
        /// <returns>A list of all vehicles</returns>
        public List<VehicleDTO> getAll()
        {
            return _mapper.Map<List<VehicleDTO>>(_vehicleRepository.getAll());
        }

        /// <summary>
        /// Get a vehicle by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The vehicle with the specified id</returns>
        public VehicleDTO getById(int id)
        {
            return _mapper.Map<VehicleDTO>(_vehicleRepository.GetById(id));
        }

        /// <summary>
        /// Get the current location of a vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Current location,or null if the vehicle doesn't have locations</returns>
        public LocationDTO getCurrentLocation(int id)
        {
            Vehicle v = _vehicleRepository.GetById(id);

            if(v.locations.Count > 0)
                return _mapper.Map<LocationDTO>(v.locations.Last());

            return null;
        }

        /// <summary>
        /// Get all locations of a vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Locations of the vehicle,or null if the vehicle doesn't exist</returns>
        public List<LocationDTO> getLocations(int id)
        {
            Vehicle v = _vehicleRepository.GetById(id);

            if (v == null)
                return null;

            return _mapper.Map<List<LocationDTO>>(v.locations.ToList());
        }
    }
}
