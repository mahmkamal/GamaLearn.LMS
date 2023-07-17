using AutoMapper;
using GamaLearn.LMS.Models.DTO;
using GamaLearn.LMS.Models.Entites;

namespace GamaLearn.LMS.Infrastructure.Repository
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookDTOTiny>().ReverseMap();
        }
    }
}
