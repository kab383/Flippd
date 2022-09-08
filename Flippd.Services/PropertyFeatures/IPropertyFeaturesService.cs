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
        Task<IEnumerable<PropertyFeaturesDetail>> GetPropertyFeaturesByListingIdAsync(int ListingId);
    }
}