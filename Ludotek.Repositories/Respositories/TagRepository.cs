using Ludotek.Repositories.Context;
using Ludotek.Repositories.Interfaces;
using Ludotek.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Ludotek.Repositories.Respositories
{
    public class TagRepository : ITagRepository
    {
        /// <summary>
        /// Le repository
        /// </summary>
        public readonly LudotekContext context;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        public TagRepository(LudotekContext dbContext)
        {
            context = dbContext;
        }

        /// <summary>
        /// Récupère l'ensemble des tag existants
        /// </summary>
        /// <returns>Le tag trouvé</returns>
        public List<Tag> Get()
        {
            var result = context.Tags.ToList();

            return result;
        }

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomTag">Le tag recherché</param>
        /// <param name="nomItem">L'item recherché</param>
        /// <returns>Les items trouvés</returns>
        public Tag Get(string nomTag)
        {
            var result = context.Tags
                .Where(x => x.Nom == nomTag)
                .Include(e => e.Items)
                .FirstOrDefault();

            return result;
        }
    }
}
