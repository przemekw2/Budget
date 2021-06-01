using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<SpendResourceDto, Spend>();

            CreateMap<Spend, SpendResourceDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name));
        }
    }
}