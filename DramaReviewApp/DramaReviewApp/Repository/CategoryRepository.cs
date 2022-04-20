using AutoMapper;
using DramaReviewApp.Data;
using DramaReviewApp.Interfaces;
using DramaReviewApp.Models;

namespace DramaReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Drama> GetDramaByCategory(int categoryId)
        {
            return _context.DramaCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Drama).ToList();
        }
    }
}
