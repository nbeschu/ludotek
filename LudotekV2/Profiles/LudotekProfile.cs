using AutoMapper;
using Ludotek.Repositories.Models;
using Ludotek.Services.Dto;
using Ludotek2.Models;
using LudotekV2.Models;

namespace LudotekV2.Profiles
{
    public class LudotekProfile : Profile
    {
        public LudotekProfile()
        {
            CreateMap<ItemDto, Item>().ReverseMap();
            CreateMap<TagDto, Tag>().ReverseMap();
            CreateMap<ItemTagDto, ItemTag>().ReverseMap();

            CreateMap<ErreurDto, Erreur>().ReverseMap();
            CreateMap<ItemDto, ItemViewModel>()
                .ForMember(dest => dest.IsTermine, opt => opt.MapFrom(src => src.IsTermine ? "Oui" : "Non"))
                .ReverseMap();
            CreateMap<TagDto, TagViewModel>().ReverseMap();
        }
    }
}
