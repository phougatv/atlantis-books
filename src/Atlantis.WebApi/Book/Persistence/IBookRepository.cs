namespace Atlantis.WebApi.Book.Persistence
{
    using Atlantis.WebApi.Shared.DataAccess.Base.Repository;
    using System;

    public interface IBookRepository : IRepository<Book, Guid>
    {

    }
}
