using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Bookstore.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemId { get; set; }
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        [ForeignKey("Books")]
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
    }
}
