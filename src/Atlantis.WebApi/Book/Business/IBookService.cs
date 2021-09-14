namespace Atlantis.WebApi.Book.Business
{
    using System;

    public interface IBookService
    {
        bool Create(BookDomainModel model);
        BookDomainModel Read(Guid id);
    }
}
