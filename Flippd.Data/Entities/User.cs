using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public int[] MyListings { get; set; }
        public string Password { get; set; }
    }
}