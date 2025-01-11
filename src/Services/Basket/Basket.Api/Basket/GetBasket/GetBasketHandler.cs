

namespace Basket.Api.Basket.GetBasket
{

    public record GetBasketQuery(string UserName):IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart ShoppingCart);
    public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var result = await Task.Run(() =>
            {
             
                return new GetBasketResult(new ShoppingCart("Ashish"));
            });

            return result;
        }
    }
    
}
