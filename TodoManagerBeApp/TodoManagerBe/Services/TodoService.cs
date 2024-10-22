using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoManagerBe.Entities;

namespace TodoManagerBe.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<TodoMongo> _todosCollection;
        public TodoService(
            IOptions<MongoSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName);
            _todosCollection = mongoDatabase.GetCollection<TodoMongo>(bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<TodoMongo>> GetAsync() => await _todosCollection.Find(_ => true).ToListAsync();
        public async Task CreateAsync(TodoMongo newItem) => await _todosCollection.InsertOneAsync(newItem);
    }
}
