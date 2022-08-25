using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public int[] MyListings { get; set; }
        [Required]
        public string Password { get; set; }
    }
}