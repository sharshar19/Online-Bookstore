using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public interface IOrderItemsRepository
    {
        public void CreateOrderItems(OrderItems orderItems);
        public IEnumerable<OrderItems> GetOrderItems();
        public OrderItems? GetOrderItemsid(int id);
        public void UpdateOrderItems(OrderItems orderItems);
        public bool DeleteOrderItems(int id);
    }
}
