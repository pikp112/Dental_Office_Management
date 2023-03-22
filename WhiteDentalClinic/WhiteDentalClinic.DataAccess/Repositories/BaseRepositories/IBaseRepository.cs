namespace WhiteDentalClinic.DataAccess.Repositories.BaseRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity AddEntity(TEntity entity);
        TEntity UpdateEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
    }
}
