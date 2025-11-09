using Ludotek.Services.Dto;

namespace Ludotek.Services.Interfaces
{
    public interface ILudothequeService
    {
        /// <summary>
        /// Retourne les items de la ludothèque du type donné
        /// </summary>
        /// <returns>Les items de la ludothèque du type donnée</returns>
        IEnumerable<ItemDto> GetByType(string type);
    }
}
