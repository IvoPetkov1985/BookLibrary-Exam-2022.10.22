using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using static Library.Data.Common.DataConstants;

namespace Library.Controllers
{
    public class BooksController : BaseController
    {
        private readonly IBookService service;

        public BooksController(IBookService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<BookAllViewModel> model = await service.GetAllBooksAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            IEnumerable<CategoryViewModel> categories = await service.GetAllCategoriesAsync();

            BookFormModel model = new()
            {
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel model)
        {
            IEnumerable<CategoryViewModel> categories = await service.GetAllCategoriesAsync();

            if (categories.Any(c => c.Id == model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), CategoryInvalid);
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = categories;

                return View(model);
            }

            await service.CreateNewBookAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string userId = GetUserId();

            IEnumerable<BookMineViewModel> model = await service.GetAllBooksInCollectionAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            if (await service.IsBookInLibraryAsync(id) == false)
            {
                return NotFound();
            }

            string userId = GetUserId();

            await service.AddBookToCollectionAsync(userId, id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            if (await service.IsBookInLibraryAsync(id) == false)
            {
                return NotFound();
            }

            string userId = GetUserId();

            await service.RemoveBookFromCollectionAsync(userId, id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
