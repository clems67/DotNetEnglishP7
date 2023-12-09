using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Dot.Net.WebApi.Domain;
using WebApi.Models;

namespace Dot.Net.WebApi.Data
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserModel>()
                .HasIndex(u => u.userName)
                .IsUnique();
        }

        public LocalDbContext() : base() { }
        public DbSet<BidModel> Bid { get; set; }
        public DbSet<CurvePointModel> CurvePoint { get; set; }
        public DbSet<RatingModel> Rating { get; set; }
        public DbSet<RuleModel> Rule { get; set; }
        public DbSet<TradeModel> Trade { get; set; }
        public DbSet<UserModel> Users { get; set;}
    }
}