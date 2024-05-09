using Ludotek.Repositories.Models;

namespace Ludotek.Repositories.Interfaces
{
    public interface ITagRepository
    {
        /// <summary>
        /// Récupère l'ensemble des tag existants
        /// </summary>
        /// <returns>Le tag trouvé</returns>
        List<Tag> Get();

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomTag">Le tag recherché</param>
        /// <param name="nomItem">L'item recherché</param>
        /// <returns>Les items trouvés</returns>
        Tag Get(string nomTag);
    }
}
