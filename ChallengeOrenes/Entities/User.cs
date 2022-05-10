using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeOrenes.Entities
{
    [Table("USERS")]
    public class User
    {
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("FULL_NAME")]
        public string fullName { get; set; }

        [Required]
        [Column("ADDRESS")]
        public string address { get; set; }

        [Required]
        [Column("EMAIL")]
        public string email { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
