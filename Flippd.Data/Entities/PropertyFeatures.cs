using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Data.Entities
{
    public class PropertyFeatures
    {
        public int Id { get; set; }
        public int Bedrooms { get; set; }
        public decimal Baths { get; set; }
        public int GarageSpaces { get; set; }
        public int SquareFootage { get; set; }
        public int LotSize { get; set; }
        public int YearBuilt { get; set; }
    }
}