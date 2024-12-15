using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Authorize]
    [Route("/Books")]
    public class BooksController(IBookService bookService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetAll();
            return View(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var book = await bookService.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }
    }
}
