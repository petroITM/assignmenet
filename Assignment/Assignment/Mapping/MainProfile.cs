using Assignment.Dto;
using Assignment.Mapping;
using Assignment.Model;
using AutoMapper;

namespace Assignment.MappingProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<AddContactDto, Contact>()
               .ForMember(dest => dest.SecondaryEmails,
                opt => opt.MapFrom(src => src.SecondaryEmails));

            CreateMap<UpdateContactDto, Contact>()
                .ForMember(dest => dest.SecondaryEmails, opt => opt.MapFrom(src => src.SecondaryEmails))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<string, SecondaryEmail>().ConvertUsing(new StringToSecondaryEmailConverter());
        }
    }
}
