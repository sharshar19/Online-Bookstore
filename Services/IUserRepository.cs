using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public interface IUserRepository
    {
        public void CreateUser(User user);
        public IEnumerable<User> GetUsers();
        public Task<User?> GetUserById(string Id);
        public void UpdateUser(User user);
        public void DeleteUser(string Id);

    }
}
