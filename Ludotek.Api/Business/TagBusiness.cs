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
        /// Retourne un tag existant
        /// </summary>
        /// <param name="nomTag">le tag recherché</param>
        /// <returns>Le tag trouvé</returns>
        public TagDto Get(string nomTag)
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

        #endregion
    }
}
