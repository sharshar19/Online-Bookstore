using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Online_Bookstore.Models
{
    public class BookContext : IdentityDbContext<User>
    {
        public BookContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<OrderItems> orderItems {  get; set; }
        public DbSet<Reviews> reviews { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
    }
}
