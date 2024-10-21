using TodoManagerBe.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TodoManagerBe.Services
{
    public class BooksService
    {
        private readonly IMongoCollection<BooksMongo> _booksCollection;

        public BooksService(
            IOptions<MongoSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<BooksMongo>(
                bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<BooksMongo>> GetAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<BooksMongo?> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(BooksMongo newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, BooksMongo updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
