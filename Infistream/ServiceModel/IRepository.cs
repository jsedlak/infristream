using Infistream.DataModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infistream.ServiceModel
{
    public interface IRepository
    {
        IEnumerable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : Entity;

        void Upsert<TEntity>(TEntity entity) where TEntity : Entity;

        void Delete<TEntity>(Guid id) where TEntity : Entity;
    }
}
