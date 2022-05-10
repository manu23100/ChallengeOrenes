using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChallengeOrenes.Entities;
using ChallengeOrenes.DTO;

namespace ChallengeOrenes.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
  
        public string fullName { get; set; }

        public string address { get; set; }

        public string email { get; set; }

        public virtual ICollection<OrderDTO> orders { get; set; }
    }
}
