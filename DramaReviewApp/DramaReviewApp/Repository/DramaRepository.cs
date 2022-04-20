using DramaReviewApp.Data;
using DramaReviewApp.Interfaces;
using DramaReviewApp.Models;

namespace DramaReviewApp.Repository
{
    public class DramaRepository : IDramaRepository
    {
        private readonly DataContext _context;

        public DramaRepository(DataContext context)
        {
            _context = context;
        }
        public bool DramaExists(int dramaId)
        {
            return _context.Drama.Any(p => p.Id == dramaId);
        }

        public Drama GetDrama(int id)
        {
            return _context.Drama.Where(p => p.Id == id).FirstOrDefault();
        }

        public Drama GetDrama(string title)
        {
            return _context.Drama.Where(p => p.Title == title).FirstOrDefault();
        }

        public decimal GetDramaRating(int dramaId)
        {
            var review = _context.Reviews.Where(p => p.Drama.Id == dramaId);
            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Drama> GetDramas()
        {
            return _context.Drama.OrderBy(p => p.Id).ToList();
        }

        public bool UpdateDrama(int directorId, int categoryId, Drama drama)
        {
            _context.Update(drama);
            return Save();
        }

        

        public bool CreateDrama(int directorId, int categoryId, Drama drama)
        {
            var dramaDirectorEntity = _context.Directors.Where(a => a.Id == directorId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();
            var dramaDirector = new DramaDirector()
            {
                Director = dramaDirectorEntity,
                Drama = drama,
            };

            _context.Add(dramaDirector);

            var dramaCategory = new DramaCategory()
            {
                Category = category,
                Drama = drama,
            };

            _context.Add(dramaCategory);

            _context.Add(drama);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
