using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public interface IReviewRepository
    {
        public void CreateReview(Reviews reviews);
        public IEnumerable<Reviews> GetReviews();
        public Reviews? GetReviewById(int id);
        public void UpdateReview(Reviews reviews);
        public bool DeleteReview(int id);
    }
}
