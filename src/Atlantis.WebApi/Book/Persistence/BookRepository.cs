namespace Atlantis.WebApi.Book.Persistence
{
    using System;

    public class BookRepository : IBookRepository
    {
        private readonly AtlantisDbContext _dbContext;
        public BookRepository(AtlantisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Book Read(Guid id)
        {
            return _dbContext.Set<Book>().Find(id);
        }
    }
}
