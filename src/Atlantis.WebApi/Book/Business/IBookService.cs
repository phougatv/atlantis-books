namespace Atlantis.WebApi.Book.Business
{
    using System;

    public interface IBookService
    {
        BookDomainModel Read(Guid id);
    }
}
