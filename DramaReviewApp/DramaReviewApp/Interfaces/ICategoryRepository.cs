using DramaReviewApp.Models;

namespace DramaReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);

        ICollection<Drama> GetDramaByCategory(int categoryId);


        bool CategoryExists(int id);


    }
}
