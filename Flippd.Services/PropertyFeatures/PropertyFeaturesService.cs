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

        public async Task<PropertyFeaturesDetail> GetPropertyFeaturesByListingIdAsync(int PropertyFeaturesId)
        {
            var entity = await _context.PropertyFeatures.Include(r => r.ListingEntity).FirstOrDefaultAsync(e => e.Id == PropertyFeaturesId);
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

        public async Task<bool> UpdatePropertyFeaturesAsync(PropertyFeaturesUpdate request)
        {
            var propertyFeaturesEntity = await _context.PropertyFeatures.FindAsync(request.Id);


            if (propertyFeaturesEntity?.Id != request.Id)
                return false;
            // Update the entity's properties.
            propertyFeaturesEntity.Bedrooms = request.Bedrooms;
            propertyFeaturesEntity.Baths = request.Baths;
            propertyFeaturesEntity.GarageSpaces = request.GarageSpaces;
            propertyFeaturesEntity.SquareFootage = request.SquareFootage;
            propertyFeaturesEntity.LotSize = request.LotSize;
            propertyFeaturesEntity.YearBuilt = request.YearBuilt;

            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

    }
}