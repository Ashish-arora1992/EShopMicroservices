
namespace Basket.Api.Basket.CheckoutBasket
{
    public record CheckoutProductRequest(ShoppingCart shoppingCart);
    public record CheckoutProductResponse(bool IsSuccess);
    public class CheckoutBasketEndPoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/checkoutBasket", async (CheckoutProductRequest shoppingCart, ISender sender) =>
            {
                //var result = await sender.Send();

            }).WithName("checkoutBasket").Produces<CheckoutProductResponse>(StatusCodes.Status200OK).
            ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
