using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Models.PropertyFeatures
{
    public class PropertyFeaturesCreate
    {
        [Required]
        public int Bedrooms { get; set; }

        [Required]
        public decimal Baths { get; set; }

        [Required]
        public int SquareFootage { get; set; }

        [Required]
        public int YearBuilt { get; set; }

        public int LotSize { get; set; }
        
        public int GarageSpaces { get; set; }
    }
}