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
    public class ImportBusiness : Business<ImportBusiness>
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
        public ImportBusiness(IStringLocalizer<ImportBusiness> localizer,
            LudothequeDao ludothequeDao,
            TagDao tagDao) : base(localizer)
        {
            this.ludothequeDao = ludothequeDao;
            this.tagDao = tagDao;
        }

        #region Méthodes publiques

        /// <summary>
        /// Initialise la base de données à partir du fichier init.csv
        /// </summary>
        public void Process(string filenameCsv)
        {
            //Read the contents of CSV file.
            string csvData = File.ReadAllText($@"Resources\Input\{filenameCsv}");

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

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Ajoute un nouvel item avec ses tags
        /// </summary>
        /// <param name="inputItem">L'item à rajouter</param>
        /// <param name="inputTags">Les tags de l'item</param>
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
        /// Retourne ou crée le tag cherché
        /// </summary>
        /// <param name="inputTag">Le tag cherché</param>
        /// <returns>Le tag</returns>
        private TagDto CheckTag(string inputTag)
        {
            // Récupération du tag en BDD
            var tag = tagDao.Get(inputTag);

            if (tag == null)
            {
                // Le tag n'existe pas -> On en crée un nouveau
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
