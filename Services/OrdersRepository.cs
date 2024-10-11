using Microsoft.AspNetCore.Identity;
using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public class OrdersRepository(BookContext bookContext, UserManager<User> userManager) : IOrdersRepository
    {
        private readonly BookContext _bookContext = bookContext;
        private readonly UserManager<User> _userManager = userManager;

        public void CreateOrders(Orders orders)
        {
            _bookContext.Add(orders);
            _bookContext.SaveChanges();
            return;
        }

        public bool DeleteOrders(int id)
        {
            var order = GetOrdersById(id);

            if (order == null || order.OrderId != id)
            {
                return false;
            }

            _bookContext.orders.Remove(order);
            _bookContext.SaveChanges();
            return true;
        }

        public IEnumerable<Orders> GetOrders()
        {
            return _bookContext.orders;
        }

        public Orders? GetOrdersById(int id)
        {
            return (from _orders in _bookContext.orders where _orders.OrderId == id select _orders).FirstOrDefault();
        }

        public async void UpdateOrders(Orders orders)
        {
            var dbOrders = GetOrdersById(orders.OrderId) ?? throw new NullReferenceException();

            var UserId = dbOrders.UserId;

            if (UserId == null || await _userManager.FindByIdAsync(UserId) == null)
            {
                throw new NullReferenceException();
            }

            _bookContext.SaveChanges();

            return;
        }
    }
}
