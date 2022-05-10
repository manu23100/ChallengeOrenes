using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeOrenes.Entities
{
    [Table("ORDERS")]
    public class Order
    {
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("ORDER_NUMBER")]
        public int orderNumber { get; set; }

        [Required]
        [Column("VEHICLE_ID")]

        public int vehicleId { get; set; }
        public virtual Vehicle vehicle { get; set; }

        [Required]
        [Column("USER_ID")]
        public int userId { get; set; }
        public virtual User user { get; set; }
    }
}
