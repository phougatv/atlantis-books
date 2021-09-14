namespace Atlantis.WebApi.Shared.DataAccess.Base.Repository
{
    internal interface IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        /// <summary>
        /// Creates an <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">The entity of type <typeparamref name="TEntity"/>.</param>
        /// <returns></returns>
        bool Create(TEntity entity);

        /// <summary>
        /// Reads an <see cref="TEntity"/> based on id.
        /// </summary>
        /// <param name="id">The id of type <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        TEntity Read(TId id);

        /// <summary>
        /// Updates an <see cref="TEntity"/>.
        /// </summary>
        /// <param name="entity">The entity of type <typeparamref name="TEntity"/>.</param>
        /// <returns></returns>
        bool Update(TEntity entity);

        /// <summary>
        /// Deletes an <see cref="TEntity"/> based on id.
        /// </summary>
        /// <param name="id">The id of type <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        bool Delete(TId id);
    }
}
