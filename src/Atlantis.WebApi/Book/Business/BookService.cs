namespace Atlantis.WebApi.Book.Business
{
    using Atlantis.WebApi.Book.Persistence;
    using System;

    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Read(Guid id)
        {
            return _repository.Read(id);
        }
    }
}
