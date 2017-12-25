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
        /// Récupère un tag
        /// </summary>
        /// <param name="inputTag">Le tag recherché</param>
        /// <returns>Le tag trouvé</returns>
        public TagDto Get(string inputTag)
        {
            var result = new TagDto();

            result = context.Tag
                .Where(x => x.NomTag == inputTag)
                .FirstOrDefault();

            return result;
        }
    }
}
