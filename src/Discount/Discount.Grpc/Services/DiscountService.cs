using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService:DiscountProtoService.DiscountProtoServiceBase
    {
        public override Task<CoupanModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            return base.GetDiscount(request, context);
        }

    }
}
