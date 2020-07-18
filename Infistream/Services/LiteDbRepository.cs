using Infistream.DataModel;
using Infistream.ServiceModel;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infistream.Services
{
    public sealed class LiteDbRepository : IRepository
    {
        private readonly LiteDatabase _database;

        public LiteDbRepository(string filename)
        {
            _database = new LiteDatabase(new ConnectionString
            {
                Connection = ConnectionType.Shared,
                Filename = filename
            });
        }

        public void Delete<TEntity>(Guid id) where TEntity : Entity
        {
            _database.GetCollection<TEntity>().DeleteMany(m => m.Id == id);
        }

        public IEnumerable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : Entity
        {
            return _database.GetCollection<TEntity>().Find(predicate);
        }

        public void Upsert<TEntity>(TEntity entity) where TEntity : Entity
        {
            _database.GetCollection<TEntity>().Upsert(entity);
        }
    }
}
