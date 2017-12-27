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
    public class LudothequeBusiness : Business<LudothequeBusiness>
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
        public LudothequeBusiness(IStringLocalizer<LudothequeBusiness> localizer,
            LudothequeDao ludothequeDao,
            TagDao tagDao) : base(localizer)
        {
            this.ludothequeDao = ludothequeDao;
            this.tagDao = tagDao;
        }

        #region Méthodes publiques

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
                // Pas d'item trouvé -> On renvoi une liste vide
                result = new List<LudothequeDto>();
            }

            return result;
        }

        /// <summary>
        /// Retourne une liste d'item correspondant au nom cherché
        /// </summary>
        /// <param name="nomItem">Le nom recherché</param>
        /// <returns>La liste des items trouvés</returns>
        public List<LudothequeDto> Get(string nomItem)
        {
            // Apell au Dao
            var result = ludothequeDao.Get(nomItem);

            if (result == null)
            {
                // Pas d'item trouvé -> On renvoi une liste vide
                result = new List<LudothequeDto>();
            }

            return result;
        }

        /// <summary>
        /// Met à jour un item existant
        /// </summary>
        /// <param name="fromBdd">L'item existant</param>
        /// <param name="fromApi">L'item contenant les nouvelles données</param>
        /// <returns>L'item mis à jour</returns>
        public LudothequeDto UpdateItem(int id, LudothequeDto fromApi)
        {
            var fromBdd = Get(id);

            if (fromBdd != null)
            {
                // On met à jour l'existant avec les données en entrée de l'API
                Update(fromBdd, fromApi);

                return fromBdd;
            }
            else
            {
                return new LudothequeDto
                {
                    Erreur = CreateErreur("LudoErr01", id.ToString())
                };
            }
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Retourne un item de la ludothèque
        /// </summary>
        /// <param name="id">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        private LudothequeDto Get(int id)
        {
            // Apell au Dao
            var result = ludothequeDao.Get(id);

            if (result == null)
            {
                result = new LudothequeDto
                {
                    Erreur = CreateErreur("LudoErr01", id.ToString())
                };
            }

            return result;
        }

        /// <summary>
        /// Met à jour un item existant
        /// </summary>
        /// <param name="fromBdd">L'item existant</param>
        /// <param name="fromApi">L'item contenant les nouvelles données</param>
        private void Update(LudothequeDto fromBdd, LudothequeDto fromApi)
        {
            fromBdd.NomItem = fromApi.NomItem;
            fromBdd.LudoTag = fromApi.LudoTag;

            // On recopie l'item d'origine dans l'objet relation
            foreach (var ludoTag in fromBdd.LudoTag)
            {
                ludoTag.Ludotheque = fromBdd;
            }

            // Maj en BDD
            ludothequeDao.Update(fromBdd);
        }

        private void UpdateTags(LudothequeDto item, List<string> inputTags)
        {
            var itemTags = new List<LudoTagDto>();

            foreach (var tag in inputTags)
            {
                itemTags.Add(new LudoTagDto
                {
                    Ludotheque = item,
                    //Tag = CheckTag(tag) TODO : vérifier l'existence du tag
                });
            }

            // On ajoute les nouveaux tags à l'item
            item.LudoTag = itemTags;

            // Maj en BDD
            ludothequeDao.Update(item);
        }

        #endregion
    }
}
