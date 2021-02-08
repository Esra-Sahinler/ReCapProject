using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, ReCapDatabaseContext> : IEntityRepository<TEntity>

        where TEntity : class, IEntity, new()
        where ReCapDatabaseContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}
