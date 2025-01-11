namespace Basket.Api.Basket.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(String UserName, CancellationToken token = default!);
        Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart, CancellationToken token = default!);
        Task<bool> DeleteBasket(String UserName, CancellationToken token = default!);
    }
}
