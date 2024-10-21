using Microsoft.AspNetCore.Mvc;
using TodoManagerBe.Entities;
using TodoManagerBe.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoManagerBe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService) =>
            _booksService = booksService;

        [HttpGet]
        public async Task<List<BooksMongo>> Get() =>
            await _booksService.GetAsync();


        [HttpPost]
        public async Task<IActionResult> Post(BooksMongo newBook)
        {
            await _booksService.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

    }
}
