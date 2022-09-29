using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Data.Entities;
using Flippd.Models.PropertyFeatures;

namespace Flippd.Services.PropertyFeatures
{
    public interface IPropertyFeaturesService
    {
        Task<bool> CreatePropertyFeaturesAsync(PropertyFeaturesCreate model);

        // Task<ListingEntity> GetPropertyFeaturesByListingId(int PropertyFeaturesId);
        Task<PropertyFeaturesDetail>
        GetPropertyFeaturesByListingIdAsync(int propFeaturesId);
        Task<PropertyFeaturesDetail> GetPropertyFeaturesByPropertyFeaturesIdAsync(int propertyFeaturesId);
        Task<bool> UpdatePropertyFeaturesAsync(PropertyFeaturesUpdate request);
        Task<bool> DeletePropertyFeaturesAsync(int propertyFeaturesId);
    }
}