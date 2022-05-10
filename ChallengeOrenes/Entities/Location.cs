using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeOrenes.Entities
{
    [Table("LOCATIONS")]
    public class Location
    {
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("COORD_X")]
        public int coordX { get; set; }

        [Required]
        [Column("COORD_Y")]
        public int coordY { get; set; }

        [Required]
        [Column("VEHICLE_ID")]
        public int vehicleId { get; set; }

        public virtual Vehicle vehicle { get; set; }
    }
}
