using Ludotek.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ludotek2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ImportController : Controller
    {
        /// <summary>
        /// Le business Import
        /// </summary>
        private readonly IImportService importService;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        /// <param name="importService">la classe business injectée</param>
        public ImportController(IImportService importService)
        {
            this.importService = importService;
        }

        /// <summary>
        /// Ajoute des items à partir d'un fichier csv
        /// </summary>
        /// <param name="filename">Le nom du fichier csv</param>
        [HttpPost]
        public void Post([FromBody]string filename)
        {
            // Appel au business
            importService.Process(filename);
        }
    }
}