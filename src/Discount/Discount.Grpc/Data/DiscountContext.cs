using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Generate and seed 10,000 records with Id=1

            var coupons = new List<Coupon>();
            for (int i = 1; i <= 10000; i++)
            {
                coupons.Add(new Coupon
                {
                    Id = i+10,  // All records have Id = 1
                    ProductName = "IphoneX",
                    Description = $"Description for Product {i}",
                    Amount = i * 10  // Different amounts for each coupon
                });
            }

            // Use HasData to seed the coupons
            modelBuilder.Entity<Coupon>().HasData(coupons);
        }
    }
}
