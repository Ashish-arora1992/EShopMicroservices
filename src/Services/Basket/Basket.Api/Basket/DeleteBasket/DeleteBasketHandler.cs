
namespace Basket.Api.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName):ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);
    public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new DeleteBasketResult(true));
;        }
    }
    
}
