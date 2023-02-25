using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDb_Sample.Models;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;

namespace MongoDb_Sample.Repositories.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        private readonly DbConfiguration _settings;
        public BaseRepository(IOptions<DbConfiguration> settings)
        {
            var test = typeof(T).ToString().Split('.').Last();
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            //_collection = database.GetCollection<T>(typeof(T).ToString().Split('.').Last());

            //if your collectionNames have (s) at the end
            _collection = database.GetCollection<T>(typeof(T).ToString().Split('.').Last() + "s");
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;

        }

        public async Task DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var res = await _collection.DeleteOneAsync(expression);

        }

        public async Task<List<T>> GetAllAsync()
        {
            var res = await (await _collection.FindAsync(c => true)).ToListAsync();
            return res;
                
        }

        public async Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            var res = await (await _collection.FindAsync(expression)).ToListAsync();
            return res;
        }

        public async Task UpdateAsync(Expression<Func<T, bool>> expression, T entity )
        {
            await _collection.ReplaceOneAsync(expression, entity);

        }
    }
}
