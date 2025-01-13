


namespace Basket.Api.Basket.Data
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string UserName, CancellationToken token = default)
        {
            session.Delete<ShoppingCart>(UserName);
            await session.SaveChangesAsync(token);
            return true;
        }

        public async Task<ShoppingCart> GetBasket(string UserName, CancellationToken token = default)
        {
            var result = await session.LoadAsync<ShoppingCart>(UserName, token);
            if (result is null)
                throw new Exception("Basket Not Found");

            return result;

        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart, CancellationToken token = default)
        {
            session.Store(shoppingCart);
            await session.SaveChangesAsync(token);
            return shoppingCart;
        }
    }
}
