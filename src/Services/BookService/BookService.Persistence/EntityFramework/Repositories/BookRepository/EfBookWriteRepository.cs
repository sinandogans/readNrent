using AuthorTranslatorService.Persistence.EntityFramework.Repositories.Base;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using BookService.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace BookService.Persistence.EntityFramework.Repositories.BookRepository
{
    public class EfBookWriteRepository : EfBaseWriteRepository<Book, BookServiceContext>, IBookWriteRepository
    {
        public async Task AddBookLanguage(Guid bookId, Guid languageId)
        {
            using (var context = new BookServiceContext())
            {
                var book = await context.Set<Book>().SingleOrDefaultAsync(b => b.Id == bookId);
                book.LanguageId = languageId;
                await context.SaveChangesAsync();
            }
        }

        public async Task AddBookPublish(Publish publish)
        {
            using (var context = new BookServiceContext())
            {
                await context.Set<Publish>().AddAsync(publish);
                var book = await context.Set<Book>().SingleOrDefaultAsync(b => b.Id == publish.BookId);
                book.Publish = publish;
                await context.SaveChangesAsync();
            }
        }

        public async Task AddBookReview(BookReview bookReview)
        {
            using (var context = new BookServiceContext())
            {
                await context.Set<BookReview>().AddAsync(bookReview);
                var book = await context.Set<Book>().SingleOrDefaultAsync(b => b.Id == bookReview.BookId);
                book.Reviews.Add(bookReview);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddBookGenre(Guid bookId, Genre genre)
        {
            using (var context = new BookServiceContext())
            {
                var book = await context.Set<Book>().SingleOrDefaultAsync(b => b.Id == bookId);
                book.Genres.Add(genre);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddBookImage(Guid bookId, BookImage bookImage)
        {
            using (var context = new BookServiceContext())
            {
                await context.AddAsync(bookImage);
                var book = await context.Set<Book>().SingleOrDefaultAsync(b => b.Id == bookId);
                book.BookImages.Add(bookImage);
                await context.SaveChangesAsync();
            }
        }
    }
}
