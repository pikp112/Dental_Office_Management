using Microsoft.EntityFrameworkCore;
using WhiteDentalClinic.DataAccess.Repositories.BaseRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly ApiDbTempContext Context;
        protected readonly DbSet<TEntity> DbSet;
        protected BaseRepository(ApiDbTempContext context)   
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
        public TEntity AddEntity(TEntity entity)
        {
            var addedEntity = DbSet.Add(entity).Entity;
            Context.SaveChanges();

            return addedEntity;
        }
        public TEntity UpdateEntity(TEntity entity)
        {
            DbSet.Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public void DeleteEntity(TEntity entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

    }
}