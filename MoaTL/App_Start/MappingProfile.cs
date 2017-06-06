using AutoMapper;
using MoaTL.Dtos;
using MoaTL.Models;

namespace MoaTL.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CharacterDto, Character>();
            CreateMap<Character, CharacterDto>();
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
        }
    }
}