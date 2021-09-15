namespace Atlantis.WebApi.Book.Persistence
{
    using Atlantis.WebApi.Shared.DataAccess.Base.Repository;
    using System;
    using System.Collections.Generic;

    internal class BookRepository : EfRepository<Book, Guid>, IBookRepository
    {
        private readonly AtlantisDbContext _dbContext;
        public BookRepository(AtlantisDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        IEnumerable<Book> IBookRepository.ReadAll() => _dbContext.Set<Book>();
    }
}
