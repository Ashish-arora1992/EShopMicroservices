
using Microsoft.AspNetCore.Http;

namespace CatalogApi.Products.GetProductByCategory
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Product);

    public class GetProductByCategoryEndPoint : ICarterModule
    {


        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{Category}", async (string Category ,ISender sender) =>
            {
               var result= await sender.Send(new GetProductByCategoryQuery(Category));
                return Results.Ok(result);
            }).WithName("GetProductByCategory").Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK).ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
