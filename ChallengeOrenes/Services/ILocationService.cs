using ChallengeOrenes.DTO;

namespace ChallengeOrenes.Services
{
    public interface ILocationService
    {
        public List<LocationDTO> getAll();

        public LocationDTO getById(int id);

        public void add(LocationDTO location);
        
    }
}
