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
            var model = await service.GetAllBooksAsync();

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
                ModelState.AddModelError(nameof(model.CategoryId), CategoryErrorMsg);
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = categories;

                return View(model);
            }

            await service.AddBookToDbAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            bool isBookExisting = await service.IsBookExisting(bookId);

            if (isBookExisting == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await service.AddBookToCollectionAsync(userId, bookId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string userId = GetUserId();

            var model = await service.GetMyBooksCollectionAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            bool isBookExisting = await service.IsBookExisting(bookId);

            if (isBookExisting == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await service.RemoveBookFromCollectionAsync(userId, bookId);

            return RedirectToAction(nameof(Mine));
        }
    }
}
