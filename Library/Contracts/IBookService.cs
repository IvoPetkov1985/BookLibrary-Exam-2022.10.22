using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBookToCollectionAsync(string userId, int bookId);

        Task CreateNewBookAsync(BookFormModel model);

        Task<IEnumerable<BookAllViewModel>> GetAllBooksAsync();

        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

        Task<IEnumerable<BookMineViewModel>> GetAllMineBooksAsync(string userId);

        Task<bool> IsBookExistingAsync(int bookId);

        Task<bool> IsUserEntryExistingAsync(string userId, int bookId);

        Task RemoveBookFromCollectionAsync(string userId, int bookId);
    }
}
