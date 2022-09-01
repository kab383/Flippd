using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Models.Listing
{
    public class ListingRegister
    {
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
    public enum PropertyType {house, townhome, multi_family, condo}
}