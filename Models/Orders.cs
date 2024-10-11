using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Bookstore.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? OrderStatus { get; set; }
        public virtual List<OrderItems>? OrderItems { get; set; }
    }
}
