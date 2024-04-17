using CheckSkillsASP.DTOs;
using CheckSkillsASP.Entity;
using AutoMapper;

namespace CheckSkillsASP.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MemberForCreationDto, AppUser>();
            CreateMap<AppUser, MemberDto>();
            CreateMap<AppUser, UserDto>();
            CreateMap<RegDto, AppUser>();
            CreateMap<UserForUpdatingDto, AppUser>();
            CreateMap<AppUser, UserForUpdatingDto>();
        }
    }
}
