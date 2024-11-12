using Library.Contracts;
using Library.Data;
using Library.Data.DataModels;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task AddBookToCollectionAsync(string userId, int bookId)
        {
            if (await context.ApplicationUsersBooks.AnyAsync(b => b.ApplicationUserId == userId && b.BookId == bookId) == false)
            {
                await context.ApplicationUsersBooks.AddAsync(new ApplicationUserBook()
                {
                    ApplicationUserId = userId,
                    BookId = bookId
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task AddBookToDbAsync(BookFormModel model)
        {
            Book book = new()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await context.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
        {
            IEnumerable<BookViewModel> allBooks = await context.Books
                .AsNoTracking()
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();

            return allBooks;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            IEnumerable<CategoryViewModel> categories = await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<BookMineViewModel>> GetMyBooksCollectionAsync(string userId)
        {
            IEnumerable<BookMineViewModel> bookCollection = await context.ApplicationUsersBooks
                .AsNoTracking()
                .Where(ab => ab.ApplicationUserId == userId)
                .Select(b => new BookMineViewModel()
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    Description = b.Book.Description,
                    ImageUrl = b.Book.ImageUrl,
                    Category = b.Book.Category.Name
                })
                .ToListAsync();

            return bookCollection;
        }

        public async Task<bool> IsBookExisting(int bookId)
        {
            var searchedBook = await context.Books
                .FirstOrDefaultAsync(b => b.Id == bookId);

            return searchedBook != null;
        }

        public async Task RemoveBookFromCollectionAsync(string userId, int bookId)
        {
            if (await context.ApplicationUsersBooks.AnyAsync(ab => ab.ApplicationUserId == userId && ab.BookId == bookId))
            {
                ApplicationUserBook entry = await context.ApplicationUsersBooks
                    .FirstAsync(ab => ab.ApplicationUserId == userId && ab.BookId == bookId);

                context.ApplicationUsersBooks.Remove(entry);

                await context.SaveChangesAsync();
            }
        }
    }
}
