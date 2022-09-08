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

        [ForeignKey(nameof(PropFeatures))]
        public int PropertyFeaturesId { get; set; }
        public virtual PropertyFeaturesEntity PropFeatures { get; set; } = new PropertyFeaturesEntity();

        [ForeignKey(nameof(PropertyOwner))]
        public int UserId { get; set; }
        public virtual UserEntity PropertyOwner { get; set; } = new UserEntity();

        // Virtual properties that represent dynamic data types
    }
    public enum PropertyType { house = 1, townhome, multi_family, condo }
}