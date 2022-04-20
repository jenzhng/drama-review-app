using DramaReviewApp.Models;

namespace DramaReviewApp.Interfaces
{
    public interface IDramaRepository
    {
        ICollection<Drama> GetDramas();
        Drama GetDrama(int id);

        Drama GetDrama(string title);

        decimal GetDramaRating(int dramaId);

        bool UpdateDrama(int directorId, int categoryId, Drama drama);

        bool CreateDrama(int directorId, int categoryId, Drama drama);

        bool DramaExists(int dramaId);
        bool Save();

    }
}
