using BookService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookService.Persistence.EntityFramework.Context
{
    public class BookServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sinan;Database=readNrent_BookService_db;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publish>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publish)
                .WithOne(b => b.Book)
                .HasForeignKey<Publish>("Id");
        }
        DbSet<Book> Books { get; set; }
        DbSet<BookImage> BookImages { get; set; }
        DbSet<BookReview> BookReviews { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Publish> Publishes { get; set; }
        DbSet<Publisher> Publishers { get; set; }

    }
}
