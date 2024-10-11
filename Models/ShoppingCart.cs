using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Bookstore.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        [ForeignKey("Books")]
        public int BookId { get; set; }
        public int Quantity { get; set; }

    }
}
