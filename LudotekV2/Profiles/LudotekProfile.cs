using AutoMapper;
using Ludotek.Repositories.Models;
using Ludotek.Services.Dto;
using LudotekV2.Models;

namespace LudotekV2.Profiles
{
    public class LudotekProfile : Profile
    {
        public LudotekProfile()
        {
            CreateMap<Wheel, WheelDto>()
                .ForMember(dest => dest.NomRoue, opt => opt.MapFrom(src => src.Config.Title))
                .ForMember(dest => dest.Entries, opt => opt.MapFrom(src => src.Config.Entries
                    .GroupBy(e => e.Text)
                    .Select(g => new EntryDto
                    {
                        Nom = g.Key,
                        NombreOccurence = g.Count()
                    })
                    .ToList()
                    ))
                .ReverseMap();

            CreateMap<ErreurDto, Erreur>().ReverseMap();
            CreateMap<ItemDto, ItemViewModel>()
                .ForMember(dest => dest.IsTermine, opt => opt.MapFrom(src => src.IsTermine ? "Oui" : "Non"))
                .ReverseMap();
            CreateMap<WheelDto, WheelViewModel>().ReverseMap();
            CreateMap<EntryDto, EntryViewModel>().ReverseMap();
        }
    }
}
