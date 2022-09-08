using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Data;
using Flippd.Data.Entities;
using Flippd.Models.PropertyFeatures;
using Microsoft.EntityFrameworkCore;


namespace Flippd.Services.PropertyFeatures
{
    public class PropertyFeaturesService : IPropertyFeaturesService
    {
        private readonly ApplicationDbContext _context;
        public PropertyFeaturesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePropertyFeaturesAsync(PropertyFeaturesCreate model)
        {
            var entity = new PropertyFeaturesEntity
            {
                Bedrooms = model.Bedrooms,
                Baths = model.Baths,
                SquareFootage = model.SquareFootage,
                YearBuilt = model.YearBuilt
            };

            _context.PropertyFeatures.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<PropertyFeaturesDetail> GetPropertyFeaturesByListingIdAsync(int ListingId)
        {
            var entity = await _context.PropertyFeatures.Include(r => r.ListingEntity).FindAsync(entity => entity.Id == ListingId);
            if(entity is null)
                return null;

            var PropertyFeaturesDetail = new PropertyFeaturesDetail
            {
                Id = entity.Id,
                Bedrooms = entity.Bedrooms,
                Baths = entity.Baths,
                GarageSpaces = entity.GarageSpaces,
                SquareFootage = entity.SquareFootage,
                LotSize = entity.LotSize,
                YearBuilt = entity.YearBuilt
            };

            return PropertyFeaturesDetail;

        }
    }
}