using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookContext _bookContext;
        public ReviewRepository(BookContext bookContext)
        {
            this._bookContext = bookContext;

        }
        public void CreateReview(Reviews reviews)
        {
            _bookContext.Add(reviews);
            _bookContext.SaveChanges();
            return;
        }

        public bool DeleteReview(int id)
        {
            var review = GetReviewById(id);

            if (review == null || review.ReviewId != id)
            {
                return false;
            }

            _bookContext.reviews.Remove(review);
            _bookContext.SaveChanges();

            return true;
        }

        public Reviews? GetReviewById(int id)
        {
            return (from _reviews in _bookContext.reviews where _reviews.ReviewId == id select _reviews).FirstOrDefault();
        }

        public IEnumerable<Reviews> GetReviews()
        {
            return _bookContext.reviews;
        }

        public void UpdateReview(Reviews reviews)
        {
            int reviewId = reviews.ReviewId;
            var dbReviews = GetReviewById(reviewId);
            dbReviews = reviews;
            dbReviews.ReviewId = reviewId;
            _bookContext.SaveChanges();
            return;
        }
    
    }
}
