


namespace Basket.Api.Basket.CheckoutBasket
{
    public record CheckoutBasketsRequest(BasketCheckoutDto BasketCheckoutDto);
    public record CheckoutBasketResponse(bool IsSuccess);
    public class CheckoutBasketEndPoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/checkout", async (CheckoutBasketsRequest request, ISender sender) =>
            {
                var command = request.Adapt<CheckOutBasketCommand>();
                var result=await sender.Send(command);
                var response=result.Adapt<CheckoutBasketResponse>();
                return Results.Ok(response);
                //var result = await sender.Send();

            }).WithName("checkoutBasket").Produces<CheckoutBasketResponse>(StatusCodes.Status200OK).
            ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
