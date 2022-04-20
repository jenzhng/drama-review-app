using DramaReviewApp.Models;

namespace DramaReviewApp.Interfaces
{
    public interface IDirectorRepository
    {
        ICollection<Director> GetDirectors();
        Director GetDirector(int directorId);

        ICollection<Director> GetDirectorOfADrama(int dramaId);
        ICollection<Drama> GetDramaByDirector(int directorId);
        bool DirectorExists(int directorId);
    }
}
