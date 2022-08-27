using AuthorTranslatorService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorTranslatorService.Persistence.EntityFramework.Context
{
    public class AuthorTranslatorServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sinan;Database=readNrent_AuthorTranslatorService_db;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasNoKey();
            modelBuilder.Entity<BookTranslator>().HasNoKey();

            modelBuilder.Entity<Translator>()
                .HasMany<BookTranslator>()
                .WithOne()
                .HasForeignKey(b => b.TranslatorId);

            modelBuilder.Entity<Translator>()
                .HasMany<BookAuthor>()
                .WithOne()
                .HasForeignKey(b => b.AuthorId);

        }
        DbSet<Translator> Authors { get; set; }
        DbSet<Translator> Translators { get; set; }
        DbSet<TranslatorReview> TranslatorReviews { get; set; }
        DbSet<AuthorReview> AuthorReviews { get; set; }
        DbSet<BookAuthor> BookAuthor { get; set; }
        DbSet<BookTranslator> BookTranslator { get; set; }
    }
}
