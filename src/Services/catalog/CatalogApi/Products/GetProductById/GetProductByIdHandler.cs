
namespace CatalogApi.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id):IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    public class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            //Product p = new() { Id = request.Id };
            var product = await session.LoadAsync<Product>(query.Id,cancellationToken);
            if (product is null)
                throw new Exception("Product not found");
            return new GetProductByIdResult(product);

        }
    }
}
