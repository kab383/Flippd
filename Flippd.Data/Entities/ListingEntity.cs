using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Data.Entities
{
    public class ListingEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Zip { get; set; }
        [Required]
        public PropertyType PropType { get; set; }
        [Required]
        public DateTime DatePosted { get; set; }
        [ForeignKey("PropertyFeatures")]
        public int databasePropertyFeaturesId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
    public enum PropertyType { house, townhome, multi_family, condo }
}