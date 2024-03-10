using CheckSkillsASP.DTOs;
using CheckSkillsASP.Entity;
using AutoMapper;

namespace CheckSkillsASP.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            Console.Clear();
            Console.WriteLine("Mapping here...");
            CreateMap<DTOs.MemberForCreationDto, Entity.AppUser>();
            CreateMap<Entity.AppUser, DTOs.MemberDto>();
        }
    }
}
