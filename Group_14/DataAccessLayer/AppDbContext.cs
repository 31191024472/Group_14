using Microsoft.EntityFrameworkCore;
using Group_14.MovieReview.CoreLayer;
using Group_14.MovieReview.CoreLayer.Entities;

namespace Group_14.DataAccessLayer
{
    public class AppDbContext : DbContext

    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("MoviesSeries");
            modelBuilder.Entity<Review>().ToTable("Reviews");
            modelBuilder.Entity<Rating>().ToTable("Ratings");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
