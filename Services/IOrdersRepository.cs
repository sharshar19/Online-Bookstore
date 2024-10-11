using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public interface IOrdersRepository
    {
        public void CreateOrders(Orders orders );
        public IEnumerable<Orders> GetOrders();
        public Orders? GetOrdersById(int id);
        public void UpdateOrders(Orders orders);
        public bool DeleteOrders(int id);
    }
}
