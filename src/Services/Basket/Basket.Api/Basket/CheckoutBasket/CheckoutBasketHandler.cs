
namespace Basket.Api.Basket.CheckoutBasket
{
    public record CheckOutBasketCommand(BasketCheckoutDto BasketCheckoutDto) :ICommand<CheckOutBasketResult>;
    public record CheckOutBasketResult(bool IsSuccess);


  
    public class CheckoutBasketHandler : ICommandHandler<CheckOutBasketCommand, CheckOutBasketResult>
    {
        public Task<CheckOutBasketResult> Handle(CheckOutBasketCommand command, CancellationToken cancellationToken)
        {
            // get exisitmg basket with total price
            // Set total price with basketCheckout event message
            // send basket checkout event message to rabbitmq using massTransit
            // delete the basket
            var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
            throw new NotImplementedException();
        }
    }

}
