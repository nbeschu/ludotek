using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ludotek.Api.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ludotek.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ImportController : Controller
    {
        /// <summary>
        /// Le business Import
        /// </summary>
        private readonly ImportBusiness importBusiness;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        /// <param name="business">la classe business injectée</param>
        public ImportController(ImportBusiness importBusiness)
        {
            this.importBusiness = importBusiness;
        }

        /// <summary>
        /// Ajoute des items à partir d'un fichier csv
        /// </summary>
        /// <param name="filename">Le nom du fichier csv</param>
        [HttpPost]
        public void Post([FromBody]string filename)
        {
            // Appel au business
            importBusiness.Process(filename);
        }
    }
}