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

        public override async Task<GetDiscountResponse> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            // Fetch the coupons from the database
            var result = await _dbContext.Coupons
                .Where(c => c.ProductName == request.ProductName).AsNoTracking()
                .FirstOrDefaultAsync();

            // Prepare the response object
            var response = new GetDiscountResponse();

            // foreach (var coupon in result)
            // {
            // Map each coupon to the Coupon message and add it to the response
            //response.Coupons.Add(new Coupon
            //{
            //    Id = coupon.Id,
            //    ProductName = coupon.ProductName,
            //    Description = coupon.Description,
            //    Amount = coupon.Amount
            //});
            //  }

            // Return the response with multiple coupons
            response.Coupon = new Coupon
            {
                Id = result.Id,
                ProductName=result.ProductName,
                Description=result.Description,
                Amount=result.Amount
            };
            return response;
        }

        // Example method for creating a new discount
        public override async Task<Coupon> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            if (request == null || request.Coupon == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument,"invalid request"));
            }

            // Create a new coupon from the request
            var coupon = new Coupon
            {
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };

            // Add the new coupon to the database
            _dbContext.Coupons.Add(coupon);
            await _dbContext.SaveChangesAsync();

            // Return the created coupon (with ID assigned by the DB)
            return coupon;
        }
    }
}
