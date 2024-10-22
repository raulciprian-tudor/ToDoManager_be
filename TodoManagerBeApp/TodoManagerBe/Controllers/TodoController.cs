using Microsoft.AspNetCore.Mvc;
using TodoManagerBe.Entities;
using TodoManagerBe.Services;

namespace TodoManagerBe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService) =>
            _todoService = todoService;

        [HttpGet]
        public async Task<List<TodoMongo>> Get() => await _todoService.GetAsync();


        [HttpPost]
        public async Task<IActionResult> Post(TodoMongo newItem)
        {
            await _todoService.CreateAsync(newItem);
            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

    }
}
