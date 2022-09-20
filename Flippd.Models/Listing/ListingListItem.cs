using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flippd.Models.Listing
{
    public class ListingListItem
    {
        public int Id { get; set; }
        public DateTime DatePosted { get; set; }
        public string StreetAddress { get; set; }
        public decimal Price { get; set; }
    }
}