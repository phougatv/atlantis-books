namespace Atlantis.WebApi.Book.Business
{
    using Atlantis.WebApi.Book.Dtos;
    using Atlantis.WebApi.Book.Persistence;
    using AutoMapper;
    using System;

    internal class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _repository;
        public BookService(
            IMapper mapper,
            IBookRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public BookDto Read(Guid id)
        {
            var book = _repository.Read(id);
            var bookDomainModel = _mapper.Map<BookDomainModel>(book);
            var bookDto = _mapper.Map<BookDto>(bookDomainModel);

            return bookDto;
        }
    }
}
