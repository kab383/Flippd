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
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        public virtual List<ListingEntity> MyListings { get; set; } = new List<ListingEntity>();
        public DateTime DateCreated { get; set; }
    }
}