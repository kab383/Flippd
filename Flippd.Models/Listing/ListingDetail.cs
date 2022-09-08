using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Data.Entities;

namespace Flippd.Models.Listing
{
    public class ListingDetail
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public PropertyType PropType { get; set; }
        public decimal Price { get; set; }
        
    }
}