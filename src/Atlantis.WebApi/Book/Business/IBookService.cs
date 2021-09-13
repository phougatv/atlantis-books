namespace Atlantis.WebApi.Book.Business
{
    using Atlantis.WebApi.Book.Persistence;
    using System;

    public interface IBookService
    {
        Book Read(Guid id);
    }
}
