using Ludotek.Services.Dto;

namespace Ludotek.Services.Interfaces
{
    public interface IDataStore
    {
        IReadOnlyCollection<ItemDto> Jeux { get; }
        IReadOnlyCollection<ItemDto> FilmsSeries { get; }
        IReadOnlyCollection<ItemDto> Animes { get; }
    }
}
