using Microsoft.EntityFrameworkCore;
using WhiteDentalClinic.DataAccess.Repositories.IRepositories;

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

        //need to implement for performance instead of SELECT * FROM Appointments WHERE CustomerId = X in services
        /*        public TEntity SelectEntity(Guid entityId)
                {
                    return DbSet.ToList().Where(e => e.Id == entityId);
                }*/

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