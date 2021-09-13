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
            CreateMap<BookDomainModel, BookDto>().ReverseMap();
            CreateMap<Book, BookDomainModel>().ReverseMap();
        }
    }
}
