using Ludotek.Api.Dao;
using Ludotek.Api.Dto;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludotek.Api.Business
{
    public class LudothequeBusiness : Business<LudothequeBusiness>
    {
        /// <summary>
        /// Le business Raccordement
        /// </summary>
        private readonly LudothequeDao ludothequeDao;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        /// <param name="business">la classe business injectée</param>
        public LudothequeBusiness(IStringLocalizer<LudothequeBusiness> localizer,
            LudothequeDao ludothequeDao) : base(localizer)
        {
            this.ludothequeDao = ludothequeDao;
        }

        /// <summary>
        /// Retourne l'intégralité de la ludothèque
        /// </summary>
        /// <returns>L'intégralité de la ludothèque</returns>
        public List<LudothequeDto> Get()
        {
            // Appel au Dao
            var result = ludothequeDao.Get();

            if (result == null)
            {
                result = new List<LudothequeDto>();
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
            // Apell au Dao
            var result = ludothequeDao.Get(nomItem);

            if (result == null)
            {
                result = new LudothequeDto
                {
                    Erreur = CreateErreur("LudoErr01", nomItem)
                };
            }

            return result;
        }
    }
}
