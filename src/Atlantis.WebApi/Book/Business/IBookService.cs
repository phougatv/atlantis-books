namespace Atlantis.WebApi.Book.Business
{
    using System;
    using System.Collections.Generic;

    public interface IBookService
    {
        bool Create(BookDomainModel model);
        BookDomainModel Read(Guid id);
        IEnumerable<BookDomainModel> ReadAll();
        bool Updated(BookDomainModel model);
        bool Delete(Guid id);
    }
}
