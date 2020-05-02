using AutoMapper;
using ContactInfo.Dtos;
using ContactInfo.Models;
using ContactInfo.ViewModels;

namespace ContactInfo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Contact, ContactDto>().ReverseMap();
            Mapper.CreateMap<Contact, ContactFormViewModel>().ReverseMap();
        }
    }
}