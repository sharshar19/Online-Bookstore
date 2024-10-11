using Microsoft.AspNetCore.Identity;
using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly BookContext _bookContext;
        private readonly UserManager<User> _userManager;


        public UserRepository(BookContext bookContext, UserManager<User> userManager) 
        {
            this._bookContext = bookContext;
            this._userManager = userManager;
        }

        public void CreateUser(User user)
        {
            var result = _userManager.CreateAsync(user);
            return;
        }

        public async void DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            
            if (user == null || user.Id != Id)
            {
                return;
            }

            var result = _userManager.DeleteAsync(user);
            
            return;
        }

        public async Task<User?> GetUserById(string Id)
        {
            return await _userManager.FindByIdAsync(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _bookContext.Users;
        }

        public async void UpdateUser(User user)
        {
            await _userManager.UpdateAsync(user);
            return;
        }
    }
}
