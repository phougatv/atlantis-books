namespace Atlantis.WebApi.Book.Business
{
    using Atlantis.WebApi.Book.Dtos;
    using System;

    public interface IBookService
    {
        BookDto Read(Guid id);
    }
}
