using Microsoft.EntityFrameworkCore;
using Group_14.MovieReview.CoreLayer;
using Group_14.MovieReview.CoreLayer.Entities;

namespace Group_14.DataAccessLayer
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Định nghĩa khóa chính
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Movie>().HasKey(m => m.Id);
            modelBuilder.Entity<Review>().HasKey(r => r.Id);
            modelBuilder.Entity<Rating>().HasKey(rt => rt.Id);
            modelBuilder.Entity<Tag>().HasKey(t => t.Id);
        }
    }
}
