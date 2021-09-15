namespace Atlantis.WebApi.Book.Business
{
    using Atlantis.WebApi.Book.Persistence;
    using Atlantis.WebApi.Shared.DataAccess.UnitOfWork;
    using AutoMapper;
    using System;

    internal class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IBookRepository _repository;
        public BookService(
            IMapper mapper,
            IUnitOfWork uow,
            IBookRepository repository)
        {
            _mapper = mapper;
            _uow = uow;
            _repository = repository;
        }

        public bool Create(BookDomainModel model)
        {
            var book = _mapper.Map<Book>(model);
            book.Id = Guid.NewGuid();

            var isCreated = _repository.Create(book);
            var rowsAffected = _uow.Commit();

            return isCreated && rowsAffected == 1;
        }

        public BookDomainModel Read(Guid id)
        {
            var book = _repository.Read(id);
            var bookDomainModel = _mapper.Map<BookDomainModel>(book);

            return bookDomainModel;
        }

        public bool Updated(BookDomainModel model)
        {
            var book = _mapper.Map<Book>(model);
            var isUpdated = _repository.Update(book);
            var rowsAffected = _uow.Commit();

            return isUpdated && rowsAffected == 1;
        }

        public bool Delete(Guid id)
        {
            var isDeleted = _repository.Delete(id);
            var rowsAffected = _uow.Commit();

            return isDeleted && rowsAffected == 1;
        }
    }
}
