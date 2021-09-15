namespace Atlantis.WebApi.Shared.DataAccess.UnitOfWork
{
    /// <summary>
    /// IUnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits all the entity entry changes.
        /// </summary>
        /// <returns></returns>
        int Commit();
    }
}
