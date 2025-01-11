
namespace Basket.Api.Basket.StoreBasket
{

    public record StoreBasketRequest(ShoppingCart ShoppingCart);
    public record StoreBasketResponse(string UserName);
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPost("/basket", async (StoreBasketRequest request,ISender sender) =>
            {
                var command=request.Adapt<StoreBasketCommand>();
                var result = await sender.Send(command);
                return Results.Created($"/basket/{result.UserName}",result);
            }).WithName("StoreBasket").Produces<StoreBasketResponse>(StatusCodes.Status200OK).
            ProducesProblem(StatusCodes.Status400BadRequest);
           
        }
    }
}
