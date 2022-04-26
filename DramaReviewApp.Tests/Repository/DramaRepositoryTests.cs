using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using DramaReviewApp.Data;
using DramaReviewApp.Models;
using DramaReviewApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DramaReviewApp.Tests.Repository
{
    public class DramaRepositoryTests
    {

        private async Task<DataContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Drama.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Drama.Add(
                    new Drama()
                    {
                        Name = "Bob's Burgers",
                        DramaCategories = new List<DramaCategory>()
                            {
                                new DramaCategory { Category = new Category() { Name = "Comedy"}}
                            },
                        Reviews = new List<Review>()
                            {
                                new Review { Title="Bob's Burgers",Text = "Best show ever", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Warner", LastName = "Smith" } },
                                new Review { Title="Bob's Burgers", Text = "Love the Belchers", Rating = 4,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Lautner" } },
                                new Review { Title="Bob's Burgers",Text = "Favorite Cartoon", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "Langley" } },
                            }
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
        [Fact]
        public async void DramaRepository_GetDrama_ReturnsDrama()
        {
            //Arrange
            var name = "Bob's Burgers";
            var dbContext = await GetDatabaseContext();
            var dramaRepository = new DramaRepository(dbContext);

            //Act
            var result = dramaRepository.GetDrama(name);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Drama>();
        }

        [Fact]
        public async void DramaRepository_GetDramaRating_ReturnDecimalBetweenOneAndTen()
        {
            //Arrange
            var dramaId = 1;
            var dbContext = await GetDatabaseContext();
            var dramaRepository = new DramaRepository(dbContext);

            //Act
            var result = dramaRepository.GetDramaRating(dramaId);

            //Assert
            result.Should().NotBe(0);
            result.Should().BeInRange(1, 10);
        }
    }
}
