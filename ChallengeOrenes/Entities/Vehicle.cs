using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeOrenes.Entities
{
    [Table("VEHICLES")]
    public class Vehicle
    {
        [Column("ID")]
        public int Id { get; set; } 

        [Required]
        [Column("LICENSE")]
        public string licensePlate { get; set; }
        public virtual ICollection<Order> orders { get; set; } 
        public virtual ICollection<Location> locations { get; set; }
    }
}
