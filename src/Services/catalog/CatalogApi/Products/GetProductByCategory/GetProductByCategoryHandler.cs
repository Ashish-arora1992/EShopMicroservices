using Marten.Linq.QueryHandlers;

namespace CatalogApi.Products.GetProductByCategory
{

    public record GetProductByCategoryQuery(string Category):IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Product);


    public class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {

              var result= await session.Query<Product>().Where(c=>c.Category.Contains(query.Category)).ToListAsync(cancellationToken);
             
              return  new GetProductByCategoryResult(result);
        }
    }
   
}
