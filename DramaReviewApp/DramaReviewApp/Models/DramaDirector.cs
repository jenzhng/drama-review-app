namespace DramaReviewApp.Models
{
    public class DramaDirector
    {
        public int DramaId { get; set; }
        public int DirectorId { get; set; }
        public Drama Drama { get; set; }
        public Director Director { get; set; }
    }
}
