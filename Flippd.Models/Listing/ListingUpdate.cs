using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Models.Listing
{
    public class ListingUpdate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(2,ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(200, ErrorMessage = "{0} must contain no more than {1} characters" )]
        public string StreetAddress { get; set; }
        [Required]
        [MinLength(2,ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(200, ErrorMessage = "{0} must contain no more than {1} characters" )]
        public string City { get; set; }
        [Required]
        [MinLength(2,ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(200, ErrorMessage = "{0} must contain no more than {1} characters" )]
        public string State { get; set; }
        [Required]
        public int Zip { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}