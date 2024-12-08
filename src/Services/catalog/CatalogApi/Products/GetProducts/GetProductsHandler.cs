using BuildingBlocks.CQRS;
using CatalogApi.Models;

namespace CatalogApi.Products.GetProducts
{
    public record GetProductCommand():IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Product);

    internal class GetProductsHandler : IQueryHandler<GetProductCommand, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var products = new List<Product>()
            {
                new (){ Name="Telivision"},
                new(){Name="Washing Machine"}
            };
            return new GetProductsResult(products); 
        }
    }
}
