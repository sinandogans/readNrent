using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using BookService.Persistence.EntityFramework.Context;
using BookService.Persistence.EntityFramework.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace BookService.Persistence.EntityFramework.Repositories.BookRepository
{
    public class EFBookRepository : EFBaseRepository<Book, BookServiceContext>, IBookRepository
    {

        public async Task AddPublish(Publish publish)
        {
            using (var context = new BookServiceContext())
            {
                await context.Set<Publish>().AddAsync(publish);
                var book = await context.Set<Book>().SingleOrDefaultAsync(b => b.Id == publish.BookId);
                book.PublishId = publish.Id;
                await context.SaveChangesAsync();
            }
        }

        public async Task AddBookReview(BookReview bookReview)
        {
            using (var context = new BookServiceContext())
            {
                await context.Set<BookReview>().AddAsync(bookReview);
                //var book = await context.Set<Book>().SingleOrDefaultAsync(b => b.Id == bookReview.BookId);
                //book.Reviews.Add(bookReview);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddBookImage(BookImage bookImage)
        {
            using (var context = new BookServiceContext())
            {
                await context.AddAsync(bookImage);
                var book = await context.Set<Book>().SingleOrDefaultAsync(b => b.Id == bookImage.BookId);
                book.Images.Add(bookImage);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Book> GetById(Guid id)
        {
            using (var context = new BookServiceContext())
            {
                return await this.Get(b => b.Id == id);
            }
        }

        public async Task<Book> AddAuthor(Guid bookId, Guid authorId)
        {
            using (var context = new BookServiceContext())
            {
                var author = await context.Set<AuthorModel>().SingleOrDefaultAsync(a => a.Id == authorId);
                var book = await context.Set<Book>().Include(b => b.Authors).SingleOrDefaultAsync(b => b.Id == bookId);
                book.Authors.Add(author);
                await context.SaveChangesAsync();
                return book;
            }
        }

        public async Task<Book> AddTranslator(Guid bookId, Guid translatorId)
        {
            using (var context = new BookServiceContext())
            {
                var translator = await context.Set<TranslatorModel>().SingleOrDefaultAsync(a => a.Id == translatorId);
                var book = await context.Set<Book>().Include(b => b.Translators).SingleOrDefaultAsync(b => b.Id == bookId);
                book.Translators.Add(translator);
                await context.SaveChangesAsync();
                return book;
            }
        }
    }
}
