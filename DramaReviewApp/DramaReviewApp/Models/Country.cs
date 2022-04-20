﻿namespace DramaReviewApp.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Director> Directors { get; set; }
    }
}
