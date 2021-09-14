namespace Atlantis.WebApi.Shared.DataAccess.Base.Repository
{
    using Atlantis.WebApi.Book.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System;

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

        #region Public CRUD Methods
        /// <summary>
        /// Creates an <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">The entity of type <typeparamref name="TEntity"/>.</param>
        /// <returns></returns>
        bool IRepository<TEntity, TId>.Create(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            var entityEntry = _dbContext.Set<TEntity>().Add(entity);

            return entityEntry.State == EntityState.Added;
        }

        /// <summary>
        /// Reads an <see cref="TEntity"/> based on id.
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        TEntity IRepository<TEntity, TId>.Read(TId id) => InternalReadById(id);

        /// <summary>
        /// Updates an <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">The entity of type <typeparamref name="TEntity"/>.</param>
        /// <returns></returns>
        bool IRepository<TEntity, TId>.Update(TEntity entity)
        {
            var internalEntity = InternalReadById(entity.Id);
            if (internalEntity == null)
                return false;

            entity.CreatedOn = internalEntity.CreatedOn;
            entity.UpdatedOn = DateTime.UtcNow;
            _dbContext.Entry(internalEntity).State = EntityState.Detached;

            var entityEntry = _dbContext.Attach(entity);
            entityEntry.State = EntityState.Modified;

            return entityEntry.State == EntityState.Modified;
        }

        /// <summary>
        /// Deletes an <see cref="TEntity"/> based on id.
        /// </summary>
        /// <param name="id">The id of type <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        bool IRepository<TEntity, TId>.Delete(TId id)
        {
            var entity = InternalReadById(id);
            if (entity == null)
                return false;

            var entityEntry = _dbContext.Set<TEntity>().Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        #endregion Public CRUD Methods

        #region Protected Abstract Methods
        protected virtual TEntity InternalReadById(TId id) => _dbContext.Set<TEntity>().Find(id);
        #endregion Protected Abstract Methods
    }
}
