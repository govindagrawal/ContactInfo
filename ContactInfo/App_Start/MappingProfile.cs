using AutoMapper;
using ContactInfo.Dtos;
using ContactInfo.Models;

namespace ContactInfo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}