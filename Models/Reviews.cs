using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Bookstore.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        [ForeignKey("Books")]
        public int BookId { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
