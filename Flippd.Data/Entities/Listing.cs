using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Data.Entities
{
    public class Listing
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public DateTime DatePosted { get; set; }
        public int PropertyFeaturesId { get; set; }
        public int UserId { get; set; }
        public int MyListingsId { get; set; }
    }
    public enum PropertyType { house, townhome, multi_family, condo }
    
}