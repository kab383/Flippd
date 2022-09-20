using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Data.Entities;

namespace Flippd.Models.Listing
{
    public class ListingUpdate
    {
        
        public int Id { get; set; }
        
        public string StreetAddress { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public int Zip { get; set; }
        
        public decimal Price { get; set; }

        public int PropertyFeaturesId { get; set; }
        public int UserId {get; set; }
    }
}