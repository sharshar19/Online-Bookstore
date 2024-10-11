using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly BookContext _bookContext;
        private readonly IBookIRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        public OrdersRepository(BookContext bookContext, IBookIRepository bookIRepository, IUserRepository userRepository)
        {
            this._bookContext = bookContext;
            _bookRepository = bookIRepository;
            _userRepository = userRepository;

        }
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

        public void UpdateOrders(Orders orders)
        {
            var dbOrders = GetOrdersById(orders.OrderId);
            if (dbOrders == null)
            {
                throw new NullReferenceException();
            }

            var orderId = dbOrders.OrderId;

            var UserId = dbOrders.UserId;

            if (UserId == null || _userRepository.GetUserById(UserId) == null)
            {
                throw new NullReferenceException();
            }

            _bookContext.SaveChanges();

            return;
        }
    }
}
