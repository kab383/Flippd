using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Models.Listing;
using Flippd.Data.Entities;
using Flippd.Data;
using Microsoft.EntityFrameworkCore;

namespace Flippd.Services.Listing
{
    public class ListingService : IListingService
    {
        private readonly ApplicationDbContext _context;
        public ListingService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterListingAsync(ListingRegister model)
        {
            if (await GetListingByStreetAddressAsync(model.StreetAddress) != null || await GetListingByCityAsync(model.City) != null)
            {
                return false;
            }
            var entity = new ListingEntity
            {
                StreetAddress = model.StreetAddress,
                City = model.City,
                State = model.State,
                Zip = model.Zip,
                Price = model.Price
            };

            _context.Listings.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        private async Task<ListingEntity> GetListingByStreetAddressAsync(string streetaddress)
        {
            return await _context.Listings.FirstOrDefaultAsync(Listing => Listing.StreetAddress.ToLower() == streetaddress.ToLower());
        }

        private async Task<ListingEntity> GetListingByCityAsync(string city)
        {
            return await _context.Listings.FirstOrDefaultAsync(Listing => Listing.City.ToLower() == city.ToLower());
        }

        public async Task<ListingDetail> GetListingByIdAsync(int listingId)
        {
            var entity = await _context.Listings.FindAsync(listingId);
            if (entity is null)
            return null;

            var listingDetail = new ListingDetail
            {
                Id = entity.Id,
                Price = entity.Price,
                StreetAddress = entity.StreetAddress,
                City = entity.City,
                State = entity.State,
                //PropType = entity.PropType,
                Zip = entity.Zip,
                
            };
            return listingDetail;
        }
    }
}