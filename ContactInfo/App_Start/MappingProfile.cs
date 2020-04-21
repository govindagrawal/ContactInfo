using AutoMapper;
using ContactInfo.Dtos;
using ContactInfo.Models;
using ContactInfo.ViewModels;

namespace ContactInfo.App_Start
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