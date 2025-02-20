using Microsoft.EntityFrameworkCore;
using Group_14.CoreLayer.Entities;

namespace Group_14.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MovieSeries> MoviesSeries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Thiết lập khóa chính cho MovieSeriesTag (Composite Key)
            modelBuilder.Entity<MovieSeriesTag>()
                .HasKey(mst => new { mst.MovieSeriesId, mst.TagId });

            // Thiết lập quan hệ giữa MovieSeriesTag với MovieSeries
            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne<MovieSeries>()
                .WithMany()
                .HasForeignKey(mst => mst.MovieSeriesId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ giữa MovieSeriesTag với Tag
            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne<Tag>()
                .WithMany()
                .HasForeignKey(mst => mst.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ giữa Review với User
            modelBuilder.Entity<Review>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ giữa Review với MovieSeries
            modelBuilder.Entity<Review>()
                .HasOne<MovieSeries>()
                .WithMany()
                .HasForeignKey(r => r.MovieSeriesId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ giữa Rating với User
            modelBuilder.Entity<Rating>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ giữa Rating với MovieSeries
            modelBuilder.Entity<Rating>()
                .HasOne<MovieSeries>()
                .WithMany()
                .HasForeignKey(r => r.MovieSeriesId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
