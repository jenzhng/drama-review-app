using DramaReviewApp.Models;

namespace DramaReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();

        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfADrama(int dramaId);
        bool ReviewExists(int reviewId);

        bool UpdateReview(Review review);
        bool Save();
    }
}
