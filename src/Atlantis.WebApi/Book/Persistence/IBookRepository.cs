namespace Atlantis.WebApi.Book.Persistence
{
    using System;

    public interface IBookRepository
    {
        Book Read(Guid id);
    }
}
