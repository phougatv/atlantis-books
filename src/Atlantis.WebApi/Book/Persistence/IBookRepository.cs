namespace Atlantis.WebApi.Book.Persistence
{
    using Atlantis.WebApi.Shared.DataAccess.Base.Repository;
    using System;
    using System.Collections.Generic;

    internal interface IBookRepository : IRepository<Book, Guid>
    {
        IEnumerable<Book> ReadAll();
    }
}
