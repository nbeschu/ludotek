using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ludotek.Api.Business;
using Ludotek.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ludotek.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TagController : GlobalController
    {
        /// <summary>
        /// Le business Raccordement
        /// </summary>
        private readonly TagBusiness tagBusiness;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        /// <param name="business">la classe business injectée</param>
        public TagController(TagBusiness tagBusiness)
        {
            this.tagBusiness = tagBusiness;
        }

        /// <summary>
        /// Retourne l'intégralité de la ludothèque
        /// </summary>
        /// <returns>L'intégralité de la ludothèque</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Appel au business
            var items = tagBusiness.Get();
            // Conversion en model
            var itemsModel = items.ConvertAll(x => Tag.ToModel(x));

            return Result(itemsModel.Cast<GlobalModel>().ToList());
        }

        /// <summary>
        /// Retourne l'intégralité de la ludothèque
        /// </summary>
        /// <returns>L'intégralité de la ludothèque</returns>
        [HttpGet]
        [Route("{nomTag}/item/{nomItem}")]
        public IActionResult Get(string nomTag, string nomItem)
        {
            // Appel au business
            var items = tagBusiness.Get(nomTag, nomItem);
            // Conversion en model
            var itemsModel = items.ConvertAll(x => Ludotheque.ToModel(x));

            return Result(itemsModel.Cast<GlobalModel>().ToList());
        }
    }
}