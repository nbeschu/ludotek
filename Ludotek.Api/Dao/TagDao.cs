using Ludotek.Api.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludotek.Api.Dao
{
    public class TagDao
    {
        /// <summary>
        /// Le repository
        /// </summary>
        public readonly Context context;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        public TagDao(Context dbContext)
        {
            context = dbContext;
        }

        /// <summary>
        /// Récupère l'ensemble des tag existants
        /// </summary>
        /// <returns>Le tag trouvé</returns>
        public List<TagDto> Get()
        {
            var result = context.Tag.ToList();

            return result;
        }

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomTag">Le tag recherché</param>
        /// <param name="nomItem">L'item recherché</param>
        /// <returns>Les items trouvés</returns>
        public TagDto Get(string nomTag)
        {
            var result = context.Tag
                .Where(x => x.NomTag == nomTag)
                .Include(e => e.LudoTag)
                .ThenInclude(e => e.Ludotheque)
                .FirstOrDefault();

            return result;
        }
    }
}
