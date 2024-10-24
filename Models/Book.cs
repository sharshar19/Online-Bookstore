using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Online_Bookstore.Models
{
    public class Book
    {
        [Key]
        //[Required(ErrorMessage ="{0} is a required field")]
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
