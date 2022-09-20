using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Flippd.Data.Entities;
using System.Threading.Tasks;

namespace Flippd.Models.User
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual List<ListingEntity> MyListings { get; set; } = new List<ListingEntity>();
    }
}