using MongoDB.Bson;
using MongoDB.Driver;
using MongoRepositoryPattern.Context;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoRepositoryPattern.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext _context;
        protected readonly IMongoCollection<TEntity> _collection;
        public BaseRepository(IMongoContext context)
        {
            _context = context;
            _collection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _collection.Find(condition).FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _collection.Find(condition).FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(string id)
        {
            var objId = new ObjectId(id);
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public Task Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Expression<Func<TEntity, bool>> condition)
        {
            await _collection.DeleteOneAsync(condition);
        }

        public Task Remove(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<TEntity>> ToListAsync()
        {
            return await _collection.AsQueryable().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _collection.Find(condition).ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var id = entity.GetObjectId();

            await _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", id), entity);
        }

        public async Task UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            await _collection.ReplaceOneAsync(expression, entity);
        }
    }
}
