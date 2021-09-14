namespace Atlantis.WebApi.Book.Business
{
    using Atlantis.WebApi.Book.Persistence;
    using AutoMapper;
    using System;

    internal class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly AtlantisDbContext _dbContext;
        private readonly IBookRepository _repository;
        public BookService(
            IMapper mapper,
            AtlantisDbContext dbContext,
            IBookRepository repository)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _repository = repository;
        }

        public bool Create(BookDomainModel model)
        {
            var book = _mapper.Map<Book>(model);
            book.Id = Guid.NewGuid();

            var isCreated = _repository.Create(book);
            var rowsAffected = _dbContext.SaveChanges();

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
            var rowsAffected = _dbContext.SaveChanges();

            return isUpdated && rowsAffected == 1;
        }

        public bool Delete(Guid id)
        {
            var isDeleted = _repository.Delete(id);
            var rowsAffected = _dbContext.SaveChanges();

            return isDeleted && rowsAffected == 1;
        }
    }
}
