using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ludotek.Api.Business;
using Ludotek.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ludotek.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LudothequeController : GlobalController
    {
        /// <summary>
        /// Le business Ludotheque
        /// </summary>
        private readonly LudothequeBusiness ludothequeBusiness;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        /// <param name="business">la classe business injectée</param>
        public LudothequeController(LudothequeBusiness ludothequeBusiness)
        {
            this.ludothequeBusiness = ludothequeBusiness;
        }

        /// <summary>
        /// Retourne l'intégralité de la ludothèque
        /// </summary>
        /// <returns>L'intégralité de la ludothèque</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Appel au business
            var items = ludothequeBusiness.Get();
            // Conversion en model
            var itemsModel = items.ConvertAll(x => Ludotheque.ToModel(x));

            return Result(itemsModel.Cast<GlobalModel>().ToList());
        }

        /// <summary>
        /// Retourne un item de la ludothèque
        /// </summary>
        /// <param name="nomItem">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        [HttpGet("{nomItem}")]
        public IActionResult Get(string nomItem)
        {
            // Appel au business
            var items = ludothequeBusiness.Get(nomItem);
            // Conversion en model
            var itemsModel = items.ConvertAll(x => Ludotheque.ToModel(x));

            return Result(itemsModel.Cast<GlobalModel>().ToList());
        }

        [HttpPost]
        public void Post([FromBody]string filename)
        {
            //TODO
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Ludotheque item)
        {
            var itemDto = item.ToDto();

            // Appel au business
            ludothequeBusiness.UpdateItem(id, itemDto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO
        }
    }
}
