
using Basket.Api.Basket.Data;

namespace Basket.Api.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart ShoppingCart):ICommand<StoreBasketResult>;
    public record StoreBasketResult(string  UserName);
    public class StoreBasketCommandHandler(IBasketRepository IBasket) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            var result = await IBasket.StoreBasket(command.ShoppingCart,cancellationToken);
            return new StoreBasketResult(command.ShoppingCart.UserName);
        }
    }
    
    
}
