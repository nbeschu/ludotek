using Ludotek.Repositories.Models;

namespace Ludotek.Repositories.Interfaces
{
    public interface ILudothequeRepository
    {
        /// <summary>
        /// Retourne l'intégralité de la ludothèque
        /// </summary>
        /// <returns>L'intégralité de la ludothèque</returns>
        List<Item> Get();

        /// <summary>
        /// Retourne un item de la ludothèque
        /// </summary>
        /// <param name="id">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        Item Get(int id);

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomItem">l'item recherché</param>
        /// <returns>Les items trouvés</returns>
        List<Item> Get(string nomItem);

        /// <summary>
        /// Retourne un item de la ludothèque en vu d'une création
        /// </summary>
        /// <param name="nomItem">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        Item GetForCreate(string nomItem);

        /// <summary>
        /// Ajoute une item avec ses tags
        /// </summary>
        /// <param name="item">L'item avec ses tags</param>
        void Insert(Item item);

        /// <summary>
        /// Met à jour un item avec ses tags
        /// </summary>
        /// <param name="item">l'item avec ses tags</param>
        void Update(Item item);
    }
}
