

using Basket.Api.Basket.Data;

namespace Basket.Api.Basket.GetBasket
{

    public record GetBasketQuery(string UserName):IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart ShoppingCart);
    public class GetBasketQueryHandler(IBasketRepository Ibasket) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var result = await Ibasket.GetBasket(query.UserName,cancellationToken);
            var response = result.Adapt<ShoppingCart>();
            return new GetBasketResult(response);
        }
    }
    
}
