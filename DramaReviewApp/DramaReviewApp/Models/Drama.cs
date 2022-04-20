namespace DramaReviewApp.Models
{
    public class Drama
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public int Year { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<DramaDirector> DramaDirectors { get; set; }

        public ICollection<DramaCategory> DramaCategories { get; set; }
    }
}
