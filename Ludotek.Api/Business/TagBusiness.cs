using Ludotek.Api.Dao;
using Ludotek.Api.Dto;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ludotek.Api.Business
{
    public class TagBusiness : Business<TagBusiness>
    {
        /// <summary>
        /// Le Dao Ludotheque
        /// </summary>
        private readonly LudothequeDao ludothequeDao;

        /// <summary>
        /// Le Dao Tag
        /// </summary>
        private readonly TagDao tagDao;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        /// <param name="business">la classe business injectée</param>
        public TagBusiness(IStringLocalizer<TagBusiness> localizer,
            LudothequeDao ludothequeDao,
            TagDao tagDao) : base(localizer)
        {
            this.ludothequeDao = ludothequeDao;
            this.tagDao = tagDao;
        }

        #region Méthodes publiques

        /// <summary>
        /// Retourne l'intégralité des tags existants
        /// </summary>
        /// <returns>L'intégralité des tags existants</returns>
        public List<TagDto> Get()
        {
            // Appel au Dao
            var result = tagDao.Get();

            if (result == null)
            {
                result = new List<TagDto>();
            }

            return result;
        }

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomTag">Le tag recherché</param>
        /// <returns>Les items trouvés</returns>
        public List<LudothequeDto> Get(string nomTag)
        {
            var items = ludothequeDao.Get();
            var result = FindItemsByTag(nomTag, items);

            return result;
        }

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomTag">Le tag recherché</param>
        /// <param name="nomItem">Le nom d'item recherché</param>
        /// <returns>Les items trouvés</returns>
        public List<LudothequeDto> Get(string nomTag, string nomItem)
        {
            var items = ludothequeDao.Get(nomItem);
            var result = FindItemsByTag(nomTag, items);

            return result;
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Retourne la liste des items d'un tag donné contenu dans la liste d'items
        /// </summary>
        /// <param name="nomTag">Le tag cherché</param>
        /// <param name="items">La liste d'items à parcourir</param>
        /// <returns>La liste des items du tag donné</returns>
        private static List<LudothequeDto> FindItemsByTag(string nomTag, List<LudothequeDto> items)
        {
            List<LudothequeDto> result = new List<LudothequeDto>();

            // Si des items sont retournés-> On cherche les items de ce tag
            if (items != null)
            {
                foreach (var item in items)
                {
                    var list = item.LudoTag.Where(x => x.Tag.NomTag.ToUpperInvariant() == nomTag.ToUpperInvariant())
                        .Select(x => x.Ludotheque);

                    result.AddRange(list);
                }
            }

            return result;
        }

        #endregion
    }
}
