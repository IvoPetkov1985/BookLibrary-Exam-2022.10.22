using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBookToCollectionAsync(string userId, int bookId);

        Task AddBookToDbAsync(BookFormModel model);

        Task<IEnumerable<BookViewModel>> GetAllBooksAsync();

        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

        Task<IEnumerable<BookMineViewModel>> GetMyBooksCollectionAsync(string userId);

        Task<bool> IsBookExisting(int bookId);

        Task RemoveBookFromCollectionAsync(string userId, int bookId);
    }
}
