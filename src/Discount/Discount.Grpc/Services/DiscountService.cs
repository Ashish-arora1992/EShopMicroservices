using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly DiscountContext _dbContext;

        // Constructor Injection for DiscountContext
        public DiscountService(DiscountContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var result = await _dbContext.Coupons
                .FirstOrDefaultAsync(c => c.ProductName == request.ProductName);

            // If no result found, return default values (this can be customized as needed)
            if (result == null)
            {
                return new CouponModel
                {
                    ProductName = "No Discount",
                    Description = "Discount not found",
                    Amount = 0,
                    Id = 0
                };
            }

            // Return the coupon information if found
            return new CouponModel
            {
                ProductName = result.ProductName,
                Description = result.Description,
                Amount = result.Amount,
                Id = result.Id
            };
        }
   
        //public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        //{
        //    Coupon coupon = new ()
        //    {
        //      ProductName=req
        //    }
        //    var result = await _dbContext.AddRangeAsync(coupon);
        //    return Task.FromResult(new CouponModel());
        //}
    }
}
