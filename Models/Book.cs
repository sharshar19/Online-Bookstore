using System.ComponentModel.DataAnnotations;

namespace Online_Bookstore.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity {  get; set; }
        public DateTime PublishDate { get; set; }
        public virtual List<OrderItems>? OrderItems { get; set; }
        public virtual List<Reviews>? Reviews { get; set; }
    }
}
