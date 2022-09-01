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
    }
}