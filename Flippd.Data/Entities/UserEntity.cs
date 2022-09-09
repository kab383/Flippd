using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }

        
        public string? PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual List<ListingEntity> MyListings { get; set; } = new List<ListingEntity>();
        public DateTime DateCreated { get; set; }
    }
}