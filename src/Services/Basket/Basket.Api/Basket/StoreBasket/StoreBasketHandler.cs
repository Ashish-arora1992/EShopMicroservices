
using Basket.Api.Basket.Data;
using Discount.Grpc;

namespace Basket.Api.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart ShoppingCart):ICommand<StoreBasketResult>;
    public record StoreBasketResult(string  UserName);
    public class StoreBasketCommandHandler(IBasketRepository IBasket,DiscountProtoService.DiscountProtoServiceClient disCountService) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            foreach (var item in command.ShoppingCart.Items)
            {
                var coupon = await disCountService.GetDiscountAsync(new GetDiscountRequest { ProductName=item.ProductName});
                item.Price-=coupon.Coupon.Amount;
            }
            var result = await IBasket.StoreBasket(command.ShoppingCart,cancellationToken);
            return new StoreBasketResult(command.ShoppingCart.UserName);
        }
    }
    
    
}
