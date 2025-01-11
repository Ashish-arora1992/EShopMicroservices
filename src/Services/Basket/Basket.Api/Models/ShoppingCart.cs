namespace Basket.Api.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; } = new();
        public string UserName { get; set; } = default!;

        public decimal TotalPrice => Items.Sum(c => c.Price * c.Quantity);
        public ShoppingCart(string UserName)
        {
            this.UserName = UserName;
        }
        // for mapping
        public ShoppingCart()
        {

        }

    }
}
