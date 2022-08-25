using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flippd.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flippd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ListingEntity> Listings { get; set; }
        public DbSet<PropertyFeaturesEntity> PropertyFeatures { get; set; }
    }
}