
namespace Basket.Api.Basket.DeleteBasket
{
    public record DeleteBasketRequest(string UserName);
    public record DeleteBasketResponse(bool IsSuccess);
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{UserName}", async (string UserName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(UserName));

                return Results.Ok(result.Adapt<DeleteBasketResponse>());
            }).WithName("DeleteBasket").Produces<DeleteBasketResponse>(StatusCodes.Status200OK).
            ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }

}
