using Microsoft.AspNetCore.Mvc;
using TodoManagerBe.Entities;
using TodoManagerBe.Services;

namespace TodoManagerBe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // GET: api/Todo
        [HttpGet]
        public IEnumerable<TodoItemEntity> Get()
        {
            var data = new TodoService().GetItems();
            return data;
        }

        // POST api/Todo
        [HttpPost]
        public void Post([FromBody] TodoItemEntity body)
        {
            var data = new TodoService().CreateItem(body);
        }

        //// PUT api/Todo/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/Todo/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
