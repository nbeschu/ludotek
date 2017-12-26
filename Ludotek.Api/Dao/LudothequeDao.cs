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

            result = context.Ludotheque
                .Include(e => e.LudoTag)
                .ThenInclude(e => e.Tag)
                .ToList();

            return result;
        }

        /// <summary>
        /// Retourne un item de la ludothèque
        /// </summary>
        /// <param name="id">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        public LudothequeDto Get(int id)
        {
            var result = new LudothequeDto();

            result = context.Ludotheque
                .Where(x => x.Id == id)
                .Include(e => e.LudoTag)
                .ThenInclude(e => e.Tag)
                .FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomItem">l'item recherché</param>
        /// <returns>Les items trouvés</returns>
        public List<LudothequeDto> Get(string nomItem)
        {
            var result = new List<LudothequeDto>();

            result = context.Ludotheque
                .Where(x => x.NomItem.Contains(nomItem))
                .Include(e => e.LudoTag)
                .ThenInclude(e => e.Tag)
                .ToList();

            return result;
        }

        /// <summary>
        /// Retourne un item de la ludothèque
        /// </summary>
        /// <param name="nomItem">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        public LudothequeDto GetForCreate(string nomItem)
        {
            var result = new LudothequeDto();

            result = context.Ludotheque
                .Where(x => x.NomItem == nomItem)
                .Include(e => e.LudoTag)
                .ThenInclude(e => e.Tag)
                .FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Ajoute une liste item avec leurs tags
        /// </summary>
        /// <param name="itemTags">La liste item avec leurs tags</param>
        public void Insert(LudothequeDto item)
        {
            context.Ludotheque.Add(item);
            context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un item avec ses tags
        /// </summary>
        /// <param name="item">l'item avec ses tags</param>
        internal void Update(LudothequeDto item)
        {
            context.Update(item);
            context.SaveChanges();
        }
    }
}
