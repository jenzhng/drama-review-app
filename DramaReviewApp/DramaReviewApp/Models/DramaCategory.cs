namespace DramaReviewApp.Models
{
    public class DramaCategory
    {
        public int DramaId { get; set; }
        public int CategoryId { get; set; }
        public Drama Drama { get; set; }
        public Category Category { get; set; }
    }
}
