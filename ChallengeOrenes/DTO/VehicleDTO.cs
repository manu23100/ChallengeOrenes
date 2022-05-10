using ChallengeOrenes.DTO;

namespace ChallengeOrenes.DTO
{
    public class VehicleDTO
    {
        public int Id { get; set; }

        public string licensePlate { get; set; }

        public virtual ICollection<OrderDTO> orders { get; set; }
        public virtual ICollection<LocationDTO> locations { get; set; }
    }
}