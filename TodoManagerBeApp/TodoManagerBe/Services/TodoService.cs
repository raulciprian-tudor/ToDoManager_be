using TodoManagerBe.Entities;

namespace TodoManagerBe.Services
{
    public class TodoService
    {
        public TodoService() { }

        // get all todo items
        public IEnumerable<TodoItemEntity> GetItems()
        {
            return new List<TodoItemEntity>
            {
                new TodoItemEntity
                {
                    Id = "1",
                    Title = "Todo 1",
                    Description = "Description 1",
                    IsCompleted = false
                },
                new TodoItemEntity
                {
                    Id = "2",
                    Title = "Todo 2",
                    Description = "Description 2",
                    IsCompleted = true
                }
            };
        }

        public IEnumerable<TodoItemEntity> CreateItem(TodoItemEntity body) 
        {
            return new List<TodoItemEntity>
            {
                new TodoItemEntity
                {
                    Id = body.Id,
                    Title = body.Title,
                    Description = body.Description,
                    IsCompleted = body.IsCompleted
                }
            };
        }
    }
}
