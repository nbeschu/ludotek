using AutoMapper;
using CsvHelper.Configuration;
using CsvHelper;
using Ludotek.Repositories.Interfaces;
using Ludotek.Repositories.Models;
using Ludotek.Services.Dto;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Ludotek.Services.Services
{
    public class ImportService : BaseService<ImportService>, IImportService
    {
        /// <summary>
        /// Le Repository Ludotheque
        /// </summary>
        private readonly ILudothequeRepository ludothequeRepository;

        /// <summary>
        /// Le Repository Tag
        /// </summary>
        private readonly ITagRepository tagRepository;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        public ImportService(
            IStringLocalizer<ImportService> localizer,
            IMapper mapper,
            ILudothequeRepository ludothequeRepository,
            ITagRepository tagRepository) : base(localizer, mapper)
        {
            this.ludothequeRepository = ludothequeRepository;
            this.tagRepository = tagRepository;
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
                    var item = ludothequeRepository.GetForCreate(inputItem);

                    if (item == null)
                    {
                        // Nouvel item -> On crée de 0
                        Insert(inputItem, inputTags);
                    }
                }
            }
        }

        /// <summary>
        /// Initialise la base de données à partir du fichier init.csv
        /// </summary>
        public void ImportDatabase(string filenameCsv)
        {
            List<ItemDto> items = new();

            // Chemin vers le fichier CSV
            string cheminFichierCSV = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Input", filenameCsv);

            CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };

            // Lecture du CSV
            using (StreamReader reader = new StreamReader(cheminFichierCSV))
            using (CsvReader csvReader = new CsvReader(reader, configuration))
            {
                csvReader.Context.RegisterClassMap<ItemDtoMap>();
                items = csvReader.GetRecords<ItemDto>().ToList();
            }

            // Ajout des items en BDD
            var itemsModel = _mapper.Map<List<Item>>(items);
            ludothequeRepository.Upsert(itemsModel);
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
            var item = new ItemDto
            {
                Nom = inputItem
            };

            // Construction des tags
            var tags = inputTags.Split(';');

            foreach (var tag in tags)
            {
                item.Tags.Add(CheckTag(tag));
            }

            // Ajout de l'item en BDD
            var itemModel = _mapper.Map<Item>(item);
            ludothequeRepository.Insert(itemModel);
        }

        /// <summary>
        /// Retourne ou crée le tag cherché
        /// </summary>
        /// <param name="inputTag">Le tag cherché</param>
        /// <returns>Le tag</returns>
        private TagDto CheckTag(string inputTag)
        {
            // Récupération du tag en BDD
            Tag tagModel = tagRepository.Get(inputTag);

            if (tagModel == null)
            {
                // Le tag n'existe pas -> On en crée un nouveau
                return new TagDto
                {
                    Nom = inputTag
                };
            }

            var tag = _mapper.Map<TagDto>(tagModel);

            return tag;
        }

        #endregion
    }
}
