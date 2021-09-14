namespace Atlantis.WebApi.Book.Persistence
{
    using Atlantis.WebApi.Shared.DataAccess.Base.Repository;
    using System;

    internal class BookRepository : EfRepository<Book, Guid>, IBookRepository
    {
        public BookRepository(AtlantisDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
