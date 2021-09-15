namespace Atlantis.WebApi.Shared.DataAccess.UnitOfWork
{
    using Atlantis.WebApi.Book.Persistence;

    public class UnitOfWork
    {
        private readonly AtlantisDbContext _dbContext;

        public UnitOfWork(AtlantisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Commits all the DB changes.
        /// </summary>
        /// <returns></returns>
        public int Commit() => _dbContext.SaveChanges();
    }
}
