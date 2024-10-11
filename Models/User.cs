using Microsoft.AspNetCore.Identity;

namespace Online_Bookstore.Models
{
    public class User: IdentityUser
    {

        public virtual List<Orders>? Orders { get; set; }
        public virtual List<Reviews>? Reviews { get; set; }
        public virtual List<ShoppingCart>? ShoppingCarts { get; set; }
    }
}
