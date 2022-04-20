using DramaReviewApp.Data;
using DramaReviewApp.Models;

namespace DramaReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.DramaDirectors.Any())
            {
                var dramaDirectors = new List<DramaDirector>()
                {
                    new DramaDirector()
                    {
                        Drama = new Drama()
                        {
                            Title = "House",
							ImageUrl = "https://artworks.thetvdb.com/banners/series/73255/posters/230801.jpg",
                            Description = "Fox Medical drama",
							Year = 2004,
                            DramaCategories = new List<DramaCategory>()
                            {
                                new DramaCategory { Category = new Category() { Name = "Medical"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="House",Text = "Better than Greys Anatomy", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Anne", LastName = "Marie" } },
                                new Review { Title="House", Text = "House is crazy", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="House",Text = "I love thirteen", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Director = new Director()
                        {
                            FirstName = "David",
                            LastName = "Shore",
                            Country = new Country()
                            {
                                Name = "Canada"
                            }
                        }
                    },
                    new DramaDirector()
                    {
                        Drama = new Drama()
                        {
							Title = "Law & Order: Special Victims Unit",
                            ImageUrl = "https://m.media-amazon.com/images/I/711VknNPdXL._SL1000_.jpg",
                            Description = "Procedural crime drama",
							Year = 1999,
                            DramaCategories = new List<DramaCategory>()
                            {
                                new DramaCategory { Category = new Category() { Name = "Crime"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Law & Order: Special Victims Unit", Text = "SVU is wild", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Sarah", LastName = "Connor" } },
                                new Review { Title= "Law & Order: Special Victims Unit",Text = "SVU, SVU", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Law & Order: Special Victims Unit", Text = "SVU crosses the line sometimes", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Director = new Director()
                        {
                            FirstName = "Dick",
                            LastName = "Wolf",
                         
                            Country = new Country()
                            {
                                Name = "United States"
                            }
                        }
                    }, 
					new DramaDirector()
                    {
                        Drama = new Drama()
                        {
							Title = "Game of Thrones",
                            ImageUrl = "https://m.media-amazon.com/images/I/71aS+WLCcaL._SY445_.jpg",
                            Description = "Procedural crime drama",
							Year = 1999,
                            DramaCategories = new List<DramaCategory>()
                            {
                                new DramaCategory { Category = new Category() { Name = "Fantasy"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Game of Thrones", Text = "Wow", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Sarah", LastName = "Connor" } },
                                new Review { Title= "Game of Thrones",Text = "Got worse", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Game of Thrones", Text = "Don't finish this", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Director = new Director()
                        {
                            FirstName = "George",
                            LastName = "Martin",
                         
                            Country = new Country()
                            {
                                Name = "United States"
                            }
                        }
                    }, 
					new DramaDirector()
                    {
                        Drama = new Drama()
                        {
							Title = "Pushing Daisies",
                            ImageUrl = "https://m.media-amazon.com/images/I/51F7cWjC12L._SY445_.jpg",
                            Description = "Romance is alive",
							Year = 2007,
                            DramaCategories = new List<DramaCategory>()
                            {
                                new DramaCategory { Category = new Category() { Name = "Comedy"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Pushing Daisies", Text = "Wow", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Sarah", LastName = "Connor" } },
                                new Review { Title= "Pushing Daisies",Text = "Love this show", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Pushing Daisies", Text = "Favorite", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Director = new Director()
                        {
                            FirstName = "Bryan",
                            LastName = "Fuller",
                         
                            Country = new Country()
                            {
                                Name = "United States"
                            }
                        }
                    }, 
					new DramaDirector()
                    {
                        Drama = new Drama()
                        {
							Title = "Better Call Saul",
                            ImageUrl = "https://m.media-amazon.com/images/I/41SH20pdGmL.jpg",
                            Description = "Spinoff",
							Year = 2015,
                            DramaCategories = new List<DramaCategory>()
                            {
                                new DramaCategory { Category = new Category() { Name = "Drama"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Better Call Saul", Text = "Better than the original", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Sarah", LastName = "Connor" } },
                                new Review { Title= "Better Call Saul",Text = "Love Bob Odenkirk", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Better Call Saul", Text = "Amazing", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Director = new Director()
                        {
                            FirstName = "Vince",
                            LastName = "Gilligan",
                         
                            Country = new Country()
                            {
                                Name = "United States"
                            }
                        }
                    }, 
					new DramaDirector()
                    {
                        Drama = new Drama()
                        {
							Title = "What We Do In the Shadows",
                            ImageUrl = "https://m.media-amazon.com/images/I/81RSwde5aqL._SL1500_.jpg",
                            Description = "Spinoff",
							Year = 2019,
                            DramaCategories = new List<DramaCategory>()
                            {
                                new DramaCategory { Category = new Category() { Name = "Comedy"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "What We Do In the Shadows", Text = "Better than the original", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Sarah", LastName = "Connor" } },
                                new Review { Title= "What We Do In the Shadows",Text = "Love this show ", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "What We Do In the Shadows", Text = "Incredible writing", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Director = new Director()
                        {
                            FirstName = "Jemaine",
                            LastName = "Clement",
                         
                            Country = new Country()
                            {
                                Name = "New Zealand"
                            }
                        }
                    }
					
                               
                };
                dataContext.DramaDirectors.AddRange(dramaDirectors);
                dataContext.SaveChanges();
            }
        }
    }
}

