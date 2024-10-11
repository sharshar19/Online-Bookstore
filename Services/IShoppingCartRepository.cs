using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public interface IShoppingCartRepository
    {
        public void CreateShoppingCart(ShoppingCart shoppingCart);
        public IEnumerable<ShoppingCart> GetShoppingCart();
        public ShoppingCart? GetShoppingCartById(int id);
        public void UpdateShoppingcart(ShoppingCart shoppingCart);
        public bool DeleteShoppingCart(int id);
    }
}