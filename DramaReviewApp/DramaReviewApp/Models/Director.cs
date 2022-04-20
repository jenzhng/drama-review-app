namespace DramaReviewApp.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Country Country { get; set; }
        public ICollection<DramaDirector> DramaDirectors { get; set; }



    }
}
