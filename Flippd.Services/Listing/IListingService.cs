using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Models.Listing;

namespace Flippd.Services.Listing
{
    public interface IListingService
    {
        Task<bool> RegisterListingAsync(ListingRegister model);
        Task<ListingDetail> GetListingByIdAsync(int listingId);
        Task<List<ListingDetail>> GetAllListingsByCityAsync(string city);
        Task<List<ListingDetail>> GetAllListingsByZipCode(int zip);
        Task<IEnumerable<ListingListItem>> GetAllListingsAsync();
        Task<bool> UpdateListingAsync(ListingUpdate request);
        Task<bool> DeleteListingAsync(int listingId);

    }
}