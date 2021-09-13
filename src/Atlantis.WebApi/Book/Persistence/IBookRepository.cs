namespace Atlantis.WebApi.Book.Persistence
{
    using Atlantis.WebApi.Shared.DataAccess.Base.Repository;
    using System;

    internal interface IBookRepository : IRepository<Book, Guid>
    {

    }
}
