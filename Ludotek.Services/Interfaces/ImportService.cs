namespace Ludotek.Services
{
    public interface IImportService
    {
        /// <summary>
        /// Initialise la base de données à partir du fichier init.csv
        /// </summary>
        void Process(string filenameCsv);
    }
}
