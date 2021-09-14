namespace Atlantis.WebApi.Book.Profiles
{
    using Atlantis.WebApi.Book.Business;
    using Atlantis.WebApi.Book.Dtos;
    using Atlantis.WebApi.Book.Persistence;
    using AutoMapper;

    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookCreateDto, BookDomainModel>();
            CreateMap<BookDto, BookDomainModel>().ReverseMap();
            CreateMap<BookUpdateDto, BookDomainModel>();
            CreateMap<BookDomainModel, Book>().ReverseMap();
        }
    }
}
