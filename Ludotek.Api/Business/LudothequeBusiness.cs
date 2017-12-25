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
                result = new List<LudothequeDto>();
            }

            return result;
        }

        /// <summary>
        /// Retourne un item de la ludothèque
        /// </summary>
        /// <param name="id">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        public LudothequeDto Get(int id)
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

        /// <summary>
        /// Initialise la base de données à partir du fichier init.csv
        /// </summary>
        public void Process()
        {
            //Read the contents of CSV file.
            string csvData = File.ReadAllText(@"Resources\Input\init.csv");

            //Execute a loop over the rows.
            foreach (string row in csvData.Split("\r\n"))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    int index = row.IndexOf(';');
                    string inputItem = row.Substring(0, index);
                    string inputTags = row.Substring(index + 1);

                    // Vérification de l'existance de l'item
                    var item = ludothequeDao.GetForCreate(inputItem);

                    if (item == null)
                    {
                        // Nouvel item -> On crée de 0
                        Insert(inputItem, inputTags);
                    }
                }
            }
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
                    Tag = CheckTag(tag)
                });
            }

            // On ajoute les nouveaux tags à l'item
            item.LudoTag = itemTags;

            // Maj en BDD
            ludothequeDao.Update(item);
        }

        private void Insert(string inputItem, string inputTags)
        {
            // Construction de l'item
            var item = new LudothequeDto
            {
                NomItem = inputItem
            };

            // Construction des tags
            var itemTags = new List<LudoTagDto>();
            var tags = inputTags.Split(';');

            foreach (var tag in tags)
            {
                itemTags.Add(new LudoTagDto
                {
                    Ludotheque = item,
                    Tag = CheckTag(tag)
                });
            }

            //On ajoute les tags à l'item
            item.LudoTag = itemTags;

            // Ajout de l'item en BDD
            ludothequeDao.Insert(item);
        }

        /// <summary>
        /// Retourne ou crée le tag cherché s'il n'existe pas
        /// </summary>
        /// <param name="inputTag">Le tag cherché</param>
        /// <returns>Le tag</returns>
        private TagDto CheckTag(string inputTag)
        {
            var tag = tagDao.Get(inputTag);

            if (tag == null)
            {
                tag = new TagDto
                {
                    NomTag = inputTag
                };
            }

            return tag;
        }

        #endregion
    }
}
