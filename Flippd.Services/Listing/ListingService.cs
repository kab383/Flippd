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
        private readonly int _listingId;
        private readonly ApplicationDbContext _context;
        public ListingService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterListingAsync(ListingRegister model)
        {
            // if (await GetListingByStreetAddressAsync(model.StreetAddress) != null || await GetListingByCityAsync(model.City) != null)
            // {
            //     return false;
            // }
            var entity = new ListingEntity
            {
                StreetAddress = model.StreetAddress,
                Price = model.Price,
                IsActive = true,
                City = model.City,
                State = model.State,
                Zip = model.Zip,
                PropType = model.PropType,
                PropertyFeaturesId = model.PropertyFeaturesId,
                UserId = model.UserId
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
                PropType = entity.PropType,
                Zip = entity.Zip,
                
            };
            return listingDetail;
        }

        public async Task<List<ListingDetail>> GetAllListingsByCityAsync(string city)
        {
            var entity = _context.Listings
            // .FindAsync(city);
            // if (entity is null)
            // return null;
                .Where(x=> x.City == city)
                .Select(
                    x => 
                    new ListingDetail
                        {
                            Id = x.Id,
                            Price = x.Price,
                            StreetAddress = x.StreetAddress,
                            City = x.City,
                            State = x.State,
                            Zip = x.Zip
                        });
                ;
                
            // var listingDetail = new ListingDetail
            return entity.ToList();
        }

        public async Task<List<ListingDetail>> GetAllListingsByZipCode(int zip)
        {
            var entity = _context.Listings
            // .FindAsync(zip);
            // if(entity is null)
            // return null;
                .Where(x => x.Zip == zip)
                .Select(
                    x => 
                    new ListingDetail
                        {
                            Id = x.Id,
                            Price = x.Price,
                            StreetAddress = x.StreetAddress,
                            City = x.City,
                            State = x.State,
                            PropType = x.PropType,
                            Zip = x.Zip
                        });
            return entity.ToList();
        }

        public async Task<IEnumerable<ListingListItem>> GetAllListingsAsync()
        {
            var listings = await _context.Listings.Select(entity => new ListingListItem
            {
                Id = entity.Id,
                StreetAddress = entity.StreetAddress,
                Price = entity.Price,
                DatePosted = entity.DatePosted,

            })
            .ToListAsync();
            return listings;
            ;
            
        }

        public async Task<bool> UpdateListingAsync(ListingUpdate request)
        {
            var listingEntity = await _context.Listings.FindAsync(request.Id);
            

            
            //listingEntity.IsActive = false;
            listingEntity.StreetAddress = request.StreetAddress;
            listingEntity.City = request.City;
            listingEntity.State = request.State;
            listingEntity.Zip = request.Zip;
            listingEntity.Price = request.Price;
            listingEntity.PropertyFeaturesId = request.PropertyFeaturesId;
            //listingEntity.UserId = request.UserId;

            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteListingAsync(int listingId)
        {
            var listingEntity = await _context.Listings.FindAsync(listingId);
            _context.Listings.Remove(listingEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}