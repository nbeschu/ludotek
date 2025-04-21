using Ludotek.Services.Dto;

namespace Ludotek.Services
{
    public interface ITagService
    {
        /// <summary>
        /// Retourne l'intégralité des tags existants
        /// </summary>
        /// <returns>L'intégralité des tags existants</returns>
        List<TagDto> Get();

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomTag">Le tag recherché</param>
        /// <returns>Les items trouvés</returns>
        List<ItemDto> Get(string nomTag);

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomTag">Le tag recherché</param>
        /// <param name="nomItem">Le nom d'item recherché</param>
        /// <returns>Les items trouvés</returns>
        List<ItemDto> Get(string nomTag, string nomItem);
    }
}
