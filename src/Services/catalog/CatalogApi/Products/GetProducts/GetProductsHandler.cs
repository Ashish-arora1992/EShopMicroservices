using BuildingBlocks.CQRS;
using CatalogApi.Models;

namespace CatalogApi.Products.GetProducts
{
    public record GetProductQuery():IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var response=await session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductsResult(response); 
        }
    }
}
