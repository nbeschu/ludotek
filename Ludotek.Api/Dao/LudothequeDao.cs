using Ludotek.Api.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludotek.Api.Dao
{
    public class LudothequeDao
    {
        /// <summary>
        /// Le repository
        /// </summary>
        public readonly Context context;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        public LudothequeDao(Context dbContext)
        {
            context = dbContext;
        }

        /// <summary>
        /// Retourne l'intégralité de la ludothèque
        /// </summary>
        /// <returns>L'intégralité de la ludothèque</returns>
        public List<LudothequeDto> Get()
        {
            var result = new List<LudothequeDto>();

            using (context)
            {
                result = context.Ludotheque
                    .Include(e => e.LudoTag)
                    .ThenInclude(e => e.Tag)
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Retourne un item de la ludothèque
        /// </summary>
        /// <param name="nomItem">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        public LudothequeDto Get(string nomItem)
        {
            var result = new LudothequeDto();

            using (context)
            {
                result = context.Ludotheque
                    .Where(x => x.NomItem == nomItem)
                    .Include(e => e.LudoTag)
                    .ThenInclude(e => e.Tag)
                    .FirstOrDefault();
            }

            return result;
        }
    }
}
