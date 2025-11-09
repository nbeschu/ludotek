using CsvHelper;
using CsvHelper.Configuration;
using Ludotek.Services.Dto;
using Ludotek.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Globalization;

namespace LudotekV2.DataStore
{
    public class CsvDataStore : IDataStore
    {
        public IReadOnlyCollection<ItemDto> Jeux { get; private set; } = Array.Empty<ItemDto>();
        public IReadOnlyCollection<ItemDto> FilmsSeries { get; private set; } = Array.Empty<ItemDto>();
        public IReadOnlyCollection<ItemDto> Animes { get; private set; } = Array.Empty<ItemDto>();

        /// <summary>
        /// Initialise la base de données à partir du fichier init.csv
        /// </summary>
        public void Load()
        {
            List<ItemDto> items = new();

            // Chemin vers le fichier CSV
            string cheminFichierCSV = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Input", "full.csv");

            if (!File.Exists(cheminFichierCSV))
                throw new FileNotFoundException($"Le fichier CSV '{cheminFichierCSV}' est introuvable.");

            try
            {
                CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };

                // Lecture du CSV
                using (StreamReader reader = new StreamReader(cheminFichierCSV))
                using (CsvReader csvReader = new CsvReader(reader, configuration))
                {
                    csvReader.Context.RegisterClassMap<ItemDtoMap>();
                    items = csvReader.GetRecords<ItemDto>().OrderBy(x => x.Nom).ToList();
                }

                List<ItemDto> jeux = items.FindAll(x => x.Type == "Jeu vidéo");
                List<ItemDto> films = items.FindAll(x => x.Type == "Film");
                List<ItemDto> series = items.FindAll(x => x.Type == "Série");
                List<ItemDto> animes = items.FindAll(x => x.Type == "Anime");

                // Rendre immuables pour lecture concurrente
                Jeux = new ReadOnlyCollection<ItemDto>(jeux);
                FilmsSeries = new ReadOnlyCollection<ItemDto>([.. films, .. series]);
                Animes = new ReadOnlyCollection<ItemDto>(animes);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erreur de lecture du fichier CSV.", ex);
            }
        }
    }
}
