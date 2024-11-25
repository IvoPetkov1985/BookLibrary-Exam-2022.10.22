using Library.Contracts;
using Library.Data;
using Library.Data.DataModels;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
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
            ApplicationUserBook userBook = new()
            {
                ApplicationUserId = userId,
                BookId = bookId
            };

            if (await context.ApplicationUsersBooks.ContainsAsync(userBook) == false)
            {
                await context.ApplicationUsersBooks.AddAsync(userBook);

                await context.SaveChangesAsync();
            }
        }

        public async Task CreateNewBookAsync(BookFormModel model)
        {
            Book book = new()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId,
            };

            await context.Books.AddAsync(book);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookAllViewModel>> GetAllBooksAsync()
        {
            IEnumerable<BookAllViewModel> allBooks = await context.Books
                .AsNoTracking()
                .Select(b => new BookAllViewModel()
                {
                    BookId = b.Id,
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

        public async Task<IEnumerable<BookMineViewModel>> GetAllMineBooksAsync(string userId)
        {
            IEnumerable<BookMineViewModel> books = await context.ApplicationUsersBooks
                .AsNoTracking()
                .Where(ub => ub.ApplicationUserId == userId)
                .Select(ub => new BookMineViewModel()
                {
                    BookId = ub.Book.Id,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    ImageUrl = ub.Book.ImageUrl,
                    Description = ub.Book.Description,
                    Category = ub.Book.Category.Name
                })
                .ToListAsync();

            return books;
        }

        public async Task<bool> IsBookExistingAsync(int bookId)
        {
            Book? book = await context.Books
                .AsNoTracking()
                .SingleOrDefaultAsync(b => b.Id == bookId);

            return book != null;
        }

        public async Task<bool> IsUserEntryExistingAsync(string userId, int bookId)
        {
            ApplicationUserBook? userBook = await context.ApplicationUsersBooks
                .AsNoTracking()
                .SingleOrDefaultAsync(ub => ub.ApplicationUserId == userId && ub.BookId == bookId);

            return userBook != null;
        }

        public async Task RemoveBookFromCollectionAsync(string userId, int bookId)
        {
            ApplicationUserBook userEntry = await context.ApplicationUsersBooks
                .SingleAsync(ub => ub.ApplicationUserId == userId && ub.BookId == bookId);

            context.ApplicationUsersBooks.Remove(userEntry);

            await context.SaveChangesAsync();
        }
    }
}
