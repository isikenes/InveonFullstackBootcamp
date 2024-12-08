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
    public class BorrowersController(IBorrowerService borrowerService, RedisCacheService cacheService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var borrowers = borrowerService.GetAll();
            return Ok(borrowers);
        }

        [HttpGet("paged")]
        public IActionResult GetPaged([FromQuery] PagingParameters pagingParameters)
        {
            var borrowers = borrowerService.GetAllPaged(pagingParameters);
            return Ok(borrowers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            string cacheKey = $"borrower_{id}";
            var borrower = await cacheService.GetAsync<Borrower>(cacheKey);

            if (borrower == null)
            {
                borrower = borrowerService.GetById(id);
                await cacheService.SetAsync(cacheKey, borrower, TimeSpan.FromMinutes(10));
            }

            if (borrower == null)
            {
                throw new BorrowerNotFoundException(id);
            }
            return Ok(borrower);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Borrower borrower)
        {
            string cacheKey = $"borrower_{borrower.Id}";
            await cacheService.SetAsync(cacheKey, borrower, TimeSpan.FromMinutes(10));

            borrowerService.Add(borrower);
            return CreatedAtAction("Get", new { id = borrower.Id }, borrower);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Borrower borrower)
        {
            if (id != borrower.Id)
            {
                return BadRequest();
            }
            if (borrowerService.Update(borrower))
            {
                string cacheKey = $"borrower_{id}";
                await cacheService.SetAsync(cacheKey, borrower, TimeSpan.FromMinutes(10));

                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (borrowerService.Delete(id))
            {
                string cacheKey = $"borrower_{id}";
                await cacheService.RemoveAsync(cacheKey);

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("{borrowerId}/books/{bookId}/borrow")]
        public async Task<IActionResult> BorrowBookAsync(int borrowerId, int bookId)
        {
            if (borrowerService.BorrowBook(borrowerId, bookId))
            {
                string cacheKey = $"borrower_{borrowerId}";
                await cacheService.RemoveAsync(cacheKey);

                string cacheKeyBook = $"book_{bookId}";
                await cacheService.RemoveAsync(cacheKeyBook);

                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost("{borrowerId}/books/{bookId}/return")]
        public async Task<IActionResult> ReturnBookAsync(int borrowerId, int bookId)
        {
            if (borrowerService.ReturnBook(borrowerId, bookId))
            {
                string cacheKey = $"borrower_{borrowerId}";
                await cacheService.RemoveAsync(cacheKey);

                string cacheKeyBook = $"book_{bookId}";
                await cacheService.RemoveAsync(cacheKeyBook);

                return NoContent();
            }
            return BadRequest();
        }
    }
}
