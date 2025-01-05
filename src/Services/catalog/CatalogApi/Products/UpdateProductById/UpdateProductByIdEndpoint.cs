
namespace CatalogApi.Products.UpdateProductById
{
    public record UpdateProductByIdRequest(Guid Version,Guid Id,string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record UpdateProductByIdResponse(bool IsSuccess);
    public class UpdateProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductByIdRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductByIdCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateProductByIdResponse>();
                return Results.Ok(response);
            }).WithName("UpdateProductById").Produces<UpdateProductByIdResponse>(StatusCodes.Status200OK).
            ProducesProblem(StatusCodes.Status400BadRequest);
            //ProducesProblem(StatusCodes.Status404NotFound);
            // throw new NotImplementedException();
        }
    }
}
