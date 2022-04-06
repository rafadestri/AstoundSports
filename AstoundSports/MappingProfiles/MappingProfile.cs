using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace AstoundSports.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sport, SportDto>();
            CreateMap<SportForCreationDto, Sport>();
            CreateMap<SportForUpdateDto, Sport>();

            CreateMap<AthleteForCreationDto, Athlete>();
            CreateMap<AthleteForUpdateDto, Athlete>();
            CreateMap<Athlete, AthleteDto>().ForMember(a => a.FullName, opt => opt.MapFrom(o => string.Join(' ', o.Name, o.SurName)));
        }
    }
}
