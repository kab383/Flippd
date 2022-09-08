using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Data.Entities;

namespace Flippd.Models.Listing
{
    public class ListingRegister
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Zip { get; set; }
        public PropertyType PropType { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}