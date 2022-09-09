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

        public async Task<bool> UpdatePropertyFeaturesAsync(PropertyFeaturesUpdate request)
        {
            // Find the Listing and Validate It's Owned by the user.
            var PropertyFeaturesEntity = await _context.PropertyFeatures.FindAsync(request.Id);

            // By using the null conditional operator we can check if it's null at the same time we check the OwnerId.
            if (PropertyFeatures?.OwnerId != _)

                // Update the entity's properties.
                PropertyFeaturesEntity.Bedrooms = request.Bedrooms;
                PropertyFeaturesEntity.Baths = request.Baths;
                PropertyFeaturesEntity.GarageSpaces = request.



            // Save the changes to the database and capture how many rows were updated.
            var numberOfChanges = await _context.SaveChangesAsync();

            // numberOfChanges is stated to be equal to 1 because only one row is updated.
            return numberOfChanges == 1;
        }
    }
}