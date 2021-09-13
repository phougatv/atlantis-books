namespace Atlantis.WebApi.Shared.DataAccess.Base.Repository
{
    using Atlantis.WebApi.Book.Persistence;

    internal abstract class EfRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly AtlantisDbContext _dbContext;

        /// <summary>
        /// Ctor, creates an instance of repository.
        /// </summary>
        /// <param name="dbContext">The db context <see cref="AtlantisDbContext"/>.</param>
        protected EfRepository(AtlantisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Reads an <see cref="TEntity"/> based on id.
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        TEntity IRepository<TEntity, TId>.Read(TId id) => InternalReadById(id);

        #region Protected Abstract Methods
        protected virtual TEntity InternalReadById(TId id) => _dbContext.Set<TEntity>().Find(id);
        #endregion Protected Abstract Methods
    }
}
