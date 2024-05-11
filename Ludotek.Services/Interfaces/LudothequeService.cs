using Ludotek.Services.Dto;

namespace Ludotek.Services
{
    public interface ILudothequeService
    {
        /// <summary>
        /// Retourne l'intégralité de la ludothèque
        /// </summary>
        /// <returns>L'intégralité de la ludothèque</returns>
        List<ItemDto> Get();

        /// <summary>
        /// Retourne les items de la ludothèque du type donné
        /// </summary>
        /// <returns>Les items de la ludothèque du type donnée</returns>
        List<ItemDto> GetByType(string type);

        /// <summary>
        /// Retourne une liste d'item correspondant au nom cherché
        /// </summary>
        /// <param name="nomItem">Le nom recherché</param>
        /// <returns>La liste des items trouvés</returns>
        List<ItemDto> Get(string nomItem);

        /// <summary>
        /// Met à jour un item existant
        /// </summary>
        /// <param name="fromBdd">L'item existant</param>
        /// <param name="fromApi">L'item contenant les nouvelles données</param>
        /// <returns>L'item mis à jour</returns>
        ItemDto UpdateItem(int id, ItemDto fromApi);
    }
}
