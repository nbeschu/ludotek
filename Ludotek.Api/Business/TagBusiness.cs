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
    public class TagBusiness : Business<LudothequeBusiness>
    {
        /// <summary>
        /// Le Dao Tag
        /// </summary>
        private readonly TagDao tagDao;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        /// <param name="business">la classe business injectée</param>
        public TagBusiness(IStringLocalizer<LudothequeBusiness> localizer,
            TagDao tagDao) : base(localizer)
        {
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
            List<LudothequeDto> result = new List<LudothequeDto>(); ;

            var tag = RecupererTag(nomTag);

            // Si le tag cherché existe -> On cherche les items de ce tag
            if (tag.Erreur == null)
            {
                // On n'a pas d'item à chercher -> On récupère tous les items
                foreach (var ludoTag in tag.LudoTag)
                {
                    result.Add(ludoTag.Ludotheque);
                }
            }

            return result;
        }

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomTag">Le tag recherché</param>
        /// <param name="nomItem">L'item recherché</param>
        /// <returns>Les items trouvés</returns>
        public List<LudothequeDto> Get(string nomTag, string nomItem)
        {
            List<LudothequeDto> result = new List<LudothequeDto>(); ;

            var tag = RecupererTag(nomTag);

            // Si le tag cherché existe -> On cherche les items de ce tag
            if (tag.Erreur == null)
            {
                // On a un item à chercher -> on récupère les items correspondants à la recherche
                foreach (var ludoTag in tag.LudoTag)
                {
                    if (ludoTag.Ludotheque.NomItem.ToUpperInvariant().Contains(nomItem.ToUpperInvariant()))
                    {
                        result.Add(ludoTag.Ludotheque);
                    }
                }
            }

            return result;
        }

        #endregion

        /// <summary>
        /// Retourne un tag existant
        /// </summary>
        /// <param name="nomTag">le tag recherché</param>
        /// <returns>Le tag trouvé</returns>
        private TagDto RecupererTag(string nomTag)
        {
            // Apell au Dao
            var result = tagDao.Get(nomTag);

            if (result == null)
            {
                result = new TagDto
                {
                    Erreur = CreateErreur("TagErr01", nomTag)
                };
            }

            return result;
        }
    }
}
