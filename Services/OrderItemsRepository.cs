using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly BookContext _bookContext;
        private readonly IBookIRepository _bookRepository;
        public OrderItemsRepository(BookContext bookContext, IBookIRepository bookIRepository)
        {
            this._bookContext = bookContext;
            _bookRepository = bookIRepository;

        }
        public void CreateOrderItems(OrderItems orderItems)
        {
            _bookContext.Add(orderItems);
            _bookContext.SaveChanges();
            return;
        }

        public bool DeleteOrderItems(int id)
        {
            var orderItem = GetOrderItemsid(id);
            
            if (orderItem != null || orderItem?.OrderItemId != id) {
                return false;
            }

            _bookContext.orderItems.Remove(orderItem);
            _bookContext.SaveChanges();
            return true;
        }

        public IEnumerable<OrderItems> GetOrderItems()
        {
            return _bookContext.orderItems;
        }

        public OrderItems? GetOrderItemsid(int id)
        {
            return (from _orderItem in _bookContext.orderItems where _orderItem.OrderItemId == id select _orderItem).FirstOrDefault();
        }

        public void UpdateOrderItems(OrderItems orderItems)
        {
            var dbOrderItem = GetOrderItemsid(orderItems.OrderItemId);
            if (dbOrderItem == null)
            {
                throw new NullReferenceException();
            }

            var orderId = dbOrderItem.OrderId;

            var BookId = dbOrderItem.BookId;

            if(_bookRepository.GetBookById(BookId) == null)
            {
                throw new NullReferenceException();
            }

            _bookContext.SaveChanges();

            return;
        }
    }

}
