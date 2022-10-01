using AutoMapper;
using LibraryService.Application.Features.UserLibraries.Commands.AddLibraryBookCommand;
using LibraryService.Domain.Entities;

namespace LibraryService.Application.Mapping.AutoMapper
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<LibraryBook, AddLibraryBookCommandRequest>().ReverseMap();
            CreateMap<LibraryBook, AddLibraryBookCommandResponse>().ReverseMap();
        }
    }
}
