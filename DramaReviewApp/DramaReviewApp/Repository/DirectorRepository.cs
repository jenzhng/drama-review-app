using DramaReviewApp.Data;
using DramaReviewApp.Interfaces;
using DramaReviewApp.Models;

namespace DramaReviewApp.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DataContext _context;

        public DirectorRepository(DataContext context)
        {
            _context = context;
        }
        public Director GetDirector(int directorId)
        {
            return _context.Directors.Where(o => o.Id == directorId).FirstOrDefault();
        }

        public ICollection<Director> GetDirectors()
        {
            return _context.Directors.ToList();
        }

        public ICollection<Director> GetDirectorOfADrama(int dramaId)
        {
            return _context.DramaDirectors.Where(p => p.Drama.Id == dramaId).Select(o => o.Director).ToList();
        }

        public ICollection<Drama> GetDramaByDirector(int directorId)
        {
            return _context.DramaDirectors.Where(p => p.Director.Id == directorId).Select(p => p.Drama).ToList();

        }

        public bool DirectorExists(int directorId)
        {
            return _context.Directors.Any(o => o.Id == directorId);
        }
    }
}
