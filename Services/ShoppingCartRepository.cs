using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{

    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly BookContext _bookContext;
        private readonly IBookIRepository _bookRepository;
        public ShoppingCartRepository(BookContext bookContext, IBookIRepository bookIRepository)
        {
            this._bookContext = bookContext;
            _bookRepository = bookIRepository;

        }
        public void CreateShoppingCart(ShoppingCart shoppingCart)
        {
            _bookContext.Add(shoppingCart);
            _bookContext.SaveChanges();
            return;
        }

        public bool DeleteShoppingCart(int id)
        {
            var shoppingCart = GetShoppingCartById(id);

            if (shoppingCart == null || shoppingCart.CartId != id)
            {
                return false;
            }

            _bookContext.shoppingCarts.Remove(shoppingCart);
            _bookContext.SaveChanges();
            return true;
        }

        public IEnumerable<ShoppingCart> GetShoppingCart()
        {
            return _bookContext.shoppingCarts;
        }

        public ShoppingCart? GetShoppingCartById(int id)
        {
            return (from _shopingCart in _bookContext.shoppingCarts where _shopingCart.CartId == id select _shopingCart).FirstOrDefault();
        }

        public void UpdateShoppingcart(ShoppingCart shoppingCart)
        {
            var dbShoppingCart = GetShoppingCartById(shoppingCart.CartId);
            if (dbShoppingCart == null)
            {
                throw new NullReferenceException();
            }

            var orderId = dbShoppingCart.CartId;

            var BookId = dbShoppingCart.BookId;

            if (_bookRepository.GetBookById(BookId) == null)
            {
                throw new NullReferenceException();
            }

            _bookContext.SaveChanges();

            return;
        }
    }
}
