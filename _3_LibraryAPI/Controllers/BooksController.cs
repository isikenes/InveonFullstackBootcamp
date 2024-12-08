using _3_LibraryAPI.Exceptions;
using _3_LibraryAPI.Models;
using _3_LibraryAPI.Services;
using _3_LibraryAPI.Services.Interfaces;
using _3_LibraryAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace _3_LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBookService bookService, RedisCacheService cacheService) : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var books = bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("paged")]
        public IActionResult GetPaged([FromQuery] PagingParameters pagingParameters)
        {
            var books = bookService.GetAllPaged(pagingParameters);
            return Ok(books);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            string cacheKey = $"book_{id}";

            var book = await cacheService.GetAsync<Book>(cacheKey);

            if (book == null)
            {
                Console.WriteLine("Book from db");
                book = bookService.GetById(id);
                await cacheService.SetAsync(cacheKey, book, TimeSpan.FromMinutes(10));
            }
            else
            {
                Console.WriteLine("Book from cache");
            }

            if (book == null)
            {
                throw new BookNotFoundException(id);
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author
            };

            string cacheKey = $"book_{book.Id}";
            await cacheService.SetAsync(cacheKey, book, TimeSpan.FromMinutes(10));

            bookService.Add(book);
            return CreatedAtAction("Get", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            if (bookService.Update(book))
            {
                string cacheKey = $"book_{id}";
                await cacheService.SetAsync(cacheKey, book, TimeSpan.FromMinutes(10));

                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (bookService.Delete(id))
            {
                string cacheKey = $"book_{id}";
                await cacheService.RemoveAsync(cacheKey);

                return NoContent();
            }
            return NotFound();
        }
    }
}
