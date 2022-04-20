using DramaReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DramaReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Drama> Drama { get; set; }
        public DbSet<DramaDirector> DramaDirectors { get; set; }
        public DbSet<DramaCategory> DramaCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DramaCategory>()
                    .HasKey(pc => new { pc.DramaId, pc.CategoryId });
            modelBuilder.Entity<DramaCategory>()
                    .HasOne(p => p.Drama)
                    .WithMany(pc => pc.DramaCategories)
                    .HasForeignKey(p => p.DramaId);
            modelBuilder.Entity<DramaCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.DramaCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<DramaDirector>()
                    .HasKey(po => new { po.DramaId, po.DirectorId });
            modelBuilder.Entity<DramaDirector>()
                    .HasOne(p => p.Drama)
                    .WithMany(pc => pc.DramaDirectors)
                    .HasForeignKey(p => p.DramaId);
            modelBuilder.Entity<DramaDirector>()
                    .HasOne(p => p.Director)
                    .WithMany(pc => pc.DramaDirectors)
                    .HasForeignKey(c => c.DirectorId);
        }
    }
}
