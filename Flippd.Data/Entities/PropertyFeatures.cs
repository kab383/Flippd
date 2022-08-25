using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Data.Entities
{
    public class PropertyFeatures
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public decimal Baths { get; set; }
        public int GarageSpaces { get; set; }
        [Required]
        public int SquareFootage { get; set; }
        public int LotSize { get; set; }
        [Required]
        public int YearBuilt { get; set; }
    }
}