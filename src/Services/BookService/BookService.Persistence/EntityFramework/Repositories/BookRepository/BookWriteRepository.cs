using AuthorTranslatorService.Persistence.EntityFramework.Repositories.Base;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using BookService.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace BookService.Persistence.EntityFramework.Repositories.BookRepository
{
    public class BookWriteRepository : EfWriteRepository<Book, BookServiceContext>, IBookWriteRepository
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
    }
}
