using ChallengeOrenes.DTO;

namespace ChallengeOrenes.Services
{
    public interface IVehicleService
    {
        public List<VehicleDTO> getAll();

        public List<LocationDTO> getLocations(int id);

        public LocationDTO getCurrentLocation(int id);

        public void add(VehicleChildDTO vehicle);

        public VehicleDTO getById(int id);
    }
}
